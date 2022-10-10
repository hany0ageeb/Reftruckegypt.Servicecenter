using Npoi.Mapper.Attributes;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels
{
    public class VehicleCategoryViewModel : ViewModelBase
    {
        public VehicleCategoryViewModel()
        {
            Name = "";
            Description = "";
            IsFuelCardRequired = false;
            IsChassisNumberRequired = false;
            Id = Guid.Empty;
        }
        public VehicleCategoryViewModel(Models.VehicleCategory vehicleCategory)
        {
            Name = vehicleCategory.Name;
            Description = vehicleCategory.Description;
            IsChassisNumberRequired = vehicleCategory.IsChassisNumberRequired;
            IsFuelCardRequired = vehicleCategory.IsFuelCardRequired;
            Id = vehicleCategory.Id;
        }
        [Ignore]
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        [Ignore]
        public bool IsChassisNumberRequired { get; private set; }
        [Ignore]
        public bool IsFuelCardRequired { get; private set; }

    }
}
