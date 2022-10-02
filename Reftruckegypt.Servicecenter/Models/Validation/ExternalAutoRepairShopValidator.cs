namespace Reftruckegypt.Servicecenter.Models.Validation
{
    
    
        public class ExternalAutoRepairShopValidator : IValidator<ExternalAutoRepairShop>
        {
            public ModelState Validate(ExternalAutoRepairShop shop)
            {
                ModelState modelState = new ModelState();
                if (string.IsNullOrEmpty(shop.Name))
                {
                    modelState.AddError(nameof(shop.Name), string.Format(ValidationErrors.RequiredField, nameof(shop.Name)));
                }
                else if(shop.Name.Length > ExternalAutoRepairShop.MaxNameLength)
                {
                    modelState.AddError(nameof(shop.Name), string.Format(ValidationErrors.TooLongFieldValue, nameof(shop.Name), ExternalAutoRepairShop.MaxNameLength));
                }
                if(!string.IsNullOrEmpty(shop.Address) && shop.Address.Length > ExternalAutoRepairShop.MaxAddressLength)
                {
                    modelState.AddError(nameof(shop.Address), string.Format(ValidationErrors.TooLongFieldValue, nameof(shop.Address), ExternalAutoRepairShop.MaxAddressLength));
                }
                if(!string.IsNullOrEmpty(shop.Phone) && shop.Phone.Length > ExternalAutoRepairShop.MaxPhoneLength)
                {
                    modelState.AddError(nameof(shop.Phone), string.Format(ValidationErrors.TooLongFieldValue, nameof(shop.Phone), ExternalAutoRepairShop.MaxPhoneLength));
                }
                return modelState;
            }
        }
    
}
