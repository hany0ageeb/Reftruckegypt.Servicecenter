using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels
{
    public class VehicleCategorySearchViewModel : ViewModelBase
    {
        private IUnitOfWork _unitOfWork;
        public VehicleCategorySearchViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private string _name;
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
        public void Search()
        {

        }
    }
    public class VehicleCategoryViewModel : ViewModelBase
    {
        public VehicleCategoryViewModel()
        {
            Name = "";
            Description = "";
        }
        public VehicleCategoryViewModel(Models.VehicleCategory vehicleCategory)
        {
            Name = vehicleCategory.Name;
            Description = vehicleCategory.Description;
            IsChassisNumberRequired = vehicleCategory.IsChassisNumberRequired;
            IsFuelCardRequired = vehicleCategory.IsFuelCardRequired;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsChassisNumberRequired { get; private set; }

        public bool IsFuelCardRequired { get; private set; }
    }
}
