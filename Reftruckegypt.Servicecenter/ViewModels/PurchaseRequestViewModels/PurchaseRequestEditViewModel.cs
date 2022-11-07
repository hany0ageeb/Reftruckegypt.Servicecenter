using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels
{
    public class PurchaseRequestEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<PurchaseRequest> _purchaseRequestValidator;
        private readonly IValidator<PurchaseRequestLine> _purchaseRequestLineValidator;

        private int _selectedIndex = -1;
        public PurchaseRequestEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<PurchaseRequest> purchaseRequestValidator,
            IValidator<PurchaseRequestLine> purchaseRequestLineValidator)
            : this(null, unitOfWork, applicationContext, purchaseRequestValidator, purchaseRequestLineValidator)
        {
        }
            public PurchaseRequestEditViewModel(
            PurchaseRequest purchaseRequest,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<PurchaseRequest> purchaseRequestValidator,
            IValidator<PurchaseRequestLine> purchaseRequestLineValidator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _purchaseRequestValidator = purchaseRequestValidator ?? throw new ArgumentNullException(nameof(purchaseRequestValidator));
            _purchaseRequestLineValidator = purchaseRequestLineValidator ?? throw new ArgumentNullException(nameof(purchaseRequestLineValidator));

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(x => x.IsEnabled, q => q.OrderBy(t => t.Code)));
            Uoms.AddRange(_unitOfWork.UomRepository.Find(x => x.IsEnabled, q => q.OrderBy(t => t.Code)));

            if (purchaseRequest is null)
            {
                _purchaseRequest = new PurchaseRequest()
                {
                    RequestDate = DateTime.Now,
                    Id = Guid.Empty
                };
                if(Vehicles.Count > 0)
                {
                    _purchaseRequest.Vehicle = Vehicles[0];
                }
            }
            else
            {
                _purchaseRequest = new PurchaseRequest()
                {
                    Id = purchaseRequest.Id,
                    Number = purchaseRequest.Number,
                    Description = purchaseRequest.Description,
                    Period = purchaseRequest.Period,
                    //State = purchaseRequest.State,
                    Vehicle = purchaseRequest.Vehicle,
                    RequestDate = purchaseRequest.RequestDate
                };
                foreach(PurchaseRequestLine line in purchaseRequest.Lines)
                {
                    _purchaseRequest.Lines.Add(line);
                    Lines.Add(new PurchaseRequestLineEditViewModel(line)
                    {
                        Validator = _purchaseRequestLineValidator
                    });
                    if (!SpareParts.Contains(line.SparePart))
                    {
                        SpareParts.Add(line.SparePart);
                    }
                    if (!Uoms.Contains(line.Uom))
                    {
                        Uoms.Add(line.Uom);
                    }
                }
            }
            Lines.ListChanged += (o, e) =>
            {
                if(e.PropertyDescriptor?.Name != "HasChanged")
                {
                    HasChanged = true;
                }
                if(e.ListChangedType == ListChangedType.ItemAdded && e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                {
                    if (Lines.Count > 0)
                    {
                        if(SpareParts.Count > 0)
                        {
                            Lines[e.NewIndex].SparePart = SpareParts[0];
                            Lines[e.NewIndex].Uom = SpareParts[0].PrimaryUom;
                        }
                        Lines[e.NewIndex].RequestedQuantity = 1;
                    }
                }
                if (e.ListChangedType == ListChangedType.ItemChanged && e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                {
                    if(Lines[e.NewIndex].SparePart != null)
                        Lines[e.NewIndex].Uom = Lines[e.NewIndex].SparePart?.PrimaryUom;
                }
            };
            HasChanged = false;
        }
        private PurchaseRequest _purchaseRequest;

        private bool _hasChanged = false;
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
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged(this, nameof(CurrentLineSparePartName));
                }
            }
        }
        public string CurrentLineSparePartName
        {
            get
            {
                if(_selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    return Lines[_selectedIndex].SparePart?.Name ?? "";
                }
                return string.Empty;
            }
        }
        public string Number
        {
            get => _purchaseRequest.Number == 0 ? "" : _purchaseRequest.Number.ToString();
        }
        public DateTime RequestDate
        {
            get => _purchaseRequest.RequestDate;
            set
            {
                if (_purchaseRequest.RequestDate != value)
                {
                    _purchaseRequest.RequestDate = value;
                    OnPropertyChanged(this, nameof(RequestDate));
                    HasChanged = true;
                }
            }
        }
        public string Description
        {
            get => _purchaseRequest.Description;
            set
            {
                if(_purchaseRequest.Description != value)
                {
                    _purchaseRequest.Description = value;
                    OnPropertyChanged(this, nameof(Description));
                    HasChanged = true;
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _purchaseRequest.Vehicle;
            set
            {
                if (_purchaseRequest.Vehicle != value)
                {
                    _purchaseRequest.Vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
                    HasChanged = true;
                }
            }
        }
        public BindingList<PurchaseRequestLineEditViewModel> Lines { get; private set; } = new BindingList<PurchaseRequestLineEditViewModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            _purchaseRequest.Period = _unitOfWork.PeriodRepository.FindOpenPeriod(_purchaseRequest.RequestDate);
            if(_purchaseRequest.Period is null)
            {
                modelState.AddError(nameof(RequestDate), $"No Open Period For Date {_purchaseRequest.RequestDate}");
                return modelState;
            }
            modelState.AddErrors(_purchaseRequestValidator.Validate(_purchaseRequest));
            if (modelState.HasErrors)
                return modelState;
            foreach(var line in Lines)
            {
                modelState.AddErrors(line.Validate());
            }
            return modelState;
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                if (!Validate().HasErrors)
                {
                    if (_purchaseRequest.Id == Guid.Empty)
                    {
                        PurchaseRequest purchaseRequest = new PurchaseRequest()
                        {
                            Description = _purchaseRequest.Description,
                            RequestDate = _purchaseRequest.RequestDate,
                            Period = _purchaseRequest.Period,
                            Vehicle = _purchaseRequest.Vehicle,
                            //State = _purchaseRequest.State
                        };
                        foreach(var line in Lines)
                        {
                            purchaseRequest.Lines.Add(new PurchaseRequestLine()
                            {
                                Notes = line.Notes,
                                RequestedQuantity = line.RequestedQuantity,
                                SparePart = line.SparePart,
                                Uom = line.Uom
                            });
                        }
                        _unitOfWork.PurchaseRequestRepository.Add(purchaseRequest);
                        _unitOfWork.Complete();
                        _purchaseRequest.Number = purchaseRequest.Number;
                        OnPropertyChanged(this, nameof(Number));
                        HasChanged = false;
                        return true;
                    }
                    else
                    {
                        PurchaseRequest purchaseRequest = _unitOfWork.PurchaseRequestRepository.Find(key: _purchaseRequest.Id);
                        if (purchaseRequest != null)
                        {
                            purchaseRequest.Description = _purchaseRequest.Description;
                            purchaseRequest.Period = _purchaseRequest.Period;
                            purchaseRequest.RequestDate = _purchaseRequest.RequestDate;
                            //purchaseRequest.State = _purchaseRequest.State;
                            purchaseRequest.Vehicle = _purchaseRequest.Vehicle;
                            Guid purchaseRequestId = _purchaseRequest.Id;
                            List<Guid> guids = Lines.Select(x => x.Id).ToList();
                           
                            foreach(var line in Lines)
                            {
                                if(line.Id == Guid.Empty)
                                {
                                    purchaseRequest.Lines.Add(new PurchaseRequestLine()
                                    {
                                        Notes = line.Notes,
                                        RequestedQuantity = line.RequestedQuantity,
                                        SparePart = line.SparePart,
                                        Uom = line.Uom
                                    });
                                }
                                else
                                {
                                    var oldLine = _unitOfWork.PurchaseRequestLineRepository.Find(key: line.Id);
                                    if (oldLine != null)
                                    {
                                        oldLine.Notes = line.Notes;
                                        oldLine.RequestedQuantity = line.RequestedQuantity;
                                        oldLine.SparePart = line.SparePart;
                                        oldLine.Uom = line.Uom;
                                    }
                                }
                            }
                            var deletedLines = _unitOfWork.PurchaseRequestLineRepository.Find(x => x.PurchaseRequestId == purchaseRequestId && !guids.Contains(x.Id)).ToList();
                            _unitOfWork.PurchaseRequestLineRepository.Remove(deletedLines);
                            _unitOfWork.Complete();
                            HasChanged = false;
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result =
                    _applicationContext.DisplayMessage("Confirm save", "Do You Want To Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    return SaveOrUpdate();
                }
                else if(result == DialogResult.No)
                {
                    HasChanged = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
    }
}
