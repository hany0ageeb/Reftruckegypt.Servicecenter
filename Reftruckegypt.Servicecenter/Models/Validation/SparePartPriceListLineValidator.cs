namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class SparePartPriceListLineValidator : IValidator<SparePartPriceListLine>
    {
        public ModelState Validate(SparePartPriceListLine entity)
        {
            ModelState modelState = new ModelState();
            if(entity.SparePart == null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.SparePart),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Spare Part"));
            }
            if(entity.Uom == null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.Uom),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Uom"));
            }
            if(entity.Uom != null && entity.Uom.Id != entity.SparePart?.PrimaryUom.Id && (entity.UomConversionRate == null || entity.UomConversionRate <= 0))
            {
                modelState.AddError(
                   propertyName: nameof(entity.UomConversionRate),
                   errorMessage: $"No Conversion Exists between Uom: {entity.Uom.Code} and {entity.SparePart?.PrimaryUom?.Code}");
            }
            return modelState;
        }
    }
}
