namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class PurchaseRequestLineValidator : IValidator<PurchaseRequestLine>
    {
        public ModelState Validate(PurchaseRequestLine entity)
        {
            ModelState modelState = new ModelState();
            if (entity.SparePart is null)
            {
                modelState.AddError(nameof(entity.SparePart), string.Format(ValidationErrors.RequiredField, nameof(entity.SparePart)));
            }
            if(entity.RequestedQuantity <= 0)
            {
                modelState.AddError(nameof(entity.RequestedQuantity), string.Format(ValidationErrors.InvalidQuantity, entity.RequestedQuantity));
            }
            if(entity.Uom is null)
            {
                modelState.AddError(nameof(entity.Uom), string.Format(ValidationErrors.RequiredField, nameof(entity.Uom)));
            }
            if (!string.IsNullOrEmpty(entity.Notes) && entity.Notes.Length > PurchaseRequestLine.MaxNotesLength)
            {
                modelState.AddError(nameof(entity.Notes), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Notes), PurchaseRequestLine.MaxNotesLength));
            }
            return modelState;
        }
    }
}
