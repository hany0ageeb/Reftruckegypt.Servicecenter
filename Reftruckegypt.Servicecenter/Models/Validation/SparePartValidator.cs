namespace Reftruckegypt.Servicecenter.Models.Validation
{
    
        public class SparePartValidator : IValidator<SparePart>
        {
            public ModelState Validate(SparePart sparePart)
            {
                ModelState modelState = new ModelState();
                if (string.IsNullOrEmpty(sparePart.Code))
                {
                    modelState.AddError(nameof(sparePart.Code), string.Format(ValidationErrors.RequiredField, nameof(sparePart.Code)));
                }
                else if(sparePart.Code.Length > SparePart.MaxSparePartCodeLength)
                {
                    modelState.AddError(nameof(sparePart.Code), string.Format(ValidationErrors.TooLongFieldValue, nameof(sparePart.Code), SparePart.MaxSparePartCodeLength));
                }
                if (string.IsNullOrEmpty(sparePart.Name))
                {
                    modelState.AddError(nameof(sparePart.Name), string.Format(ValidationErrors.RequiredField, nameof(sparePart.Name)));
                }
                else if(sparePart.Name.Length > SparePart.MaxSparePartNameLength)
                {
                    modelState.AddError(nameof(sparePart.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(sparePart.Name), SparePart.MaxSparePartNameLength));
                }
                if(sparePart.PrimaryUom == null)
                {
                    modelState.AddError(nameof(sparePart.PrimaryUom), string.Format(ValidationErrors.RequiredField, nameof(sparePart.PrimaryUom)));
                }
                return modelState;
            }
        }
}
