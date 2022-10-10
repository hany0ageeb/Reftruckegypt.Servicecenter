using System;
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
}
