namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class LocationValidator : IValidator<Location>
    {
        public ModelState Validate(Location location)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(location.Name))
            {
                modelState.AddError(nameof(location.Name), string.Format(ValidationErrors.RequiredField,nameof(location.Name)));
            }
            else if(location.Name.Length > 250)
            {
                modelState.AddError(nameof(location.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(location.Name), 250));
            }
            if(!string.IsNullOrEmpty(location.AddressLine) && location.AddressLine.Length > 500)
            {
                modelState.AddError(nameof(location.AddressLine), ValidationErrors.TooLongFieldValue);
            }
            return modelState;
        }
    }
}
