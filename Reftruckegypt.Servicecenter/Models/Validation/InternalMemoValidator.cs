namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class InternalMemoValidator : IValidator<InternalMemo>
    {
        public ModelState Validate(InternalMemo entity)
        {
            ModelState modelState = new ModelState();
            if(entity.Vehicle is null)
            {
                modelState.AddError(nameof(entity.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(entity.Vehicle)));
            }
            if(entity.Period is null)
            {
                modelState.AddError(nameof(entity.Period), string.Format(ValidationErrors.RequiredField, nameof(entity.Period)));
            }
            if (string.IsNullOrEmpty(entity.Header))
            {
                modelState.AddError(nameof(entity.Header), string.Format(ValidationErrors.RequiredField, nameof(entity.Header)));
            }
            else if(entity.Header.Length > InternalMemo.MaxHeaderLength)
            {
                modelState.AddError(nameof(entity.Header), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Header), InternalMemo.MaxHeaderLength));
            }
            if (string.IsNullOrEmpty(entity.Content))
            {
                modelState.AddError(nameof(entity.Content), string.Format(ValidationErrors.RequiredField, nameof(entity.Content)));
            }
            else if(entity.Content.Length > InternalMemo.MaxContentLength)
            {
                modelState.AddError(nameof(entity.Content), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Content), InternalMemo.MaxContentLength));
            }
            return modelState;
        }
    }
}
