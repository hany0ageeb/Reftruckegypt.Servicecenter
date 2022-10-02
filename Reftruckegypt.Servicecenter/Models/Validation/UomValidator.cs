namespace Reftruckegypt.Servicecenter.Models.Validation
{
     public class UomValidator : IValidator<Uom>
     {
        public ModelState Validate(Uom uom)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(uom.Code))
            {
                modelState.AddError(nameof(uom.Code), string.Format(ValidationErrors.RequiredField, nameof(uom.Code)));
            }
            else if(uom.Code.Length > Uom.CodeMaxLength)
            {
                modelState.AddError(nameof(uom.Code), string.Format(ValidationErrors.TooLongFieldValue, nameof(uom.Code), nameof(Uom.CodeMaxLength)));
            }
            if (!string.IsNullOrEmpty(uom.Name) && uom.Name.Length > Uom.NameMaxLength)
            {
                modelState.AddError(nameof(uom.Code), string.Format(ValidationErrors.TooLongFieldValue, nameof(uom.Name), nameof(Uom.NameMaxLength)));
            }
            return modelState;
        }
    }
}
