using System;
using System.Linq;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Models
{
    public class PurchaseRequest : EntityBase
    {
        private string _state = PurchaseRequestStates.Approved;
        public long Number { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public virtual Period Period { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public string State 
        {
            get
            {
                if (Lines.All(x=>x.ReceiptLines.Count == 0))
                {
                    _state = PurchaseRequestStates.Approved;
                }
                else if(Lines.Any(x => x.ReceiptLines.Count > 0 && x.RequestedQuantity > x.ReceiptLines.Sum(y => y.ReceivedQuantity)))
                {
                    _state = PurchaseRequestStates.PartiallyReceived;
                }
                else if(Lines.All(x=>x.RequestedQuantity <= x.ReceiptLines.Sum(y => y.ReceivedQuantity)))
                {
                    _state = PurchaseRequestStates.FullyReceived;
                }
                else
                {
                    _state = PurchaseRequestStates.Approved;
                }
                return _state;
            }
            private set
            {
                _state = value;
            }
        }  
        public Guid PeriodId { get; set; }
        public Guid VehicleId { get; set; }
        public virtual ICollection<PurchaseRequestLine> Lines { get; set; } = new HashSet<PurchaseRequestLine>();

        public const int MaxDescriptionLength = 500;
        public const int MaxStateLength = 50;

        public PurchaseRequest Self => this;
        public static readonly PurchaseRequest empty = new PurchaseRequest() { Id = Guid.Empty, Number = -1, Description = "" };
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
