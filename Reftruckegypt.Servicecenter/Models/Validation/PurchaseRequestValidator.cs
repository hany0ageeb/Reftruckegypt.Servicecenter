namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class PurchaseRequestValidator : IValidator<PurchaseRequest>
    {
        public ModelState Validate(PurchaseRequest entity)
        {
            ModelState modelState = new ModelState();
            if(entity.Period is null)
            {
                modelState.AddError(nameof(entity.Period), string.Format(ValidationErrors.RequiredField, nameof(entity.Period)));
            }
            if(entity.Vehicle is null)
            {
                modelState.AddError(nameof(entity.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(entity.Vehicle)));
            }
            if (string.IsNullOrEmpty(entity.State))
            {
                modelState.AddError(nameof(entity.State), string.Format(ValidationErrors.RequiredField, nameof(entity.State)));
            }
            else if(entity.State.Length > PurchaseRequest.MaxStateLength)
            {
                modelState.AddError(nameof(entity.State), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Period), PurchaseRequest.MaxStateLength));
            }
            if(!string.IsNullOrEmpty(entity.Description) && entity.Description.Length > PurchaseRequest.MaxDescriptionLength)
            {
                modelState.AddError(nameof(entity.Description), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Description), PurchaseRequest.MaxDescriptionLength));
            }
            return modelState;
        }
    }
}
