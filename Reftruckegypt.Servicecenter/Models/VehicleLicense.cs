﻿using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class VehicleLicense : EntityBase
    {
        public string MotorNumber { get; set; }
        public string PlateNumber { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public virtual Vehicle Vehicel { get; set; }
        public Guid VehicleId { get; set; }
        public string Notes { get; set; }
        public string TrafficDepartmentName { get; set; }
    }
}
