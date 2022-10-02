namespace Reftruckegypt.Servicecenter.Models.Validation
{
    
        public class ExternalRepairBillValidator : IValidator<ExternalRepairBill>
        {
            public ModelState Validate(ExternalRepairBill externalRepairBill)
            {
                ModelState modelState = new ModelState();
                if (externalRepairBill.ExternalAutoRepairShop == null)
                {
                    modelState.AddError(nameof(externalRepairBill.ExternalAutoRepairShop), string.Format(ValidationErrors.RequiredField, nameof(externalRepairBill.ExternalAutoRepairShop)));
                }
                if (externalRepairBill.Period == null)
                {
                    modelState.AddError(nameof(externalRepairBill.Period), string.Format(ValidationErrors.RequiredField, nameof(externalRepairBill.Period)));
                }
                if(externalRepairBill.Vehicle == null)
                {
                    modelState.AddError(nameof(externalRepairBill.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(externalRepairBill.Vehicle)));
                }
                if(externalRepairBill.TotalAmountInEGP < 0)
                {
                    modelState.AddError(nameof(externalRepairBill.TotalAmountInEGP), string.Format(ValidationErrors.InvalidAmount, externalRepairBill.TotalAmountInEGP));
                }
                if(!string.IsNullOrEmpty(externalRepairBill.Repairs) && externalRepairBill.Repairs.Length > ExternalRepairBill.MaxRepairsLength)
                {
                    modelState.AddError(nameof(externalRepairBill.Repairs), string.Format(ValidationErrors.TooLongFieldValue,nameof(externalRepairBill.Repairs), ExternalRepairBill.MaxRepairsLength));
                }
                if(!string.IsNullOrEmpty(externalRepairBill.SupplierBillNumber) && externalRepairBill.SupplierBillNumber.Length > 50)
                {
                    modelState.AddError(nameof(externalRepairBill.SupplierBillNumber), string.Format(ValidationErrors.TooLongFieldValue, nameof(externalRepairBill.SupplierBillNumber), ExternalRepairBill.MaxSupplierBillNumberLength));
                }
                if (!string.IsNullOrEmpty(externalRepairBill.BillImageFilePath) && externalRepairBill.BillImageFilePath.Length > ExternalRepairBill.MaxBillImageFilePathLength)
                {
                    modelState.AddError(nameof(externalRepairBill.BillImageFilePath), string.Format(ValidationErrors.TooLongFieldValue, nameof(externalRepairBill.BillImageFilePath), ExternalRepairBill.MaxBillImageFilePathLength));
                }
                return modelState;
            }
        }
}
