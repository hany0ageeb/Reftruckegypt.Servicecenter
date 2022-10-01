using System;
using System.ComponentModel.DataAnnotations;

namespace Reftruckegypt.Servicecenter.Models
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
