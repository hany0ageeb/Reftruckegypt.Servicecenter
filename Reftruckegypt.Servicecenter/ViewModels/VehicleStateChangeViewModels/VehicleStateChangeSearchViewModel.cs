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

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels
{
    public class VehicleStateChangeSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<VehicleStateChange> _validator;

        private Vehicle _vehicle;
        private DateTime? _fromDate;
        private DateTime? _toDate;

        private int _selectedIndex = -1;
        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = false;

        private bool _isDisposed = false;

        public VehicleStateChangeSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<VehicleStateChange> validator
        )
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            Vehicles.Insert(0, Vehicle.Empty);
            _vehicle = Vehicle.Empty;
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged(this, nameof(SelectedIndex));
                    if(_selectedIndex >= 0 && _selectedIndex < VehicleStateChanges.Count)
                    {
                        IsEditEnabled = true;
                        IsDeleteEnabled = true;
                    }
                }
            }
        }
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            private set
            {
                if(_isDeleteEnabled != value)
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
                if(_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
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
        public void Search()
        {
            VehicleStateChanges.Clear();
            IEnumerable<VehicleStateChange> vehicleStateChanges =
                _unitOfWork.VehicleStateChangeRepository
                .Find(
                    vehicleId: _vehicle.Id,
                    fromDate: _fromDate,
                    toDate: _toDate,
                    orderBy: q=>q.OrderBy(x=>x.Vehicle.InternalCode).ThenBy(x => x.FromDate));
            foreach(VehicleStateChange vehicleStateChange in vehicleStateChanges)
            {
                VehicleStateChanges.Add(new VehicleStateChangeViewModel(vehicleStateChange));
            }
        }
        public void Create()
        {
            _applicationContext.DisplayVehicleStateChangeEditView(new VehicleStateChangesEditModel(_unitOfWork, _applicationContext, _validator));
        }
        public void Edit()
        {
            if (_isEditEnabled)
            {
                _applicationContext.DisplayVehicleStateChangeEditView(
                    new VehicleStateChangesEditModel(
                        VehicleStateChanges.Select(x => x.VehicleStateChange), 
                        _unitOfWork, 
                        _applicationContext, 
                        _validator));
                Search();
            }
        }
        public void Delete()
        {
            if (_isDeleteEnabled)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confirm Delete",
                    message: $"Are You Sure You want To Delete Down time for Vehicle: {VehicleStateChanges[_selectedIndex].VehicleInternalCode} from Date {VehicleStateChanges[_selectedIndex].FromDate} to Date {VehicleStateChanges[_selectedIndex].FromDate.ToString() ?? "(Still Broken ... )"}",
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    VehicleStateChange vehicleStateChange =
                        _unitOfWork.VehicleStateChangeRepository.Find(key: VehicleStateChanges[_selectedIndex].Id);
                    if (vehicleStateChange != null)
                    {
                        _unitOfWork.VehicleStateChangeRepository.Remove(vehicleStateChange);
                        _unitOfWork.Complete();
                    }
                    Search();
                }
            }
        }
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
        public BindingList<VehicleStateChangeViewModel> VehicleStateChanges { get; private set; } = new BindingList<VehicleStateChangeViewModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
    }
}
