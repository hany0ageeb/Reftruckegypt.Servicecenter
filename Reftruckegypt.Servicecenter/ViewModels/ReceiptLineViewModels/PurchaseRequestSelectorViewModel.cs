using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels
{
    public class PurchaseRequestSelectorViewModel : ViewModelBase
    {
        private bool _isSelected;
        private long _number;
        private DateTime _date;
        private string _vehicleInternalCode;
        public PurchaseRequestSelectorViewModel(PurchaseRequest purchaseRequest)
        {
            RequestId = purchaseRequest.Id;
            _vehicleInternalCode = purchaseRequest.Vehicle?.InternalCode;
            _date = purchaseRequest.RequestDate;
            _number = purchaseRequest.Number;
            _isSelected = false;
        }
        public Guid RequestId { get; private set; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(this, nameof(IsSelected));
                }
            }
        }
        public long Number
        {
            get => _number;
            private set
            {
                _number = value;
            }
        }
        public DateTime RequestDate
        {
            get => _date;
            private set
            {
                if (_date != value)
                {
                    _date = value;
                }
            }
        }
        public string VehicleInternalCode
        {
            get => _vehicleInternalCode;
            private set
            {
                _vehicleInternalCode = value;
            }
        }
    }
}
