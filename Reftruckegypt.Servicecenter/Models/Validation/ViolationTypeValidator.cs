namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class ViolationTypeValidator : IValidator<ViolationType>
    {
        public ModelState Validate(ViolationType violationType)
        {
            ModelState modelState = new ModelState();
            if (string.IsNullOrEmpty(violationType.Name))
            {
                modelState.AddError(nameof(violationType.Name), string.Format(ValidationErrors.RequiredField, nameof(violationType.Name)));
            }
            else if(violationType.Name.Length > ViolationType.MaxNameLength)
            {
                modelState.AddError(nameof(violationType.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(violationType.Name), ViolationType.MaxNameLength));
            }
            if(!string.IsNullOrEmpty(violationType.Description) && violationType.Description.Length > ViolationType.MaxDescriptionLength)
            {
                modelState.AddError(nameof(violationType.Description), string.Format(ValidationErrors.TooLongFieldValue, nameof(violationType.Description), ViolationType.MaxDescriptionLength));
            }
            return modelState;
        }
    }
}
