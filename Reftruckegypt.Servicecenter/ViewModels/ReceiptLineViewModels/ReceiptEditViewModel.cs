using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels
{
    public class ReceiptEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<ReceiptLine> _validator;
        private DateTime _receiptDate = DateTime.Now;
        private Period _period = null;
        private bool _hasChanged = false;

        public ReceiptEditViewModel(
            IEnumerable<PurchaseRequestLine> purchaseRequestLines,
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext,
            IValidator<ReceiptLine> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_receiptDate);
            foreach (var line in purchaseRequestLines)
            {
                decimal remainingQuantity = line.RequestedQuantity - line.ReceiptLines.Sum(x => x.ReceivedQuantity);
                if (remainingQuantity > 0)
                {
                    Lines.Add(new ReceiptLineEditViewModel()
                    {
                        ReceivedQuantity = remainingQuantity,
                        ReceiptDate = DateTime.Now,
                        PurchaseRequestLine = line,
                        Period = _period,
                        Validator = _validator
                    });
                }
            }
            Lines.ListChanged += (o, e) =>
            {
                HasChanged = true;
            };
            HasChanged = true;
        }
        public ReceiptEditViewModel(
            ReceiptLine receiptLine,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<ReceiptLine> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _receiptDate = receiptLine.ReceiptDate;
            _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_receiptDate);
            Lines.Add(new ReceiptLineEditViewModel(receiptLine)
            {
                Validator = _validator
            });
        }
        public bool HasChanged
        {
            get => _hasChanged;
            private set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public DateTime ReceiptDate
        {
            get => _receiptDate;
            set
            {
                if (_receiptDate != value)
                {
                    _receiptDate = value;
                    _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_receiptDate);
                    OnPropertyChanged(this, nameof(ReceiptDate));
                    foreach (var line in Lines)
                    {
                        line.ReceiptDate = _receiptDate;
                        line.Period = _period;
                    }
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                IList<ReceiptLine> receiptLines = Lines.Select(x => x.ReceiptLine).Where(x => x != null).ToList();
                for(int index = 0; index < receiptLines.Count; index++)
                {
                    var line = receiptLines[index];
                    ModelState modelState = _validator.Validate(line);
                    if (modelState.HasErrors)
                    {
                        _ = _applicationContext.DisplayMessage("Error", $"Invalid Receipt Line At {index + 1}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                List<PurchaseRequest> purchaseRequests = new List<PurchaseRequest>();
                foreach(var line in receiptLines)
                {
                    if (line.Id == Guid.Empty)
                    {
                        line.Id = Guid.NewGuid();
                        _unitOfWork.ReceiptLineRepository.Add(line);

                    }
                    else
                    {
                        ReceiptLine oldLine = _unitOfWork.ReceiptLineRepository.Find(key: line.Id);
                        if (oldLine != null)
                        {
                            oldLine.Notes = line.Notes;
                            oldLine.ReceiptDate = line.ReceiptDate;
                            oldLine.ReceivedQuantity = line.ReceivedQuantity;
                            oldLine.Period = line.Period;
                        }
                    }
                    PurchaseRequest purchaseRequest = _unitOfWork.PurchaseRequestRepository.Find(key: line.PurchaseRequestLine.PurchaseRequestId);
                    if (!purchaseRequests.Contains(purchaseRequest))
                    {
                        purchaseRequests.Add(purchaseRequest);
                    }
                }
                foreach(var purchaseRequest in purchaseRequests)
                {
                    _ = purchaseRequest.State;
                }
                _unitOfWork.Complete();
                HasChanged = false;
                return true;
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result =
                    _applicationContext.DisplayMessage(
                        title: "Confirm Save", 
                        message: "Do You Want To Save Changes?",
                        buttons: MessageBoxButtons.YesNoCancel, 
                        icon: MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    return SaveOrUpdate();
                }
                else if(result == DialogResult.No)
                {
                    HasChanged = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public BindingList<ReceiptLineEditViewModel> Lines { get; private set; } = new BindingList<ReceiptLineEditViewModel>();
        public string this[string columnName] => _period == null ? $"No Open Period For Date {_receiptDate}" : string.Empty;
        public string Error => _period == null ? $"No Open Period For Date {_receiptDate}" : string.Empty;
    }
}
