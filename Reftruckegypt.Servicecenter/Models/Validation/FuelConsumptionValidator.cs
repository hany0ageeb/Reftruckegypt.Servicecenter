namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class FuelConsumptionValidator : IValidator<FuelConsumption>
    {
        public ModelState Validate(FuelConsumption fuelConsumption)
        {
            ModelState modelState = new ModelState();
            if (fuelConsumption.Vehicle == null)
            {
                modelState.AddError(nameof(fuelConsumption.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(fuelConsumption.Vehicle)));
            }
            if(fuelConsumption.FuelType == null)
            {
                modelState.AddError(nameof(fuelConsumption.FuelType), $"Fuel Type Field is required.");
            }
            if(fuelConsumption.FuelCard == null)
            {
                modelState.AddError(nameof(fuelConsumption.FuelCard), string.Format(ValidationErrors.RequiredField, nameof(fuelConsumption.FuelCard)));
            }
            if (fuelConsumption.Period == null)
            {
                modelState.AddError(nameof(fuelConsumption.Period), string.Format(ValidationErrors.RequiredField, nameof(fuelConsumption.Period)));
            }
            if (fuelConsumption.TotalAmountInEGP < 0)
            {
                modelState.AddError(nameof(fuelConsumption.TotalAmountInEGP), string.Format(ValidationErrors.InvalidAmount, fuelConsumption.TotalAmountInEGP));
            }
            if (fuelConsumption.TotalConsumedQuanityInLiteres <= 0)
            {
                modelState.AddError(nameof(fuelConsumption.TotalConsumedQuanityInLiteres), string.Format(ValidationErrors.InvalidQuantity, fuelConsumption.TotalConsumedQuanityInLiteres));
            }
            if (!string.IsNullOrEmpty(fuelConsumption.Notes) && fuelConsumption.Notes.Length > FuelConsumption.MaxFuelConsumptionNotesLength)
            {
                modelState.AddError(nameof(fuelConsumption.Notes), string.Format(ValidationErrors.TooLongFieldValue, nameof(fuelConsumption.Notes), FuelConsumption.MaxFuelConsumptionNotesLength));
            }
            return modelState;
        }
    }
}
