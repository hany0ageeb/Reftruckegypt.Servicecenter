using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public abstract class EntityBase
    {
        [Key]
        [Npoi.Mapper.Attributes.Ignore()]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Timestamp]
        [Npoi.Mapper.Attributes.Ignore()]
        public byte[] RowVersion { get; set; }
    }
    public class PurchaseRequest : EntityBase
    {
        public long Number { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public virtual Period Period { get; set; }
        public Guid PeriodId { get; set; }
        public virtual ICollection<PurchaseRequestLine> Lines { get; set; } = new HashSet<PurchaseRequestLine>();
    }
    
    public class PurchaseRequestLine : EntityBase
    {
        public virtual SparePart SparePart { get; set; }
        public virtual Uom Uom { get; set; }
        public decimal RequestedQuantity { get; set; }
        public string Notes { get; set; }
    }
}
