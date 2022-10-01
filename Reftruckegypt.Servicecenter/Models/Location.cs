using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Location : EntityBase
    {
        public string Name { get; set; }
        public string AddressLine { get; set; }
    }
}
