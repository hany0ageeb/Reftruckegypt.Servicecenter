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

namespace Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels
{
    public class PeriodSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Period> _validator;

        #region IDisposable
        private bool _isDisposed = false;
        #endregion
        private int _selectedIndex = -1;
        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = false;

        private string _name = "";
        private DateTime? _date = null;

        public PeriodSearchViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<Period> validator)
        {
            _validator = validator;
            _applicationContext = applicationContext;
            _unitOfWork = unitOfWork;
        }
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(this, nameof(Name));
                }
            }
        }
        public DateTime? Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(this, nameof(Date));
                }
            }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    IsDeleteEnabled = CanSelectedPeriodBeDeleted();
                    IsEditEnabled = CanEditSelectedPeriod();
                    OnPropertyChanged(this, nameof(SelectedIndex));
                }
            }
        }
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            set
            {
                if (_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        public bool IsEditEnabled
        {
            get => _isEditEnabled;
            set
            {
                if (_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
            }
        }
        private bool CanSelectedPeriodBeDeleted()
        {
            if(_selectedIndex >= 0 && SelectedIndex < Periods.Count)
            {
                Guid currentPeriodId = Periods[_selectedIndex].Id;
                if (
                    _unitOfWork.ExternalRepairBillRepository.Exists(e => e.PeriodId == currentPeriodId) || 
                    _unitOfWork.FuelConsumptionRepository.Exists(e => e.PeriodId == currentPeriodId) ||
                    _unitOfWork.SparePartsBillRepository.Exists(e=>e.PeriodId == currentPeriodId) ||
                    _unitOfWork.SparePartsPriceListRepository.Exists(e=>e.Period.Id == currentPeriodId) ||
                    _unitOfWork.VehicleKilometerReadingRepository.Exists(e=>e.PeriodId == currentPeriodId) ||
                    _unitOfWork.VehicleViolationRepository.Exists(e=>e.PeriodId == currentPeriodId))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        private bool CanEditSelectedPeriod()
        {
            if (_selectedIndex >= 0 && _selectedIndex < Periods.Count)
            {
                Guid currentPeriodId = Periods[_selectedIndex].Id;
                if (
                    _unitOfWork.ExternalRepairBillRepository.Exists(e => e.PeriodId == currentPeriodId) ||
                    _unitOfWork.FuelConsumptionRepository.Exists(e => e.PeriodId == currentPeriodId) ||
                    _unitOfWork.SparePartsBillRepository.Exists(e => e.PeriodId == currentPeriodId) ||
                    _unitOfWork.SparePartsPriceListRepository.Exists(e => e.Period.Id == currentPeriodId) ||
                    _unitOfWork.VehicleKilometerReadingRepository.Exists(e => e.PeriodId == currentPeriodId) ||
                    _unitOfWork.VehicleViolationRepository.Exists(e => e.PeriodId == currentPeriodId))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public BindingList<Period> Periods { get; private set; } = new BindingList<Period>();
        public void Search()
        {
            Periods.Clear();
            IEnumerable<Period> periods = _unitOfWork.PeriodRepository.Find(_name, _date, q => q.OrderBy(p => p.FromDate));
            foreach(var period in periods)
            {
                Periods.Add(period);
            }
        }
        public void ChangeSelectedPeriodState()
        {
            if (_selectedIndex >= 0 && _selectedIndex < Periods.Count)
            {
                var period = _unitOfWork.PeriodRepository.Find(Periods[_selectedIndex].Id);
                if (period != null)
                {
                    period.ReverseState();
                    _unitOfWork.Complete();
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"Period: ${Periods[_selectedIndex].Name} no longer exist.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, Periods);
        }

        public void Create()
        {
            _applicationContext.DisplayPeriodEditView(new PeriodEditViewModel(_unitOfWork, _applicationContext, _validator));
            Search();
        }
        public void Edit()
        {
            if(_selectedIndex >= 0 && _selectedIndex < Periods.Count)
            {
                var period = _unitOfWork.PeriodRepository.Find(Periods[_selectedIndex].Id);
                if (period != null)
                {
                    _applicationContext.DisplayPeriodEditView(new PeriodEditViewModel(period, _unitOfWork, _applicationContext, _validator));
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"Period: ${Periods[_selectedIndex].Name} no longer exist.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Search();
            }
        }
        public void Delete()
        {
            if(_selectedIndex >= 0 && _selectedIndex < Periods.Count)
            {
                if (CanSelectedPeriodBeDeleted())
                {
                    Period period = _unitOfWork.PeriodRepository.Find(Periods[_selectedIndex].Id);
                    if (period != null)
                    {
                        _unitOfWork.PeriodRepository.Remove(period);
                        _ = _unitOfWork.Complete();
                        Search();
                    }
                    else
                    {
                        _applicationContext.DisplayMessage("Info", $"Period: ${Periods[_selectedIndex].Name} no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Search();
                    }
                }
                else
                {
                    _applicationContext.DisplayMessage("Error", $"Cannot Delete Period: ${Periods[_selectedIndex].Name} !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
        #endregion
    }
}
