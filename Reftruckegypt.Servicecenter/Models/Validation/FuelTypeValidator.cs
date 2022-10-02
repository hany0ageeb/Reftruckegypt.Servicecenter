namespace Reftruckegypt.Servicecenter.Models.Validation
{
   
        public class FuelTypeValidator : IValidator<FuelType>
        {
            public ModelState Validate(FuelType fuelType)
            {
                ModelState modelState = new ModelState();
                if (string.IsNullOrEmpty(fuelType.Name))
                {
                    modelState.AddError(nameof(fuelType.Name), string.Format(ValidationErrors.RequiredField, nameof(fuelType.Name)));
                }
                else if(fuelType.Name.Length > FuelType.MaxFuelTypeNameLength)
                {
                    modelState.AddError(nameof(fuelType.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(fuelType.Name), FuelType.MaxFuelTypeNameLength));
                }
                if(!string.IsNullOrEmpty(fuelType.Description) && fuelType.Description.Length > FuelType.MaxFuelTypeDescriptionLength)
                {
                    modelState.AddError(nameof(fuelType.Description), string.Format(ValidationErrors.TooLongFieldValue, nameof(fuelType.Description), FuelType.MaxFuelTypeDescriptionLength));
                }
                return modelState;
            }
        }
}
