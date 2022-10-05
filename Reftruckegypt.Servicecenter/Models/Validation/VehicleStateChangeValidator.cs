namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleStateChangeValidator : IValidator<VehicleStateChange>
    {
        public ModelState Validate(VehicleStateChange vehicleStateChange)
        {
            ModelState modelState = new ModelState();
            if(vehicleStateChange.Vehicle == null)
            {
                modelState.AddError(nameof(vehicleStateChange.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(vehicleStateChange.Vehicle)));
            }
            if (string.IsNullOrEmpty(vehicleStateChange.State))
            {
                modelState.AddError(nameof(vehicleStateChange.State), string.Format(ValidationErrors.RequiredField, nameof(vehicleStateChange.State)));
            }
            else if(vehicleStateChange.State.Length > VehicleStateChange.MaxStateLength)
            {
                modelState.AddError(nameof(vehicleStateChange.State), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleStateChange.State), VehicleStateChange.MaxStateLength));
            }
            else if (!VehicleStates.IsValidState(vehicleStateChange.State))
            {
                modelState.AddError(nameof(VehicleStateChange.State), string.Format(ValidationErrors.InvalidVehicleState, nameof(VehicleStateChange.State), VehicleStates.Broken, VehicleStates.Working));
            }
            if(!string.IsNullOrEmpty(vehicleStateChange.Notes) && vehicleStateChange.Notes.Length > VehicleStateChange.MaxNotesLength)
            {
                modelState.AddError(nameof(vehicleStateChange.Notes), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleStateChange.Notes), VehicleStateChange.MaxNotesLength));
            }
            return modelState;
        }
    }
}
