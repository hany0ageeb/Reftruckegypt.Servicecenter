using System.Linq;
namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public class SparePartsPriceListValidator : IValidator<SparePartsPriceList>
    {
        public ModelState Validate(SparePartsPriceList entity)
        {
            ModelState modelState = new ModelState();
            if(!string.IsNullOrEmpty(entity.Name) && entity.Name.Length > SparePartsPriceList.MaxPriceListNameLength)
            {
                modelState.AddError(
                    propertyName: nameof(entity.Name),
                    errorMessage: string.Format(ValidationErrors.TooLongFieldValue,nameof(entity.Name), SparePartsPriceList.MaxPriceListNameLength)
                    );
            }
            if(entity.Period == null)
            {
                modelState.AddError(
                    propertyName: nameof(entity.Period),
                    errorMessage:string.Format(ValidationErrors.RequiredField, $"Field: {nameof(entity.Period)} is required."));
            }
            if(entity.Lines.GroupBy(x=>x.SparePart).Where(g=>g.Count() > 1).Count() > 0)
            {
                modelState.AddError(nameof(entity.Lines), $"Duplicate Spare Part in the List.");
            }
            return modelState;
        }
    }
}
