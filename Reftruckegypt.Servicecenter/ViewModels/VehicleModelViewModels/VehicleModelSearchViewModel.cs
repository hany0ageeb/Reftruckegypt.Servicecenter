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

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels
{
    public class VehicleModelSearchViewModel : ViewModelBase, IDisposable
    {
        private bool _isDisposed = false;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<VehicleModel> _validator;
        private string _name = "";
        private int _selectedIndex = -1;
        private bool _canDeleteVehicleModel = false;
        private bool _canEditVehicleModel = false;
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
        public VehicleModelSearchViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<VehicleModel> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _applicationContext = applicationContext;
        }
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
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
                    CanDeleteVehicleModel = IsVehicleModelDeletable(_selectedIndex);
                }
                if(_selectedIndex < 0 || _selectedIndex >= VehicleModelViewModels.Count)
                {
                    CanEditVehicleModel = false;
                }
            }
        }
        public bool CanEditVehicleModel
        {
            get => _canEditVehicleModel;
            private set
            {
                if (_canEditVehicleModel != value)
                {
                    _canEditVehicleModel = value;
                    OnPropertyChanged(this, nameof(CanEditVehicleModel));
                }
            }
        }
        public bool CanDeleteVehicleModel
        {
            get => _canDeleteVehicleModel;
            private set
            {
                if (_canDeleteVehicleModel != value)
                {
                    _canDeleteVehicleModel = value;
                    OnPropertyChanged(this, nameof(CanDeleteVehicleModel));
                }
            }
        }
        public bool IsVehicleModelDeletable(int index)
        {
            if(index >= 0 && index < VehicleModelViewModels.Count)
            {
                Guid id = VehicleModelViewModels[index].Id;
                return !_unitOfWork.VehicleRepository.Exists(v => v.VehicelModelId == id);
            }
            return false;
        }
        public void Delete(int index)
        {
            if(index  >=0 && index < VehicleModelViewModels.Count)
            {
                var result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Vehicle Model: {VehicleModelViewModels[index].Name}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    var model = _unitOfWork.VehicleModelRepository.Find(VehicleModelViewModels[index].Id);
                    _unitOfWork.VehicleModelRepository.Remove(model);
                    _ = _unitOfWork.Complete();
                    Search();
                }
            }
        }
        public void Create()
        {
            VehicleModelEditViewModel editViewModel = new VehicleModelEditViewModel( _unitOfWork, _validator, _applicationContext);
            _applicationContext.DisplayVehicleModelEditView(editViewModel);
            Search();
        }
        public void Edit(int index)
        {
            if(index >= 0 && index < VehicleModelViewModels.Count)
            {
                var model = _unitOfWork.VehicleModelRepository.Find(VehicleModelViewModels[index].Id);
                if (model != null)
                {
                    VehicleModelEditViewModel editViewModel = new VehicleModelEditViewModel(model, _unitOfWork,_validator,_applicationContext);
                    _applicationContext.DisplayVehicleModelEditView(editViewModel);
                    Search();
                }
                else
                {
                    _applicationContext.DisplayMessage("Info", $"Vehicle Model {VehicleModelViewModels[index].Name} is no longer exist.", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
        public void Search()
        {
            VehicleModelViewModels.Clear();
            var models = _unitOfWork.VehicleModelRepository.Find(
                predicate: e => e.Name.Contains(_name) || e.Description.Contains(_name),
                orderBy: q=>q.OrderBy(e=>e.Name));
            foreach(var model in models)
            {
                VehicleModelViewModels.Add(new VehicleModelViewModel(model));
            }
            if(models.Count() > 0)
            {
                _selectedIndex = 0;
                CanEditVehicleModel = true;
            }
            else
            {
                _selectedIndex = -1;
                CanEditVehicleModel = false;
                CanDeleteVehicleModel = false;
            }
        }
        
        public BindingList<VehicleModelViewModel> VehicleModelViewModels { get; private set; } = new BindingList<VehicleModelViewModel>();
    }
}
