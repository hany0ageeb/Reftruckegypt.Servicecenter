namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class DriverValidator : IValidator<Driver>
    {
        public ModelState Validate(Driver driver)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(driver.Name))
            {
                modelState.AddError(
                    propertyName:nameof(driver.Name),
                    errorMessage: string.Format(ValidationErrors.RequiredField, nameof(driver.Name)));
            }
            else if (driver.Name.Length > Driver.MaxNameLength)
            {
                modelState.AddError(
                    propertyName: nameof(driver.Name),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, nameof(driver.Name), Driver.MaxNameLength));
            }
            if (string.IsNullOrEmpty(driver.LicenseNumber))
            {
                modelState.AddError(
                                   propertyName: nameof(driver.LicenseNumber),
                                   errorMessage: string.Format(ValidationErrors.RequiredField, nameof(driver.LicenseNumber)));
            }
            else if (driver.LicenseNumber.Length > Driver.MaxLicenseNumberLength)
            {
                modelState.AddError(
                    propertyName: nameof(driver.LicenseNumber),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Driver License Number" , Driver.MaxLicenseNumberLength));
            }
            if(!string.IsNullOrEmpty(driver.TrafficDepartmentName) && driver.TrafficDepartmentName.Length > Driver.MaxTrafficDepartmentNameLength)
            {
                modelState.AddError(
                    propertyName: nameof(driver.TrafficDepartmentName),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Traffic Department Name", Driver.MaxTrafficDepartmentNameLength));
            }
            return modelState;
        }
    }
}
