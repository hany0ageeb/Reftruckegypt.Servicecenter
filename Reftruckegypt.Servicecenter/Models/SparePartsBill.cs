﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Reftruckegypt.Servicecenter.Models
{
    public class SparePartsBill : EntityBase
    {
        public long Number { get; set; }
        public DateTime BillDate { get; set; } = DateTime.Now;
        public virtual Vehicle Vehicle { get; set; }
        public virtual Period Period { get; set; }
        public string Repairs { get; set; }
        public virtual IList<SparePartsBillLine> Lines { get; set; } = new List<SparePartsBillLine>();
        public Guid VehicleId { get; set; }
        public Guid PeriodId { get; set; }
        public decimal TotalAmount => Lines.Sum(e => e.TotalAmount);
        public const int MaxRepairsLength = 500;

    }
}
