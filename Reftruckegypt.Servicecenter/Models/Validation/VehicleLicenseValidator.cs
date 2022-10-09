namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleLicenseValidator : IValidator<VehicleLicense>
    {
        public ModelState Validate(VehicleLicense entity)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(entity.MotorNumber))
            {
                modelState.AddError(
                    propertyName: nameof(entity.MotorNumber),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Motor Number"));
            }
            else if(entity.MotorNumber.Length > VehicleLicense.MaxMotorNumberLength)
            {
                modelState.AddError(
                    propertyName: nameof(entity.MotorNumber),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Motor Number", VehicleLicense.MaxMotorNumberLength));
            }
            if(entity.StartDate >= entity.EndDate)
            {
                modelState.AddError(
                    propertyName: nameof(entity.StartDate),
                    errorMessage: $"Start Date {entity.StartDate:g} is greater than or equal to End Date {entity.EndDate:g}");
            }
            if (string.IsNullOrEmpty(entity.PlateNumber))
            {
                modelState.AddError(
                    propertyName: nameof(entity.PlateNumber),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Plate Number"));
            }
            else if(entity.PlateNumber.Length > VehicleLicense.MaxPlatNumberLength)
            {
                modelState.AddError(
                   propertyName: nameof(entity.PlateNumber),
                   errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Plate Number", VehicleLicense.MaxPlatNumberLength));
            }
            
            return modelState;
        }
    }
}
