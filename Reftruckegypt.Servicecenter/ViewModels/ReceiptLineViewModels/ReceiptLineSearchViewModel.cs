using Npoi.Mapper;
using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels
{
    public class ReceiptLineSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<ReceiptLine> _validator;

        private DateTime? _fromDate;
        private DateTime? _toDate;
        private Vehicle _vehicle;
        private PurchaseRequest _purchaseRequest;

        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;
        public ReceiptLineSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<ReceiptLine> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            Vehicles.Insert(0, Vehicle.Empty);
            _vehicle = Vehicles[0];
            PurchaseRequests.AddRange(_unitOfWork.PurchaseRequestRepository.Find(q=>q.OrderBy(x=>x.Number)));
            PurchaseRequests.Insert(0, PurchaseRequest.empty);
            _purchaseRequest = PurchaseRequests[0];


        }
        private bool CanEditSelectedLine()
        {
            if(_selectedIndex >= 0 && _selectedIndex < ReceiptLines.Count)
            {
                return ReceiptLines[_selectedIndex].PeriodState == PeriodStates.OpenState;
            }
            return false;
        }
        private bool CanDeleteSelectedLine()
        {
            if (_selectedIndex >= 0 && _selectedIndex < ReceiptLines.Count)
            {
                return ReceiptLines[_selectedIndex].PeriodState == PeriodStates.OpenState;
            }
            return false;
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    IsEditEnabled = CanEditSelectedLine();
                    IsDeleteEnabled = CanDeleteSelectedLine();
                }
            }
        }
        public bool IsEditEnabled
        {
            get => _isEditEnabled;
            private set
            {
                if (_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
            }
        }
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            private set
            {
                if (_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        public DateTime? FromDate
        {
            get=>_fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged(this, nameof(FromDate));
                }
            }
        }
        public DateTime? ToDate
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged(this, nameof(ToDate));
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
                }
            }
        }
        public PurchaseRequest PurchaseRequest
        {
            get => _purchaseRequest;
            set
            {
                if (_purchaseRequest != value) 
                { 
                    _purchaseRequest = value;
                    OnPropertyChanged(this, nameof(PurchaseRequest));
                }
            }
        }
        public void Search()
        {
            ReceiptLines.Clear();
            IEnumerable<ReceiptLine> receiptLines =
                _unitOfWork.ReceiptLineRepository.Find(
                    purchaseRequestId: _purchaseRequest?.Id,
                    vehicleId: _vehicle?.Id,
                    fromDate: _fromDate,
                    toDate: _toDate,
                    orderBy: q => q.OrderByDescending(x => x.ReceiptDate));
            foreach(ReceiptLine receiptLine in receiptLines)
            {
                ReceiptLines.Add(new ReceiptLineDTO(receiptLine));
            }
        }
        public void Create()
        {
            IEnumerable<PurchaseRequestSelectorViewModel> purchases =
                _unitOfWork
                .PurchaseRequestRepository
                .Find(x => x.State != PurchaseRequestStates.FullyReceived, q => q.OrderBy(x => x.Number))
                .Select(x => new PurchaseRequestSelectorViewModel(x));
            IList<Guid> selectedRequests = _applicationContext.DisplayPurchaseRequestsSelectionView(purchases);
            
            if(selectedRequests.Count > 0)
            {
                IEnumerable<PurchaseRequestLine> purchaseRequestLines = 
                    _unitOfWork
                    .PurchaseRequestLineRepository
                    .Find(
                        x => selectedRequests.Contains(x.PurchaseRequestId) && 
                        x.PurchaseRequest.State != PurchaseRequestStates.FullyReceived && 
                        (x.ReceiptLines.Count() == 0 || x.RequestedQuantity > x.ReceiptLines.Sum(z=>z.ReceivedQuantity)));
                ReceiptEditViewModel editModel = new ReceiptEditViewModel(purchaseRequestLines, _unitOfWork, _applicationContext, _validator);
                _applicationContext.DisplayReceiptEditView(editModel);
            }
        }

        public void ExportToExcel(string fileName)
        {
            
                Mapper mapper = new Mapper();
                mapper.Save(fileName, ReceiptLines.ToList());
                

        }

        public BindingList<ReceiptLineDTO> ReceiptLines { get; private set; } = new BindingList<ReceiptLineDTO>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<PurchaseRequest> PurchaseRequests { get; private set; } = new List<PurchaseRequest>();
        private bool _isDisposed = false;
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
    }
}
