namespace Reftruckegypt.Servicecenter.Models.Validation
{

    public class DriverValidator : IValidator<Driver>
    {
        public ModelState Validate(Driver driver)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(driver.Name))
            {
                modelState.AddError(nameof(driver.Name), string.Format(ValidationErrors.RequiredField, nameof(driver.Name)));
            }
            else if(driver.Name.Length > Driver.MaxNameLength)
            {
                modelState.AddError(nameof(driver.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(driver.Name), Driver.MaxNameLength));
            }
            if (!string.IsNullOrEmpty(driver.LicenseNumber) && driver.LicenseNumber.Length > Driver.MaxLicenseNumberLength)
            {
                modelState.AddError(nameof(driver.LicenseNumber), string.Format(ValidationErrors.TooLongFieldValue, nameof(driver.LicenseNumber), Driver.MaxLicenseNumberLength));
            }
            return modelState;
        }
    }
}
