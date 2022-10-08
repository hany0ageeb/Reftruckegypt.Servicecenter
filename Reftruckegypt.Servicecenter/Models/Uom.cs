using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Uom : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
        public virtual ICollection<UomConversion> FromUomConversions { get; set; } = new HashSet<UomConversion>();
        public virtual ICollection<UomConversion> ToUomConversions { get; set; } = new HashSet<UomConversion>();
        public Uom Self => this;

        public const int CodeMaxLength = 8;
        public const int NameMaxLength = 250;
        public decimal? Convert(Uom toUom, decimal quantity = 1, SparePart sparePart = null)
        {
            if (sparePart == null || sparePart.Id == System.Guid.Empty) 
            {
                UomConversion conversion = FromUomConversions.Where(x => x.ToUomId == toUom.Id && x.SparePartId == null).FirstOrDefault();
                if(conversion != null)
                {
                    return quantity * conversion.Rate;
                }
                else
                {
                    conversion = ToUomConversions.Where(x => x.FromUomId == toUom.Id).FirstOrDefault();
                    if (conversion != null)
                    {
                        return quantity * (1.0M / conversion.Rate);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                UomConversion conversion = FromUomConversions.Where(x => x.ToUomId == toUom.Id && x.SparePartId == sparePart.Id).FirstOrDefault();
                if(conversion != null)
                {
                    return quantity * conversion.Rate;
                }
                else
                {
                    conversion = ToUomConversions.Where(x => x.FromUomId == toUom.Id && x.SparePartId == sparePart.Id).FirstOrDefault();
                    if (conversion != null)
                    {
                        return quantity * (1.0M / conversion.Rate);
                    }
                    else
                    {
                        conversion = FromUomConversions.Where(x => x.ToUomId == toUom.Id && x.SparePartId == null).FirstOrDefault();
                        if (conversion != null)
                        {
                            return quantity * conversion.Rate;
                        }
                        else
                        {
                            conversion = ToUomConversions.Where(x => x.FromUomId == toUom.Id).FirstOrDefault();
                            if (conversion != null)
                            {
                                return quantity * (1.0M / conversion.Rate);
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
        }
    }
}
