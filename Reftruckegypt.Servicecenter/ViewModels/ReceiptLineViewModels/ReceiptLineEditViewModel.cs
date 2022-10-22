using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels
{
    public class ReceiptLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private bool _isSelected = false;
        private decimal _receivedQuantity;
        
        private PurchaseRequestLine _purchaseRequestLine;
        public Guid Id { get; private set; }
        public ReceiptLineEditViewModel() { Id = Guid.Empty; }
        public ReceiptLineEditViewModel(PurchaseRequestLine line)
        {
            Id = Guid.Empty;
            _purchaseRequestLine = line;
            if (_purchaseRequestLine != null)
                _receivedQuantity = _purchaseRequestLine.RequestedQuantity;
        }
        public ReceiptLineEditViewModel(ReceiptLine receiptLine)
        {
            _purchaseRequestLine = receiptLine.PurchaseRequestLine;
            _receivedQuantity = receiptLine.ReceivedQuantity;
            _isSelected = true;
            Id = receiptLine.Id;
            ReceiptDate = receiptLine.ReceiptDate;
            Period = receiptLine.Period;
        }
        public PurchaseRequestLine PurchaseRequestLine 
        { 
            get => _purchaseRequestLine;
            set
            {
                if(_purchaseRequestLine != value)
                {
                    _purchaseRequestLine = value;
                    OnPropertyChanged(this, nameof(PurchaseRequestLine));
                }
            }
        }
        public IValidator<ReceiptLine> Validator { get; set; }
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
        public decimal ReceivedQuantity
        {
            get => _receivedQuantity;
            set
            {
                if(_receivedQuantity != value)
                {
                    _receivedQuantity = value;
                    OnPropertyChanged(this, nameof(ReceivedQuantity));
                    if (!_isSelected)
                    {
                        IsSelected = true;
                    }
                }
            }
        }
        public string SparePartCode => _purchaseRequestLine?.SparePart?.Code;
        public string SparePartName => _purchaseRequestLine?.SparePart?.Name;
        public string SparePartUomCode => _purchaseRequestLine?.Uom?.Code;
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public Period Period { get; set; }
        public ModelState Validate()
        {
            
            if (Validator is null || !_isSelected)
                return new ModelState();
            return Validator.Validate(ReceiptLine);
        }
        public ReceiptLine ReceiptLine
        {
            get
            {
                if (_isSelected)
                {
                    return new ReceiptLine()
                    {
                        Id = Id,
                        PurchaseRequestLine = _purchaseRequestLine,
                        ReceivedQuantity = _receivedQuantity,
                        SparePart = _purchaseRequestLine?.SparePart,
                        Uom = _purchaseRequestLine.Uom,
                        ReceiptDate = ReceiptDate,
                        Period = Period
                    };
                }
                else
                {
                    return null;
                }
            }
        }
        public string this[string columnName] => Validate()[columnName];

        public string Error => Validate().Error;
    }
}
