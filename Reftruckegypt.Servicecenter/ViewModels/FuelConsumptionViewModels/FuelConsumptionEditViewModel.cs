using Npoi.Mapper;
using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels
{
    public class FuelConsumptionEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<FuelConsumption> _validator;

        private bool _hasChanged = false;

        private ModelState _modelState = new ModelState();

        private DateTime _consumptionDate;
        public FuelConsumptionEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<FuelConsumption> validator)
            : this(null, unitOfWork, applicationContext,validator)
        {
            
        }
        public FuelConsumptionEditViewModel(
            FuelConsumption line,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<FuelConsumption> validator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));

            FuelCards.AddRange(_unitOfWork.FuelCardRepository.Find(q => q.OrderBy(e => e.Number)));
            FuelTypes.AddRange(_unitOfWork.FuelTypeRepository.Find(q => q.OrderBy(x => x.Name)));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            if (line != null)
            {
                Lines.Add(new FuelConsumptionLineEditViewModel(line,_validator));
                ConsumptionDate = line.ConsumptionDate;
            }
            else
            {
                ConsumptionDate = DateTime.Now;
            }
            Lines.ListChanged += (o, e) =>
            {
                if(e.PropertyDescriptor?.Name != nameof(HasChanged))
                {
                    HasChanged = true;
                }
                if(e.ListChangedType == ListChangedType.ItemAdded && e.NewIndex >=0 && e.NewIndex < Lines.Count)
                {
                    Lines[e.NewIndex].Validator = _validator;
                    if (Vehicles.Count > 0)
                    {
                        Lines[e.NewIndex].Vehicle = Vehicles[0];
                        Lines[e.NewIndex].FuelCard = Vehicles[0].FuelCard;
                        Lines[e.NewIndex].FuelType = Vehicles[0].FuelType;
                        Lines[e.NewIndex].Period = _unitOfWork.PeriodRepository.FindOpenPeriod(_consumptionDate);
                        Lines[e.NewIndex].ConsumptionDate = _consumptionDate;
                    }
                }
            };
        }
        
        public DateTime ConsumptionDate
        {
            get => _consumptionDate;
            set
            {
                if (_consumptionDate != value)
                {
                    _consumptionDate = value;
                    ValidateDate();
                    OnPropertyChanged(this, nameof(ConsumptionDate));
                }
            }
        }
        public void Validate()
        {
            _modelState.Clear();
            ValidateDate();
            if (!_modelState.HasErrors)
            {
                foreach(var line in Lines)
                {
                    ModelState modelState = line.Validate(true);
                    if (modelState.HasErrors)
                    {
                        _modelState.AddErrors(modelState);
                        return;
                    }
                }
            }
        }
        private void ValidateDate()
        {
            Period period = _unitOfWork.PeriodRepository.FindOpenPeriod(_consumptionDate);
            _modelState.Clear(nameof(ConsumptionDate));
            if (period == null)
            {
                _modelState.AddError(nameof(ConsumptionDate), $"No Open Period For Date: {_consumptionDate}");
            }
            else
            {
                _modelState.Clear();
            }
            foreach (var line in Lines)
            {
                line.Period = period;
                line.ConsumptionDate = _consumptionDate;
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
                Validate();
                if (!_modelState.HasErrors)
                {
                    IEnumerable<FuelConsumption> lines = Lines.Select(l => l.FuelConsumption);
                    foreach(FuelConsumption line in lines)
                    {
                        if(line.Id == Guid.Empty)
                        {
                            line.Id = Guid.NewGuid();
                            _unitOfWork.FuelConsumptionRepository.Add(line);
                        }
                        else
                        {
                            FuelConsumption oldLine = _unitOfWork.FuelConsumptionRepository.Find(key: line.Id);
                            oldLine.ConsumptionDate = line.ConsumptionDate;
                            oldLine.Notes = line.Notes;
                            oldLine.FuelCard = line.FuelCard;
                            oldLine.FuelType = line.FuelType;
                            oldLine.Period = line.Period;
                            oldLine.TotalAmountInEGP = line.TotalAmountInEGP;
                            oldLine.TotalConsumedQuanityInLiteres = line.TotalConsumedQuanityInLiteres;
                            oldLine.Vehicle = line.Vehicle;
                        }
                    }
                    _ = _unitOfWork.Complete();
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
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Save", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
        public BindingList<FuelConsumptionLineEditViewModel> Lines { get; private set; } = new BindingList<FuelConsumptionLineEditViewModel>();
        public List<FuelCard> FuelCards { get; private set; } = new List<FuelCard>();
        public List<FuelType> FuelTypes { get; private set; } = new List<FuelType>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        #region IDataErrorInfo
        public string Error => _modelState.Error;
        public string this[string columnName] => _modelState[columnName];
        #endregion IDataErrorInfo
    }
}
