namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleModelValidator : IValidator<VehicleModel>
    {
        public ModelState Validate(VehicleModel vehicleModel)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(vehicleModel.Name))
            {
                modelState.AddError(nameof(vehicleModel.Name), string.Format(ValidationErrors.RequiredField, nameof(vehicleModel.Name)));
            }
            else if(vehicleModel.Name.Length > VehicleModel.NameMaxLength)
            {
                modelState.AddError(nameof(vehicleModel.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleModel.Name), VehicleModel.NameMaxLength));
            }
            if(!string.IsNullOrEmpty(vehicleModel.Description) && vehicleModel.Description.Length > VehicleModel.DescriptionMaxLength)
            {
                modelState.AddError(nameof(vehicleModel.Description), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleModel.Description), VehicleModel.DescriptionMaxLength));
            }
            return modelState;
        }
    }
}
