namespace Reftruckegypt.Servicecenter.Models.Validation
{
    
        public class FuelCardValidator : IValidator<FuelCard>
        {
            public ModelState Validate(FuelCard fuelCard)
            {
                ModelState modelState = new ModelState();
                if (string.IsNullOrEmpty(fuelCard.Number))
                {
                    modelState.AddError(nameof(fuelCard.Number), string.Format(ValidationErrors.RequiredField, nameof(fuelCard.Number)));
                }
                else if(fuelCard.Number.Length > FuelCard.MaxFuelCardNumberLength)
                {
                    modelState.AddError(nameof(fuelCard.Number), string.Format(ValidationErrors.TooLongFieldValue, nameof(fuelCard.Number), FuelCard.MaxFuelCardNumberLength));
                }
                if (string.IsNullOrEmpty(fuelCard.Name))
                {
                    modelState.AddError(nameof(fuelCard.Name), string.Format(ValidationErrors.RequiredField, nameof(fuelCard.Name)));
                }
                else if (fuelCard.Name.Length > FuelCard.MaxFuelCardNameLength)
                {
                    modelState.AddError(nameof(fuelCard.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(fuelCard.Name), FuelCard.MaxFuelCardNameLength));
                }
                if(!string.IsNullOrEmpty(fuelCard.Registration) && fuelCard.Registration.Length > FuelCard.MaxFuelCardRegistrationLength)
                {
                    modelState.AddError(nameof(fuelCard.Registration), string.Format(ValidationErrors.TooLongFieldValue, nameof(fuelCard.Registration), FuelCard.MaxFuelCardRegistrationLength));
                }
                return modelState;
            }
        }
}
