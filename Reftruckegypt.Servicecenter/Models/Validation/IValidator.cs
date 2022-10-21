using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Models.Validation
{
    public interface IValidator<TEntity>
    {
        ModelState Validate(TEntity entity);
    }
    public class PurchaseRequestValidator : IValidator<PurchaseRequest>
    {
        public ModelState Validate(PurchaseRequest entity)
        {
            ModelState modelState = new ModelState();
            if(entity.Period == null)
            {
                modelState.AddError(nameof(entity.Period), string.Format(ValidationErrors.RequiredField, nameof(entity.Period)));
            }
            if(entity.Vehicle == null)
            {
                modelState.AddError(nameof(entity.Vehicle), string.Format(ValidationErrors.RequiredField, nameof(entity.Vehicle)));
            }
            if (string.IsNullOrEmpty(entity.State))
            {
                modelState.AddError(nameof(entity.State), string.Format(ValidationErrors.RequiredField, nameof(entity.State)));
            }
            else if(entity.State.Length > PurchaseRequest.MaxStateLength)
            {
                modelState.AddError(nameof(entity.State), string.Format(ValidationErrors.TooLongFieldValue, nameof(entity.Period), PurchaseRequest.MaxStateLength));
            }
            return modelState;
        }
    }
    public class PurchaseRequestLineValidator : IValidator<PurchaseRequestLine>
    {
        public ModelState Validate(PurchaseRequestLine entity)
        {
            throw new NotImplementedException();
        }
    }
    public class ReceiptLineValidator : IValidator<ReceiptLine>
    {
        public ModelState Validate(ReceiptLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
