namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleViolationValidator : IValidator<VehicleViolation>
    {
        public ModelState Validate(VehicleViolation vehicleViolation)
        {
            ModelState modelState = new ModelState();
            if(vehicleViolation.Period == null)
            {
                modelState.AddError(nameof(vehicleViolation.Period), string.Format(ValidationErrors.RequiredField, nameof(vehicleViolation.Period)));
            }
            if(vehicleViolation.Vehicle == null)
            {
                modelState.AddError(nameof(vehicleViolation.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(vehicleViolation.Vehicle)));
            }
            if(vehicleViolation.ViolationType == null)
            {
                modelState.AddError(nameof(vehicleViolation.ViolationType), string.Format(ValidationErrors.RequiredField, nameof(vehicleViolation.ViolationType)));
            }
            if(vehicleViolation.Count <= 0)
            {
                modelState.AddError(nameof(vehicleViolation.Count), string.Format(ValidationErrors.InvalidViolationsCount, vehicleViolation.Count));
            }
            if(vehicleViolation.Notes?.Length > VehicleViolation.MaxNotesLength)
            {
                modelState.AddError(nameof(vehicleViolation.Notes), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleViolation.Notes), VehicleViolation.MaxNotesLength));
            }
            return modelState;
        }
    }
}
