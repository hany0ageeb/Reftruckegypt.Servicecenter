using Microsoft.Extensions.DependencyInjection;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels
{
    public delegate void SelectedVehicleCategoryChangedEventHandler(object sender, SelectedVehicleCategoryChangedEventArgs evt);
    public class SelectedVehicleCategoryChangedEventArgs : EventArgs
    {
        public SelectedVehicleCategoryChangedEventArgs(int index)
        {
            Index = index;
        }
        public int Index { get; private set; }
    }
    public class VehicleCategorySearchViewModel : ViewModelBase, IDisposable
    {
        private IUnitOfWork _unitOfWork;
        private Common.IApplicationContext _applicationContext;
        private int _selectedIndex = -1;
        private bool _isDisposed = false;
        public event SelectedVehicleCategoryChangedEventHandler SelectedVehicleCategoryChanged;
        public VehicleCategorySearchViewModel(IUnitOfWork unitOfWork, Common.IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _name = "";
        }
        private string _name;
        private bool _canDelete = false;
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
        
        public bool CanDelete
        {
            get => _canDelete;
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    OnPropertyChanged(this, nameof(CanDelete));
                }
            }
        }
        public bool CanEdit
        {
            get => _selectedIndex >= 0 && _selectedIndex < VehicleCategoryViews.Count;
        }
        public void Search()
        {
            VehicleCategoryViews.Clear();
            var vehicleCategories = 
                _unitOfWork.VehicleCategoryRepository.Find(
                    predicate: (cat) => cat.Name.Contains(_name) || cat.Description.Contains(_name), 
                    orderBy: q=> q.OrderBy(cat=>cat.Name)
                 ).ToList();
            foreach(var vehicleCategory in vehicleCategories)
            {
                VehicleCategoryViews.Add(new VehicleCategoryViewModel(vehicleCategory));
            }
            if(vehicleCategories.Count > 0)
            {
                _selectedIndex = 0;
            }
            else
            {
                _selectedIndex = -1;
            }
            SelectedVehicleCategoryChanged?.Invoke(this, new SelectedVehicleCategoryChangedEventArgs(_selectedIndex));
        }
        private bool CanDeleteVehicleCategory(int index)
        {
            if(index >= 0 && index < VehicleCategoryViews.Count)
            {
                Guid id = VehicleCategoryViews[index].Id;
                return !_unitOfWork.VehicleRepository.Exists(e => e.VehicleCategoryId == id);
            }
            return false;
        }
        public void SelectedVehicelCategoryChanged(int index)
        {
            _selectedIndex = index;
            CanDelete = CanDeleteVehicleCategory(_selectedIndex);
        }
        public void Create()
        {
            IValidator<VehicleCategory> validator = Program.ServiceProvider.GetRequiredService<IValidator<VehicleCategory>>();
            VehicleCategoryEditViewModel editModel = new VehicleCategoryEditViewModel(validator, _unitOfWork,_applicationContext);
            _applicationContext.DisplayVehicleCategoryEditView(editModel);
            Search();
        }
        public void Delete()
        {
           
            if(_selectedIndex >= 0 && _selectedIndex < VehicleCategoryViews.Count)
            {
                var result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure you want to delete VehicleCategory: {VehicleCategoryViews[_selectedIndex].Name}", Common.MessageBoxButtons.YesNo, Common.MessageBoxIcon.Question);
                if (result == Common.DialogResult.Yes)
                {
                    _unitOfWork.VehicleCategoryRepository.Remove(_unitOfWork.VehicleCategoryRepository.Find(VehicleCategoryViews[_selectedIndex].Id));
                    _unitOfWork.Complete();
                    Search();
                }
            }
        }
        public void Edit()
        {
            if (_selectedIndex >= 0 && _selectedIndex < VehicleCategoryViews.Count)
            {
                IValidator<VehicleCategory> validator = Program.ServiceProvider.GetRequiredService<IValidator<VehicleCategory>>();
                VehicleCategoryEditViewModel editModel = new VehicleCategoryEditViewModel(_unitOfWork.VehicleCategoryRepository.Find(VehicleCategoryViews[_selectedIndex].Id), validator,_unitOfWork, _applicationContext);
                _applicationContext.DisplayVehicleCategoryEditView(editModel);
                Search();
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

        public BindingList<VehicleCategoryViewModel> VehicleCategoryViews { get; private set; } = new BindingList<VehicleCategoryViewModel>();
    }
}
