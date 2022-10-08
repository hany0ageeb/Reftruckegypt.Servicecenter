namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class SparePartsBillLineValidator : IValidator<SparePartsBillLine>
    {
        public ModelState Validate(SparePartsBillLine entity)
        {
            ModelState modelState = new ModelState();
            if(entity.SparePart is null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.SparePart),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Spare Part"));
            }
            if(entity.Quantity <= 0)
            {
                modelState.AddError(
                    propertyName: nameof(entity.Quantity),
                    errorMessage: $"Invalid Quantity {entity.Quantity}\n should be greater than zero"
                    );
            }
            if(entity.UnitPrice < 0)
            {
                modelState.AddError(
                    propertyName: nameof(entity.UnitPrice),
                    errorMessage: $"Invalid Unit Price {entity.UnitPrice}.\n unit price should not be less than zero"
                    );
            }
            if(entity.Uom is null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.Uom),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Uom"));
            }
            if(!string.IsNullOrEmpty(entity.Notes) && entity.Notes.Length > SparePartsBillLine.MaxNotesLength)
            {
                modelState.AddError(
                    propertyName: nameof(entity.Notes),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Notes), SparePartsBillLine.MaxNotesLength)
                    );
            }
            return modelState;
        }
    }
}
