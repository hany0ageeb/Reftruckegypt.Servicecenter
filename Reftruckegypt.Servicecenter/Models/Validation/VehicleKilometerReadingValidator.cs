namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleKilometerReadingValidator : IValidator<VehicleKilometerReading>
    {
        public ModelState Validate(VehicleKilometerReading vehicleKilometerReading)
        {
            ModelState modelState = new ModelState();
            if(vehicleKilometerReading.Vehicle == null)
            {
                modelState.AddError(nameof(vehicleKilometerReading.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(vehicleKilometerReading.Vehicle)));
            }
            if(vehicleKilometerReading.Period == null)
            {
                modelState.AddError(nameof(vehicleKilometerReading.Period), string.Format(ValidationErrors.RequiredField, nameof(vehicleKilometerReading.Period)));
            }
            if(vehicleKilometerReading.Reading < 0)
            {
                modelState.AddError(nameof(vehicleKilometerReading.Reading), string.Format(ValidationErrors.InvalidKilometerReading, vehicleKilometerReading.Reading));
            }
            if (!string.IsNullOrEmpty(vehicleKilometerReading.Notes) && vehicleKilometerReading.Notes.Length > VehicleKilometerReading.VehicleKilometerReadingNotesMaxLength)
            {
                modelState.AddError(nameof(vehicleKilometerReading.Notes), string.Format(ValidationErrors.TooLongFieldValue, nameof(vehicleKilometerReading.Notes), VehicleKilometerReading.VehicleKilometerReadingNotesMaxLength));
            }
            return modelState;
        }
    }
}
