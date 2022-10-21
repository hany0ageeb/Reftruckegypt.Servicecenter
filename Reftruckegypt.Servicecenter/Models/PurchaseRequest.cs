using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class PurchaseRequest : EntityBase
    {
        public long Number { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public virtual Period Period { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public string State { get; set; } = PurchaseRequestStates.Approved;
        public Guid PeriodId { get; set; }
        public Guid VehicleId { get; set; }
        public virtual ICollection<PurchaseRequestLine> Lines { get; set; } = new HashSet<PurchaseRequestLine>();

        public const int MaxDescriptionLength = 500;
        public const int MaxStateLength = 50;
    }
    public static class PurchaseRequestStates
    {
        public const string Approved = "Approved";
        public const string PartiallyReceived = "Partially Received";
        public const string FullyReceived = "Fully Received";

        public static string[] AllStates = { Approved , PartiallyReceived , FullyReceived };
        public static bool IsValidState(string state)
        {
            return AllStates.Contains(state);
        }
    }
}
