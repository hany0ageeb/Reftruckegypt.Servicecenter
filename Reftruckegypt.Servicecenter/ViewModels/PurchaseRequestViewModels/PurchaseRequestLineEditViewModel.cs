using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels
{
    public class PurchaseRequestLineEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private PurchaseRequestLine _line;
        private bool _hasChanged = false;
        public PurchaseRequestLineEditViewModel()
        {
            _line = new PurchaseRequestLine()
            {
                Id = Guid.Empty
            };
        }
        public PurchaseRequestLineEditViewModel(PurchaseRequestLine line)
        {
            _line = new PurchaseRequestLine()
            {
                Notes = line.Notes,
                PurchaseRequest = line.PurchaseRequest,
                RequestedQuantity = line.RequestedQuantity,
                SparePart = line.SparePart,
                Uom = line.Uom,
                Id = line.Id
            };
        }
        public bool HasChanged
        {
            get => _hasChanged;
            private set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public IValidator<PurchaseRequestLine> Validator { get; set; }
        public Guid Id => _line.Id;
        public SparePart SparePart
        {
            get => _line.SparePart;
            set
            {
                if (_line.SparePart != value)
                {
                    _line.SparePart = value;
                    OnPropertyChanged(this, nameof(SparePart));
                    HasChanged = true;
                }
            }
        }
        public Uom Uom
        {
            get => _line.Uom;
            set
            {
                if (_line.Uom != value)
                {
                    _line.Uom = value;
                    OnPropertyChanged(this, nameof(Uom));
                    HasChanged = true;
                }
            }
        }
        public decimal RequestedQuantity
        {
            get => _line.RequestedQuantity;
            set
            {
                if (_line.RequestedQuantity != value)
                {
                    _line.RequestedQuantity = value;
                    OnPropertyChanged(this, nameof(RequestedQuantity));
                    HasChanged = true;
                }
            }
        }
        public string Notes
        {
            get => _line.Notes;
            set
            {
                if (_line.Notes != value)
                {
                    _line.Notes = value;
                    OnPropertyChanged(this, nameof(Notes));
                    HasChanged = true;
                }
            }
        }
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            if (Validator != null)
            {
                modelState.AddErrors(Validator.Validate(_line));
            }
            return modelState;
        }
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
    }
}
