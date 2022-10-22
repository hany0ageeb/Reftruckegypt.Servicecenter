namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class ReceiptLineValidator : IValidator<ReceiptLine>
    {
        public ModelState Validate(ReceiptLine entity)
        {
            ModelState modelState = new ModelState();
            if(entity.SparePart is null)
            {
                modelState.AddError(nameof(entity.SparePart), string.Format(ValidationErrors.RequiredField, nameof(entity.SparePart)));
            }
            if(entity.Uom is null)
            {
                modelState.AddError(nameof(entity.Uom), string.Format(ValidationErrors.RequiredField, nameof(entity.Uom)));
            }
            if(entity.Period is null)
            {
                modelState.AddError(nameof(entity.Period), string.Format(ValidationErrors.RequiredField, nameof(entity.Period)));
            }
            if(entity.PurchaseRequestLine is null)
            {
                modelState.AddError(nameof(entity.PurchaseRequestLine), string.Format(ValidationErrors.RequiredField, nameof(entity.PurchaseRequestLine)));
            }
            else
            {
                if(entity.ReceivedQuantity > entity.PurchaseRequestLine.RequestedQuantity)
                {
                    modelState.AddError(
                        propertyName: nameof(entity.ReceivedQuantity), 
                        errorMessage: $"Received Quantity {entity.ReceivedQuantity} Exceeds Requested Quantity {entity.PurchaseRequestLine.RequestedQuantity}.");
                }
            }
            if(entity.ReceivedQuantity <= 0)
            {
                modelState.AddError(nameof(entity.ReceivedQuantity), string.Format(ValidationErrors.InvalidQuantity, entity.ReceivedQuantity));
            }
            return modelState;
        }
    }
}
