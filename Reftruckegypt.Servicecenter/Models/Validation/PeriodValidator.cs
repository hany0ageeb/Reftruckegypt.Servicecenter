namespace Reftruckegypt.Servicecenter.Models.Validation
{
    
        public class PeriodValidator : IValidator<Period>
        {
            public ModelState Validate(Period period)
            {
                ModelState modelState = new ModelState();
                if (string.IsNullOrEmpty(period.Name))
                {
                    modelState.AddError(nameof(period.Name), string.Format(ValidationErrors.RequiredField, nameof(period.Name)));
                }
                else if(period.Name.Length > Period.MaxPeriodNameLength)
                {
                    modelState.AddError(nameof(period.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(period.Name), Period.MaxPeriodNameLength));
                }
                if (string.IsNullOrEmpty(period.State))
                {
                    modelState.AddError(nameof(period.State), string.Format(ValidationErrors.RequiredField, nameof(period.State)));
                }
                else if (period.State.Length > Period.MaxPeriodStateLength)
                {
                    modelState.AddError(nameof(period.State), string.Format(ValidationErrors.TooLongFieldValue, nameof(period.State), Period.MaxPeriodStateLength));
                }
                else if (!PeriodStates.IsValidState(period.State))
                {
                    modelState.AddError(nameof(period.State), string.Format(ValidationErrors.InvalidPeriodStateValue, period.State, PeriodStates.OpenState, PeriodStates.ClosedState));
                }
                return modelState;
            }
        }
}
