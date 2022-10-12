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

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels
{
    public class ExternalRepairBillEditViewModel: ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ExternalRepairBill> _validator;
        private readonly IApplicationContext _applicationContext;

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
        public ExternalRepairBillEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<ExternalRepairBill> validator)
            : this(null, unitOfWork, applicationContext, validator)
        {
            
        }
        public ExternalRepairBillEditViewModel(
            ExternalRepairBill externalRepairBill, 
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext,
            IValidator<ExternalRepairBill> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            ExternalAutoRepairShops.AddRange(_unitOfWork.ExternalAutoRepairShopRepository.Find(e => e.IsEnabled, q => q.OrderBy(e => e.Name)));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(e => e.InternalCode)));

            if (externalRepairBill != null)
            {
                Id = externalRepairBill.Id;
                _number = externalRepairBill.Number.ToString();
                _billDate = externalRepairBill.BillDate;
                _period = externalRepairBill.Period;
                _billImageFilePath = externalRepairBill.BillImageFilePath;
                _repairs = externalRepairBill.Repairs;
                _totalAmountEgp = externalRepairBill.TotalAmountInEGP;
                _supplierBillNumber = externalRepairBill.SupplierBillNumber;
                if (!Vehicles.Contains(externalRepairBill.Vehicle))
                {
                    Vehicles.Add(externalRepairBill.Vehicle);
                }
                if (!ExternalAutoRepairShops.Contains(externalRepairBill.ExternalAutoRepairShop))
                {
                    ExternalAutoRepairShops.Add(externalRepairBill.ExternalAutoRepairShop);
                }
                _vehicle = externalRepairBill.Vehicle;
                _externalAutoRepairShop = externalRepairBill.ExternalAutoRepairShop;
                
            }
            else
            {
                Id = Guid.Empty;
                if (ExternalAutoRepairShops.Count > 0)
                {
                    _externalAutoRepairShop = ExternalAutoRepairShops[0];
                }
                if (Vehicles.Count > 0)
                {
                    _vehicle = Vehicles[0];
                }
                _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_billDate);
            }
            
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
            Repairs = _repairs,
            TotalAmountInEGP = _totalAmountEgp,
            BillImageFilePath = _billImageFilePath
        };
        
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            _period = _unitOfWork.PeriodRepository.FindOpenPeriod(_billDate);
            if (_period == null)
            {
                modelState.AddError(nameof(BillDate), $"No Open Period For Date ${_billDate}");
            }
            if (!modelState.HasErrors)
            {
                ExternalRepairBill externalRepairBill = ExternalRepairBill;
                modelState.AddErrors(_validator.Validate(externalRepairBill));
                if (!modelState.HasErrors)
                {
                    if (!string.IsNullOrEmpty(_billImageFilePath))
                    {
                        try
                        {
                            if (System.IO.Path.GetExtension(_billImageFilePath).ToLower() == ".jpg" || System.IO.Path.GetExtension(_billImageFilePath).ToLower() == ".jpeg")
                            {
                                if (!System.IO.File.Exists(_billImageFilePath))
                                {
                                    modelState.AddError(nameof(BillImageFilePath), $"File {_billImageFilePath} does not exist");
                                }
                            }
                            else
                            {
                                modelState.AddError(nameof(BillImageFilePath), $"File {_billImageFilePath} Is Not a Valid Image.");
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            modelState.AddError(nameof(BillImageFilePath), ex.Message);
                        }
                    }
                }
            }
            return modelState;
        }
        public string BillImageFilePath
        {
            get => _billImageFilePath;
            set
            {
                if (_billImageFilePath != value)
                {
                    _billImageFilePath = value;
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
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                ModelState modelState = Validate();
                if (!modelState.HasErrors)
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
                        _unitOfWork.Complete();
                        Number = newBill.Number.ToString();
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
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confirm save",
                    message: "Do You Want To Save Changes?",
                    buttons: MessageBoxButtons.YesNoCancel,
                    icon: MessageBoxIcon.Question
                    );
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
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<ExternalAutoRepairShop> ExternalAutoRepairShops { get; private set; } = new List<ExternalAutoRepairShop>();

        #region IDataErrorInfo
        public string Error => Validate().Error;
        public string this[string columnName] => Validate()[columnName];
        #endregion
    }
}
