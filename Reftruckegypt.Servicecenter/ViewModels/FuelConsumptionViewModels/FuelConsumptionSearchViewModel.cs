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

namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<FuelConsumption> _validator;

        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        private bool _isDisposed = false;

        private Vehicle _vehicle;
        private DateTime? _fromDate = null;
        private DateTime? _toDate = null;
        private FuelCard _fuelCard;
        private FuelType _fuelType;
        private VehicleCategory _vehicleCategory;
        private VehicleModel _vehicleModel;
        public FuelConsumptionSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<FuelConsumption> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(orderBy: q => q.OrderBy(f => f.Name)));
            FuelTypes.Insert(0, new FuelType() { Id = Guid.Empty, Name = "--ALL--" });
            _fuelType = FuelTypes[0];
            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(orderBy: q=>q.OrderBy(c=>c.Number)));
            FuelCards.Insert(0, new FuelCard() { Id = Guid.Empty, Number = "--ALL--" });
            _fuelCard = FuelCards[0];
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(v => v.InternalCode)));
            Vehicles.Insert(0, new Vehicle() { Id = Guid.Empty, InternalCode = "--ALL--" });
            _vehicle = Vehicles[0];
            VehicleCategories.AddRange(_unitOfWork.VehicleCategoryRepository.Find(orderBy: q=>q.OrderBy(e=>e.Name)));
            VehicleCategories.Insert(0, new VehicleCategory() { Id = Guid.Empty, Name = "--ALL--" });
            _vehicleCategory = VehicleCategories[0];
            VehicleModels.AddRange(_unitOfWork.VehicleModelRepository.Find(orderBy: q => q.OrderBy(m => m.Name)));
            VehicleModels.Insert(0, new VehicleModel() { Id = Guid.Empty, Name = "--ALL--" });
            _vehicleModel = VehicleModels[0];
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    IsDeleteEnabled = CanDeleteSelectedRecord();
                    IsEditEnabled = CanEditSelectedRecord();
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

        public Task<string> ImportFromExcelFile(Mapper mapper, IProgress<int> progress)
        {
            return Task.Run<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                IList<FuelConsumptionDTO> consumptions = mapper.Take<FuelConsumptionDTO>().Select(r => r.Value).ToList();
                List<FuelConsumption> data = new List<FuelConsumption>();
                for(int index = 0; index < consumptions.Count(); index++)
                {
                    FuelConsumptionDTO consumption = consumptions[index];
                    FuelConsumption fuelConsumption = new FuelConsumption();
                    fuelConsumption.ConsumptionDate = consumption.FuelConsumptionDate;
                    fuelConsumption.Notes = "";
                    consumption.AmountConsumed = consumption.AmountConsumed.Replace(',', '.');
                    consumption.QuantityConsumed = consumption.QuantityConsumed.Replace(',', '.');
                    string strAmount = new string(consumption.AmountConsumed.Where(x=> char.IsDigit(x) || x == '.').ToArray());
                    string strQuantity = new string(consumption.QuantityConsumed.Where(x => char.IsDigit(x) || x == '.').ToArray());
                    if (!string.IsNullOrEmpty(strAmount))
                    {
                        fuelConsumption.TotalAmountInEGP = decimal.Parse(strAmount);
                        if (!string.IsNullOrEmpty(strQuantity))
                        {
                            fuelConsumption.TotalConsumedQuanityInLiteres = decimal.Parse(strQuantity);
                            FuelCard fuelCard =
                                _unitOfWork
                            .FuelCardRepository
                            .Find(x => x.Number.Equals(consumption.FuelCardNumber))
                            .FirstOrDefault();
                            if (fuelCard != null)
                            {
                                fuelConsumption.FuelCard = fuelCard;
                                fuelConsumption.Vehicle = fuelCard.Vehicle;
                                fuelConsumption.FuelType = fuelCard.Vehicle.FuelType;
                                fuelConsumption.Period = _unitOfWork.PeriodRepository.FindOpenPeriod(fuelConsumption.ConsumptionDate);
                                ModelState modelState = _validator.Validate(fuelConsumption);
                                if (modelState.HasErrors)
                                {
                                    _ = stringBuilder.Append(modelState.Error);
                                }
                                else
                                {
                                    data.Add(fuelConsumption);
                                }
                            }
                            else
                            {
                                _ = stringBuilder.AppendLine($"Invalid Fuel Card Number: {consumption.FuelCardNumber} At Row # {index + 2}");
                            }
                        }
                        else
                        {
                            _ = stringBuilder.AppendLine($"Invalid Quantity At Row # {index + 2}");
                        }
                    }
                    else
                    {
                        _ = stringBuilder.AppendLine($"Invalid Amount At Row # {index+2}");
                    }
                    progress.Report((int)(index / consumptions.Count * 100.0));
                }
                progress.Report(50);
                _unitOfWork.FuelConsumptionRepository.Add(data);
                _unitOfWork.Complete();
                progress.Report(100);
                return stringBuilder.ToString();
            });
        }
        public ModelState Validate(FuelConsumption fuelConsumption)
        {
            ModelState modelState = new ModelState();
            fuelConsumption.Period = _unitOfWork.PeriodRepository.FindOpenPeriod(fuelConsumption.ConsumptionDate);
            modelState.AddErrors(_validator.Validate(fuelConsumption));
            return modelState;

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
        private bool CanDeleteSelectedRecord()
        {
            if(_selectedIndex>=0 && _selectedIndex < FuelConsumptions.Count)
            {
                return FuelConsumptions[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        private bool CanEditSelectedRecord()
        {
            if (_selectedIndex >= 0 && _selectedIndex < FuelConsumptions.Count)
            {
                return FuelConsumptions[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        public void Search()
        {
            FuelConsumptions.Clear();
            IEnumerable<FuelConsumption> consumptions =
                _unitOfWork
                .FuelConsumptionRepository
                .Find(
                    categoryId: _vehicleCategory.Id, 
                    modelId: _vehicleModel.Id,
                    vehicleId: _vehicle.Id,
                    fuelCardId: _fuelCard.Id,
                    fuelTypeId: _fuelType.Id,
                    fromDate: _fromDate,
                    toDate: _toDate,
                    orderBy: q=>q.OrderBy(x=>x.ConsumptionDate).ThenBy(x=>x.Vehicle.InternalCode));
            foreach(var consumption in consumptions)
            {
                FuelConsumptions.Add(new FuelConsumptionViewModel(consumption));
            }
        }
        public IList<FuelConsumptionSummaryDTO> GenerateFuelConsumptionReportData(DateTime fromDate, DateTime toDate)
        {
            var result = _unitOfWork.FuelConsumptionRepository.FindFuelConsumptionsGroupedByFuelcard(fromDate, toDate);
            return 
                result.Select(g => 
                new FuelConsumptionSummaryDTO()
                {
                    AmountConsumed = g.Sum(x=>x.TotalAmountInEGP),
                    QuantityConsumed = g.Sum(x=>x.TotalConsumedQuanityInLiteres),
                    CardNumber = g.Key.Number,
                    CardName = g.Key.Name,
                    Registration = g.Key.Registration,
                    VehicleInternalCode = g.Key.Vehicle.InternalCode,
                    VehicleCategory = g.Key.Vehicle.VehicleCategory.Name,
                    FuelTypeName = g.Key.Vehicle.FuelType.Name,
                    StartKilometerReading = _unitOfWork.VehicleKilometerReadingRepository.Find(x=>x.VehicleId == g.Key.Vehicle.Id && x.ReadingDate <= fromDate, q=>q.OrderByDescending(x=>x.ReadingDate)).FirstOrDefault()?.Reading ?? 0,
                    EndKilometerReading = _unitOfWork.VehicleKilometerReadingRepository.Find(x=>x.VehicleId == g.Key.Vehicle.Id && x.ReadingDate <= toDate, q=>q.OrderByDescending(x=>x.ReadingDate)).FirstOrDefault()?.Reading ?? 0
                })
                .ToList();
        }
        public VehicleCategory VehicleCategory
        {
            get => _vehicleCategory;
            set
            {
                if (_vehicleCategory != value)
                {
                    _vehicleCategory = value;
                    OnPropertyChanged(this, nameof(VehicleCategory));
                }
            }
        }
        public VehicleModel VehicleModel
        {
            get => _vehicleModel;
            set
            {
                if (_vehicleModel != value)
                {
                    _vehicleModel = value;
                    OnPropertyChanged(this, nameof(VehicleModel));
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
        public FuelCard FuelCard
        {
            get => _fuelCard;
            set
            {
                if (_fuelCard != value)
                {
                    _fuelCard = value;
                    OnPropertyChanged(this, nameof(FuelCard));
                }
            }
        }
        public FuelType FuelType
        {
            get => _fuelType;
            set
            {
                if (_fuelType != value)
                {
                    _fuelType = value;
                    OnPropertyChanged(this, nameof(FuelType));
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
        public BindingList<FuelConsumptionViewModel> FuelConsumptions { get; private set; } = new BindingList<FuelConsumptionViewModel>();
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<FuelCard> FuelCards { get; private set; } = new List<FuelCard>();
        public List<VehicleCategory> VehicleCategories { get; private set; } = new List<VehicleCategory>();
        public List<VehicleModel> VehicleModels { get; private set; } = new List<VehicleModel>();

        public void Delete()
        {
            if(_selectedIndex>=0 && _selectedIndex < FuelConsumptions.Count)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Fuel Consumption of Vehicle {FuelConsumptions[_selectedIndex].VehicleInternalCode}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    FuelConsumption fuelConsumption = _unitOfWork.FuelConsumptionRepository.Find(key: FuelConsumptions[_selectedIndex].Id);
                    if (fuelConsumption != null)
                    {
                        _unitOfWork.FuelConsumptionRepository.Remove(fuelConsumption);
                        _unitOfWork.Complete();
                        Search();
                    }
                    else
                    {
                        //_ = _applicationContext.DisplayMessage("Error", $"This Record has been deleted and no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Search();
                    }
                }
            }
        }

        public void Edit()
        {
            if(_selectedIndex >= 0 && _selectedIndex < FuelConsumptions.Count)
            {
                FuelConsumption line = _unitOfWork.FuelConsumptionRepository.Find(key: FuelConsumptions[_selectedIndex].Id);
                if (line != null)
                {
                    _applicationContext.DisplayFuelConsumptionEditView(new FuelConsumptionEditViewModel(line, _unitOfWork, _applicationContext,_validator));
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", "The Selected Record Has been deleted and no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }

        public void Create()
        {
            FuelConsumptionEditViewModel fuelConsumptionEditViewModel = new FuelConsumptionEditViewModel(_unitOfWork, _applicationContext,_validator);
            _applicationContext.DisplayFuelConsumptionEditView(fuelConsumptionEditViewModel: fuelConsumptionEditViewModel);
        }
        #region IDisposable
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }

        public void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, FuelConsumptions);
        }
        #endregion IDisposable
    }
}
