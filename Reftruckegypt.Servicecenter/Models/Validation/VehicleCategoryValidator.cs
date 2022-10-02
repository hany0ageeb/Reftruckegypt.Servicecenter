namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleCategoryValidator : IValidator<VehicleCategory>
    {
        public ModelState Validate(VehicleCategory vehicleCategory)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(vehicleCategory.Name))
            {
                modelState.AddError(nameof(vehicleCategory.Name), string.Format(ValidationErrors.RequiredField, nameof(vehicleCategory.Name)));
            }
            else if(vehicleCategory.Name.Length > VehicleCategory.MaxVehicleCategoryNameLength)
            {
                modelState.AddError(nameof(vehicleCategory.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleCategory.Name), VehicleCategory.MaxVehicleCategoryNameLength));
            }
            if (!string.IsNullOrEmpty(vehicleCategory.Description) && vehicleCategory.Description.Length > VehicleCategory.MaxVehicleCategoryDescriptionLength)
            {
                modelState.AddError(nameof(vehicleCategory.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleCategory.Description), VehicleCategory.MaxVehicleCategoryDescriptionLength));
            }
            return modelState;
        }
    }
}
