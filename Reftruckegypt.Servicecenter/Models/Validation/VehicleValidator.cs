using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class VehicleValidator : IValidator<Vehicle>
    {
        public ModelState Validate(Vehicle entity)
        {
            ModelState modelState = new ModelState();
            if(entity.VehicleCategory is null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.VehicleCategory),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Vehicle Category"));
            }
            else
            {
                if(entity.VehicleCategory.IsChassisNumberRequired && string.IsNullOrEmpty(entity.ChassisNumber))
                {
                    modelState.AddError(
                        propertyName: nameof(entity.ChassisNumber),
                        errorMessage: string.Format(ValidationErrors.RequiredField, "Chassis")
                        );
                }
            }
            if(entity.VehicleModel is null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.VehicleModel),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Vehicle Model"));
            }
            if (string.IsNullOrEmpty(entity.InternalCode))
            {
                modelState.AddError(
                    propertyName: nameof(entity.InternalCode),
                    errorMessage: string.Format(ValidationErrors.RequiredField, "Internal Code"));
            }
            else if(entity.InternalCode.Length > Vehicle.MaxInternalCodeLength)
            {
                modelState.AddError(
                    propertyName: nameof(entity.InternalCode),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Internal Code", Vehicle.MaxInternalCodeLength));
            }
            if(!string.IsNullOrEmpty(entity.ChassisNumber) && entity.ChassisNumber.Length > Vehicle.MaxChassisNumberLength)
            {
                modelState.AddError(
                    propertyName: nameof(entity.ChassisNumber),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Chassis", Vehicle.MaxInternalCodeLength));
            }
            if (!string.IsNullOrEmpty(entity.VehicleCode) && entity.ChassisNumber.Length > Vehicle.MaxVehicelCodeLength)
            {
                modelState.AddError(
                    propertyName: nameof(entity.VehicleCode),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue, "Vehicel Code", Vehicle.MaxVehicelCodeLength));
            }
            if (string.IsNullOrEmpty(entity.WorkingState))
            {
                modelState.AddError(
                   propertyName: nameof(entity.WorkingState),
                   errorMessage: string.Format(ValidationErrors.RequiredField, "Working State"));
            }
            else if (!VehicleStates.IsValidState(entity.WorkingState))
            {
                modelState.AddError(
                   propertyName: nameof(entity.WorkingState),
                   errorMessage: $"{entity.WorkingState} is not a valid Working state Value.");
            }
            return modelState;
        }
    }
}
