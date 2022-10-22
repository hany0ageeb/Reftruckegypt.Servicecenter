using Npoi.Mapper;
using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels
{
    public class PurchaseRequestSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<PurchaseRequest> _purchaseRequestValidator;
        private readonly IValidator<PurchaseRequestLine> _purchaseRequestLineValidator;

        private bool _isDisposed = false;

        private DateTime? _fromDate;
        private DateTime? _toDate;
        private Vehicle _vehicle;
        private SparePart _sparePart;

        private bool _displayByHeader = true;
        private bool _displayByLine = false;

        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        public PurchaseRequestSearchViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext,
            IValidator<PurchaseRequest> purchaseRequestValidator,
            IValidator<PurchaseRequestLine> purchaseRequestLineValidator
            )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _purchaseRequestValidator = purchaseRequestValidator ?? throw new ArgumentNullException(nameof(purchaseRequestValidator));
            _purchaseRequestLineValidator = purchaseRequestLineValidator ?? throw new ArgumentNullException(nameof(purchaseRequestLineValidator));

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q=>q.OrderBy(x=>x.InternalCode)));
            Vehicles.Insert(0, Vehicle.Empty);
            _vehicle = Vehicles[0];

            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(q => q.OrderBy(x => x.Code)));
            SpareParts.Insert(0, SparePart.empty);
            _sparePart = SpareParts[0];
        }
        private bool CanEditSelectedRecord()
        {
            if (_displayByHeader)
            {
                if(_selectedIndex >= 0 && _selectedIndex < PurchaseRequests.Count)
                {
                    return 
                        PurchaseRequests[_selectedIndex].PeriodState == PeriodStates.OpenState && 
                        PurchaseRequests[_selectedIndex].RequestState == PurchaseRequestStates.Approved;
                }
                return false;
            }
            else if (_displayByLine)
            {
                if (_selectedIndex >= 0 && _selectedIndex < PurchaseRequestLines.Count)
                {
                    return
                        PurchaseRequestLines[_selectedIndex].PeriodState == PeriodStates.OpenState &&
                        PurchaseRequestLines[_selectedIndex].RequestState == PurchaseRequestStates.Approved;

                }
                return false;
            }
            return false;
        }
        private bool CanDeleteSelectedRecord()
        {
            if (_displayByHeader)
            {
                if (_selectedIndex >= 0 && _selectedIndex < PurchaseRequests.Count)
                {
                    return 
                        PurchaseRequests[_selectedIndex].PeriodState == PeriodStates.OpenState &&
                        PurchaseRequests[_selectedIndex].RequestState == PurchaseRequestStates.Approved;
                }
                return false;
            }
            else if (_displayByLine)
            {
                if (_selectedIndex >= 0 && _selectedIndex < PurchaseRequestLines.Count)
                {
                    return 
                        PurchaseRequestLines[_selectedIndex].PeriodState == PeriodStates.OpenState &&
                        PurchaseRequestLines[_selectedIndex].RequestState == PurchaseRequestStates.Approved;
                }
                return false;
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
                    IsEditEnabled = CanEditSelectedRecord();
                    IsDeleteEnabled = CanDeleteSelectedRecord();
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
            get => _fromDate;
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
        public SparePart SparePart
        {
            get => _sparePart;
            set
            {
                if (_sparePart != value)
                {
                    _sparePart = value;
                    OnPropertyChanged(this, nameof(SparePart));
                }
            }
        }
        public bool DisplayResultByHeader 
        {
            get => _displayByHeader;
            set
            {
                if (_displayByHeader != value)
                {
                    _displayByHeader = value;
                    OnPropertyChanged(this, nameof(DisplayResultByHeader));
                    DisplayResultByLine = !_displayByHeader;
                }
            }
        }

        public Task ExportToExcelAsync(string fileName)
        {
            return Task.Run(() =>
            {
                Mapper mapper = new Mapper();
                if (_displayByHeader && PurchaseRequests.Count > 0)
                {
                    mapper.Save(fileName, PurchaseRequests.ToList());
                }
                else if(_displayByLine && PurchaseRequestLines.Count > 0)
                {
                    mapper.Save(fileName, PurchaseRequestLines.ToList());
                }
               
            });
        }

        public bool DisplayResultByLine 
        {
            get => _displayByLine;
            set
            {
                if (_displayByLine != value)
                {
                    _displayByLine = value;
                    OnPropertyChanged(this, nameof(DisplayResultByLine));
                    DisplayResultByHeader = !_displayByLine;
                }
            } 
        }
        public void Search()
        {
            PurchaseRequests.Clear();
            PurchaseRequestLines.Clear();
            if (_displayByHeader)
            {
                IEnumerable<PurchaseRequest> purchaseRequests = _unitOfWork
                    .PurchaseRequestRepository
                    .Find(vehicleId: _vehicle?.Id,
                          fromDate: _fromDate,
                          toDate: _toDate,
                          orderBy: q => q.OrderByDescending(x => x.RequestDate));
                foreach(var purchaseRequest in purchaseRequests)
                {
                    PurchaseRequests.Add(new PurchaseRequestDTO(purchaseRequest));
                }
            }
            else
            {
                IEnumerable<PurchaseRequestLine> purchaseRequestLines =
                    _unitOfWork
                    .PurchaseRequestLineRepository
                    .Find(_vehicle?.Id,
                          _sparePart?.Id,
                          _fromDate,
                          _toDate,
                          q => q.OrderByDescending(x => x.PurchaseRequest.RequestDate).ThenBy(x => x.SparePart.Code))
                    .ToList();
                foreach(var line in purchaseRequestLines)
                {
                    PurchaseRequestLines.Add(new PurchaseRequestLineDTO(line));
                }
            }
        }
        public void Create()
        {
            PurchaseRequestEditViewModel editModel = new PurchaseRequestEditViewModel(_unitOfWork, _applicationContext,_purchaseRequestValidator,_purchaseRequestLineValidator);
            _applicationContext.DisplayPurchaseRequestEditView(editModel);
          
        }
        public void Edit()
        {
            if (_displayByHeader)
            {
                if (_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < PurchaseRequests.Count)
                {
                    PurchaseRequest oldRequest = _unitOfWork.PurchaseRequestRepository.Find(key: PurchaseRequests[_selectedIndex].PurchaseRequestId);
                    if (oldRequest != null)
                    {
                        PurchaseRequestEditViewModel editModel = new PurchaseRequestEditViewModel(oldRequest,_unitOfWork, _applicationContext, _purchaseRequestValidator, _purchaseRequestLineValidator);
                        _applicationContext.DisplayPurchaseRequestEditView(editModel);
                        Search();
                    }
                    else
                    {
                        _applicationContext.DisplayMessage("Error", $"Purchase Request {PurchaseRequests[_selectedIndex].Number} has been deleted and no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Search();
                    }
                }
            }
            else
            {

            }
        }
        public void Delete()
        {
            if (_displayByHeader)
            {
                if (_isDeleteEnabled && _selectedIndex >= 0 && _selectedIndex < PurchaseRequests.Count)
                {
                    DialogResult result =
                        _applicationContext.DisplayMessage(
                            title: "Confirm Delete",
                            message: $"Are You Sure You Want To Delete Purchase Request# {PurchaseRequests[_selectedIndex].Number}?",
                            buttons: MessageBoxButtons.YesNo,
                            icon: MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        PurchaseRequest old = 
                            _unitOfWork.PurchaseRequestRepository.Find(key: PurchaseRequests[_selectedIndex].PurchaseRequestId);
                        if (old != null)
                        {
                            _unitOfWork.PurchaseRequestRepository.Remove(old);
                            _ = _unitOfWork.Complete();
                        }
                        Search();
                    }
                }
                
            }
            else
            {
                if (_isDeleteEnabled && _selectedIndex >= 0 && _selectedIndex < PurchaseRequestLines.Count)
                {

                }
            }
            
        }
        public BindingList<PurchaseRequestDTO> PurchaseRequests { get; private set; } = new BindingList<PurchaseRequestDTO>();
        public BindingList<PurchaseRequestLineDTO> PurchaseRequestLines { get; private set; } = new BindingList<PurchaseRequestLineDTO>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
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
