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

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels
{
    public class ExternalRepairBillSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<ExternalRepairBill> _validator;

        private int _selectedIndex = -1;
        private bool _canEditOrDeleteBill = false;

        private long? _numberFrom = null;
        private long? _numberTo = null;
        private string _supplierBillNumber = "";
        private DateTime? _fromDate = null;
        private DateTime? _toDate = null;
        private decimal? _fromAmount = null;
        private decimal? _toAmount = null;
        private ExternalAutoRepairShop _externalAutoRepairShop = null;
        private Vehicle _vehicle = null;

        public ExternalRepairBillSearchViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext, 
            IValidator<ExternalRepairBill> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;
            ExternalAutoRepairShops.AddRange(_unitOfWork.ExternalAutoRepairShopRepository.Find().ToList());
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q=>q.OrderBy(x=>x.InternalCode)).ToList());
            ExternalAutoRepairShops.Insert(0, new ExternalAutoRepairShop()
            {
                Id = Guid.Empty,
                Name = "--ALL--"
            });
            _externalAutoRepairShop = ExternalAutoRepairShops[0];
            Vehicles.Insert(0, new Vehicle()
            {
                Id = Guid.Empty,
                InternalCode = "--ALL--"
            });
            _vehicle = Vehicles[0];
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    CanEditOrDeleteBill = IsBillPeriodOpened(_selectedIndex);
                }
            }
        }
        public bool CanEditOrDeleteBill
        {
            get => _canEditOrDeleteBill;
            set
            {
                if(_canEditOrDeleteBill != value)
                {
                    _canEditOrDeleteBill = value;
                    OnPropertyChanged(this, nameof(CanEditOrDeleteBill));
                }
            }
        }
        private bool IsBillPeriodOpened(int index)
        {
            if(index >=0 && index < ExternalRepairBillVieModels.Count)
            {
                return _unitOfWork.PeriodRepository.Find(key: ExternalRepairBillVieModels[index].PeriodId)?.State == PeriodStates.OpenState;
            }
            return false;
        }
        public long? NumberFrom
        {
            get => _numberFrom;
            set
            {
                if(_numberFrom != value)
                {
                    _numberFrom = value;
                    OnPropertyChanged(this, nameof(NumberFrom));
                }
            }
        }
        public long? NumberTo
        {
            get => _numberTo;
            set
            {
                if (_numberTo != value)
                {
                    _numberTo = value;
                    OnPropertyChanged(this, nameof(NumberTo));
                }
            }
        }
        public ModelState Validate(ExternalRepairBill bill)
        {
            bill.Period = _unitOfWork.PeriodRepository.FindOpenPeriod(bill.BillDate);
            return _validator.Validate(bill);
        }
        public Task<string> ImportFromExcelFile(Mapper mapper, IProgress<int> progress)
        {
            return Task.Run<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                IList<ExternalRepairBillViewModel> externalBillsViewModel = mapper.Take<ExternalRepairBillViewModel>().Select(r => r.Value).ToList();
                List<ExternalRepairBill> data = new List<ExternalRepairBill>();
                for(int index=0;index< externalBillsViewModel.Count; index++)
                {
                    ExternalRepairBillViewModel viewModel = externalBillsViewModel[index];
                    if (!string.IsNullOrEmpty(viewModel.VehicleInternalCode))
                    {
                        Vehicle vehicle = _unitOfWork.VehicleRepository.Find(x=>x.InternalCode.Equals(viewModel.VehicleInternalCode)).FirstOrDefault();
                        if(vehicle != null)
                        {
                            ExternalAutoRepairShop shop = _unitOfWork.ExternalAutoRepairShopRepository.Find(x=>x.Name.Equals(viewModel.ExternalAutoRepairShopName)).FirstOrDefault();
                            if (shop != null)
                            {
                                var bill = new ExternalRepairBill()
                                {
                                    BillDate = viewModel.BillDate,
                                    ExternalAutoRepairShop = shop,
                                    Repairs = viewModel.Repairs,
                                    SupplierBillNumber = viewModel.SupplierBillNumber,
                                    TotalAmountInEGP = viewModel.TotalAmount,
                                    Vehicle = vehicle
                                };
                                ModelState modelState = Validate(bill);
                                if (!modelState.HasErrors)
                                    data.Add(bill);
                                else
                                    stringBuilder.AppendLine(modelState.Error);
                            }
                            else
                            {
                                stringBuilder.AppendLine($"Invalid External Repair Shop Name {viewModel.ExternalAutoRepairShopName} At Row {index + 2}");
                            }
                        }
                        else
                        {
                            stringBuilder.AppendLine($"Invalid Vehicle Code {viewModel.VehicleInternalCode} At Row {index + 2}");
                        }
                    }
                    else
                    {
                        stringBuilder.AppendLine($"Invalid Vehicle Code At Row {index + 2}");
                    }
                    progress.Report((int)(index / externalBillsViewModel.Count * 100.0));
                }
                progress.Report(50);
                _unitOfWork.ExternalRepairBillRepository.Add(data);
                _unitOfWork.Complete();
                return stringBuilder.ToString();
            });
        }

        public string SupplierBillNumber
        {
            get => _supplierBillNumber;
            set
            {
                if (_supplierBillNumber != value)
                {
                    _supplierBillNumber = value;
                    OnPropertyChanged(this, nameof(_supplierBillNumber));
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
        public decimal? FromAmount
        {
            get => _fromAmount;
            set
            {
                if (_fromAmount != value)
                {
                    _fromAmount = value;
                    OnPropertyChanged(this, nameof(FromAmount));
                }
            }
        }
        public decimal? ToAmount
        {
            get => _toAmount;
            set
            {
                if (_toAmount != value)
                {
                    _toAmount = value;
                    OnPropertyChanged(this, nameof(ToAmount));
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
        public void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, ExternalRepairBillVieModels);
        }
        public void Search()
        {
            ExternalRepairBillVieModels.Clear();
            var bills =
                _unitOfWork.ExternalRepairBillRepository.Find((bill) => new ExternalRepairBillViewModel()
                {
                    Id = bill.Id,
                    Number = bill.Number,
                    BillDate = bill.BillDate,
                    SupplierBillNumber = bill.SupplierBillNumber,
                    ExternalAutoRepairShopName = bill.ExternalAutoRepairShop.Name,
                    VehicleInternalCode = bill.Vehicle.InternalCode,
                    Repairs = bill.Repairs,
                    State = bill.Period.State,
                    TotalAmount = bill.TotalAmountInEGP
                },
                _numberFrom,
                _numberTo,
                _supplierBillNumber,
                _fromDate,
                _toDate,
                _fromAmount,
                _toAmount,
                _externalAutoRepairShop.Id,
                _vehicle.Id,
                q => q.OrderBy(b => b.BillDate)
            );
            foreach(var bill in bills)
            {
                ExternalRepairBillVieModels.Add(bill);
            }

        }
        public void Create()
        {
            ExternalRepairBillEditViewModel editViewModel = new ExternalRepairBillEditViewModel(_unitOfWork, _applicationContext,_validator);
            _applicationContext.DisplayExternalRepaiBillEditView(editViewModel);
            Search();
        }
        public void Delete()
        {
            if(_selectedIndex >=0 && _selectedIndex < ExternalRepairBillVieModels.Count)
            {
                var bill = _unitOfWork.ExternalRepairBillRepository.Find(ExternalRepairBillVieModels[_selectedIndex].Id);
                if (bill != null)
                {
                    var result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Bill# {bill.Number}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        _unitOfWork.ExternalRepairBillRepository.Remove(bill);
                        _unitOfWork.Complete();
                        Search();
                    }
                }
                else
                {
                    _applicationContext.DisplayMessage("Error", $"External Bill With Number ${ExternalRepairBillVieModels[_selectedIndex].Number} is no longer exist\npleas click search button to reload the data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Edit()
        {
            if (_selectedIndex >= 0 && _selectedIndex < ExternalRepairBillVieModels.Count)
            {
                var oldBill = _unitOfWork.ExternalRepairBillRepository.Find(ExternalRepairBillVieModels[_selectedIndex].Id);
                if (oldBill != null)
                {
                    _applicationContext.DisplayExternalRepaiBillEditView(new ExternalRepairBillEditViewModel(oldBill, _unitOfWork, _applicationContext,_validator));
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"External Bill With Number ${ExternalRepairBillVieModels[_selectedIndex].Number} is no longer exist\npleas click search button to reload the data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public BindingList<ExternalRepairBillViewModel> ExternalRepairBillVieModels { get; private set; } = new BindingList<ExternalRepairBillViewModel>();
        public List<ExternalAutoRepairShop> ExternalAutoRepairShops { get; private set; } = new List<ExternalAutoRepairShop>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        #region IDisposable
        private bool _isDisposed = false;
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
        #endregion
    }
}
