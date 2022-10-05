using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels
{
    public class ExternalRepairBillEditViewModel: ViewModelBase, IDataErrorInfo
    {
        private IUnitOfWork _unitOfWork;

        private IValidator<ExternalRepairBill> _validator;
        private ModelState _modelState = new ModelState();

        private string _number = "";
        private DateTime _billDate = DateTime.Now;
        private string _supplierBillNumber = "";
        private decimal _totalAmountEgp = 0;
        private string _repairs = "";
        private ExternalAutoRepairShop _externalAutoRepairShop;
        private Vehicle _vehicle;
        private Period _period = null;
        private string _billImageFilePath = "";

        private bool _hasChanged = false;
        public ExternalRepairBillEditViewModel(IUnitOfWork unitOfWork, IValidator<ExternalRepairBill> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;

            Id = Guid.Empty;

            ExternalAutoRepairShops.AddRange(_unitOfWork.ExternalAutoRepairShopRepository.Find(e => e.IsEnabled, q=>q.OrderBy(e=>e.Name)));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(e => e.InternalCode)));
            if(ExternalAutoRepairShops.Count > 0)
            {
                _externalAutoRepairShop = ExternalAutoRepairShops[0];
            }
            if(Vehicles.Count > 0)
            {
                _vehicle = Vehicles[0];
            }
            _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_billDate);
        }
        public ExternalRepairBillEditViewModel(ExternalRepairBill externalRepairBill, IUnitOfWork unitOfWork, IValidator<ExternalRepairBill> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;

            Id = externalRepairBill.Id;
            Number = externalRepairBill.Number.ToString();
            BillDate = externalRepairBill.BillDate;
            BillImageFilePath = externalRepairBill.BillImageFilePath;
            Repairs = externalRepairBill.Repairs;
            TotalAmountInEGP = externalRepairBill.TotalAmountInEGP;
            SupplierBillNumber = externalRepairBill.SupplierBillNumber;

            ExternalAutoRepairShops.AddRange(_unitOfWork.ExternalAutoRepairShopRepository.Find(e => e.IsEnabled, q => q.OrderBy(e => e.Name)));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(e => e.InternalCode)));
        }
        public Guid Id { get; private set; }
        public ExternalRepairBill ExternalRepairBill => new ExternalRepairBill()
        {
            Id = Id == Guid.Empty ? Guid.NewGuid() : Id,
            BillDate = BillDate,
            SupplierBillNumber = SupplierBillNumber,
            ExternalAutoRepairShop = ExternalAutoRepairShop,
            Vehicle = Vehicle,
            Period = _period,
            Repairs = Repairs,
            TotalAmountInEGP = TotalAmountInEGP,
            BillImageFilePath = _billImageFilePath
        };
        
        public void Validate()
        {
            _modelState.Clear();
            ExternalRepairBill externalRepairBill = ExternalRepairBill;
            _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_billDate);
            if(_period == null)
            {
                _modelState.AddError(nameof(BillDate), $"No Open Period For Date ${_billDate}");
            }
            else
            {
                externalRepairBill.Period = _period;
            }
            var modelstate = _validator.Validate(externalRepairBill);
            if (!modelstate.HasErrors)
            {
                if (!string.IsNullOrEmpty(_billImageFilePath))
                {
                    try
                    {
                        if (!System.IO.File.Exists(_billImageFilePath))
                        {
                            _modelState.AddError(nameof(BillImageFilePath), $"File {_billImageFilePath} does not exist");
                        }
                    }
                    catch (Exception ex)
                    {
                        _modelState.AddError(nameof(BillImageFilePath), ex.Message);
                    }
                }
            }
            _modelState.AddErrors(modelstate);
        }
        public string BillImageFilePath
        {
            get => _billImageFilePath;
            set
            {
                if (_billImageFilePath != value)
                {
                    _billImageFilePath = value;
                    Validate();
                    OnPropertyChanged(this, nameof(BillImageFilePath));
                    HasChanged = true;
                }
            }
        }
        public string Number
        {
            get => _number;
            private set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(this, nameof(Number));
                    
                }
            }
        }
        public DateTime BillDate
        {
            get => _billDate;
            set
            {
                if (_billDate != value)
                {
                    _billDate = value;
                    Validate();
                    OnPropertyChanged(this, nameof(BillDate));
                    HasChanged = true;
                }
            }
        }
        public string SupplierBillNumber
        {
            get => _supplierBillNumber;
            set
            {
                if (_supplierBillNumber != value)
                {
                    _supplierBillNumber = value;
                    Validate();
                    OnPropertyChanged(this, nameof(SupplierBillNumber));
                    HasChanged = true;
                }
            }
        }
        public decimal TotalAmountInEGP
        {
            get => _totalAmountEgp;
            set
            {
                if (_totalAmountEgp != value)
                {
                    _totalAmountEgp = value;
                    Validate();
                    OnPropertyChanged(this, nameof(TotalAmountInEGP));
                    HasChanged = true;
                }
            }
        }
        public string Repairs
        {
            get => _repairs;
            set
            {
                if (_repairs != value)
                {
                    _repairs = value;
                    Validate();
                    OnPropertyChanged(this, nameof(Repairs));
                    HasChanged = true;
                }
            }
        }
        public ExternalAutoRepairShop ExternalAutoRepairShop
        {
            get => _externalAutoRepairShop;
            set
            {
                if (_externalAutoRepairShop != value)
                {
                    _externalAutoRepairShop = value;
                    Validate();
                    OnPropertyChanged(this, nameof(ExternalAutoRepairShop));
                    HasChanged = true;
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
                    Validate();
                    OnPropertyChanged(this, nameof(Vehicle));
                    HasChanged = true;
                }
            }
        }
        public bool HasChanged
        {
            get => _hasChanged;
            private set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = true;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                Validate();
                if (!_modelState.HasErrors)
                {
                    if(Id == Guid.Empty)
                    {
                        var newBill = new ExternalRepairBill()
                        {
                            BillDate = _billDate,
                            ExternalAutoRepairShop = _externalAutoRepairShop,
                            Period = _period,
                            Repairs = _repairs,
                            BillImageFilePath = _billImageFilePath,
                            TotalAmountInEGP = _totalAmountEgp,
                            Vehicle = _vehicle,
                            SupplierBillNumber = _supplierBillNumber
                        };
                        _unitOfWork.ExternalRepairBillRepository.Add(newBill);
                        Number = newBill.Number.ToString();
                        _unitOfWork.Complete();
                        HasChanged = false;
                        return true;
                    }
                    else
                    {
                        var old = _unitOfWork.ExternalRepairBillRepository.Find(Id);
                        old.Repairs = _repairs;
                        old.BillDate = _billDate;
                        old.Vehicle = _vehicle;
                        old.ExternalAutoRepairShop = _externalAutoRepairShop;
                        old.Period = _period;
                        old.SupplierBillNumber = _supplierBillNumber;
                        old.BillImageFilePath = _billImageFilePath;
                        _unitOfWork.Complete();
                        HasChanged = false;
                        return true;
                    }
                }
                return false;
            }
            return true;
        }
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<ExternalAutoRepairShop> ExternalAutoRepairShops { get; private set; } = new List<ExternalAutoRepairShop>();

        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion
    }
}
