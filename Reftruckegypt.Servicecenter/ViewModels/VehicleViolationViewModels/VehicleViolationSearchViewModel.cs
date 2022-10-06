using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels
{
    public class VehicleViolationSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;

        private bool _isDisposed = false;

        private int _selectedIndex = -1;
        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = false;

        private Vehicle _vehicle;
        private ViolationType _violationType;
        private DateTime? _fromDate;
        private DateTime? _toDate;

        public VehicleViolationSearchViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(e => e.InternalCode)));
            Vehicles.Insert(0, new Vehicle() { Id = Guid.Empty, InternalCode = "--ALL--" });
            Vehicle = Vehicles[0];
            ViolationTypes.AddRange(_unitOfWork.ViolationTypeRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            ViolationTypes.Insert(0, new ViolationType() { Id = Guid.Empty, Name = "--ALL--"});
            ViolationType = ViolationTypes[0];
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
        public ViolationType ViolationType
        {
            get => _violationType;
            set
            {
                if (_violationType != value)
                {
                    _violationType = value;
                    OnPropertyChanged(this, nameof(ViolationType));
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
        private bool CanDeleteSelectedRecord()
        {
            if(_selectedIndex >= 0 && _selectedIndex < VehicleViolationViewModels.Count)
            {
                return VehicleViolationViewModels[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        private bool CanEditSelectedRecord()
        {
            if (_selectedIndex >= 0 && _selectedIndex < VehicleViolationViewModels.Count)
            {
                return VehicleViolationViewModels[_selectedIndex].State == PeriodStates.OpenState;
            }
            return false;
        }
        public void Search()
        {
            VehicleViolationViewModels.Clear();
            IEnumerable<VehicleViolation> violations = _unitOfWork.VehicleViolationRepository.Find(
                vehicleId: _vehicle.Id, 
                violationTypeId: _violationType.Id, 
                fromDate: _fromDate, 
                toDate: _toDate, 
                orderBy: q => q.OrderBy(x => x.ViolationDate).ThenBy(x => x.Vehicle.InternalCode));
            foreach(VehicleViolation violation in violations)
            {
                VehicleViolationViewModels.Add(new VehicleViolationViewModel(violation));
            }

        }
        public void Create()
        {
            VehicleViolationEditViewModel editModel = new VehicleViolationEditViewModel(_unitOfWork, _applicationContext);
            _applicationContext.DisplayVehicleViolationEditView(editModel);
            Search();
        }
        public void Edit()
        {
            if (_selectedIndex >= 0 && _selectedIndex < VehicleViolationViewModels.Count)
            {
                VehicleViolation vehicleViolation = _unitOfWork.VehicleViolationRepository.Find(key: VehicleViolationViewModels[_selectedIndex].Id);
                if (vehicleViolation != null)
                {
                    VehicleViolationEditViewModel editModel = new VehicleViolationEditViewModel(vehicleViolation, _unitOfWork, _applicationContext);
                    _applicationContext.DisplayVehicleViolationEditView(editModel);
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"The Selected Record is no longer Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public void Delete()
        {
            if(_selectedIndex >= 0 && _selectedIndex < VehicleViolationViewModels.Count)
            {
                VehicleViolation vehicleViolation = _unitOfWork.VehicleViolationRepository.Find(key: VehicleViolationViewModels[_selectedIndex].Id);
                if (vehicleViolation != null)
                {
                    DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Violation of Vehicle {VehicleViolationViewModels[_selectedIndex].VehicleInternalCode}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        _unitOfWork.VehicleViolationRepository.Remove(vehicleViolation);
                        _unitOfWork.Complete();
                        Search();
                    }
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"The Selected Record is no longer Exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public BindingList<VehicleViolationViewModel> VehicleViolationViewModels { get; private set; } = new BindingList<VehicleViolationViewModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<ViolationType> ViolationTypes { get; private set; } = new List<ViolationType>();
        #region IDisposable
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
        #endregion IDisposable
    }
}
