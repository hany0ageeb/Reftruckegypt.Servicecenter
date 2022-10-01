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
}
