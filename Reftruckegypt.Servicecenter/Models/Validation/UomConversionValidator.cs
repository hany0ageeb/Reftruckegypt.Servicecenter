namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class UomConversionValidator : IValidator<UomConversion>
    {
        public ModelState Validate(UomConversion entity)
        {
            ModelState modelState = new ModelState();
            if(entity.FromUom == null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.FromUom),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "From Uom"));
            }
            if (entity.ToUom == null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.ToUom),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "To Uom"));
            }
            if(entity.Rate <= 0)
            {
                modelState.AddError(
                    propertyName: nameof(entity.ToUom),
                    errorMessage: $"Invalid Uom Conversion Rate. Should be greater than zero");
            }
            if(!string.IsNullOrEmpty(entity.Notes) && entity.Notes.Length > 500)
            {
                modelState.AddError(
                    propertyName: nameof(entity.FromUom),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Notes", UomConversion.MaxNotesLength));
            }
            if(entity.FromUom!=null && entity.ToUom != null)
            {
                if(entity.FromUom.Id == entity.ToUom.Id)
                {
                    modelState.AddError(nameof(entity.FromUom), "From Uom is the same as To Uom!");
                }
            }
            return modelState;
        }
    }
}
