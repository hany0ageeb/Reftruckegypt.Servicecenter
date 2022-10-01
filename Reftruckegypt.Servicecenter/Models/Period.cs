using System;

namespace Reftruckegypt.Servicecenter.Models
{
    public class Period : EntityBase
    {
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string State { get; set; } = PeriodStates.OpenState;
    }
    public static class PeriodStates
    {
        public static string OpenState = "Open";
        public static string ClosedState = "Closed";
    }
}
