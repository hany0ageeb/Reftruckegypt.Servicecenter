namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class LocationValidator : IValidator<Location>
    {
        public ModelState Validate(Location location)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(location.Name))
            {
                modelState.AddError(nameof(location.Name), ValidationErrors.EmptyLocationName);
            }
            return modelState;
        }
    }
}
