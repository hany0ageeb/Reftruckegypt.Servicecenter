namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class SparePartsBillValidator : IValidator<SparePartsBill>
    {
        public ModelState Validate(SparePartsBill entity)
        {
            ModelState modelState = new ModelState();
            if(entity.Vehicle is null)
            {
                modelState.AddError(nameof(entity.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(entity.Vehicle)));
            }
            if(entity.Period is null)
            {
                modelState.AddError(nameof(entity.Period), string.Format(ValidationErrors.RequiredField, nameof(entity.Vehicle)));
            }
            if(!string.IsNullOrEmpty(entity.Repairs) && entity.Repairs.Length > SparePartsBill.MaxRepairsLength)
            {
                modelState.AddError(nameof(entity.Repairs), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Repairs), SparePartsBill.MaxRepairsLength));
            }
            if(entity.KilometerReading.HasValue && entity.KilometerReading < 0)
            {
                modelState.AddError(nameof(entity.KilometerReading), "Negative Kilometer Reading!!!");
            }
            return modelState;
        }
    }
}
