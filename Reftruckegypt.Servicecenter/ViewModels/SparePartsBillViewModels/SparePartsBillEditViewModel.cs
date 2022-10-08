using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels
{
    public class SparePartsBillEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _number;
        private DateTime _date;
        private Vehicle _vehicle;
        private Period _period;
        private string _repairs;
        private bool _hasChanged = false;
        private IValidator<SparePartsBillLine> _lineValidator;
        private readonly IUnitOfWork _untiOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<SparePartsBill> _billValidator;

        private List<SparePartsBillLineEditViewModel> deletedLines = new List<SparePartsBillLineEditViewModel>();
        public SparePartsBillEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<SparePartsBill> billValidator,
            IValidator<SparePartsBillLine> lineValidator)
            : this(null, unitOfWork, applicationContext, billValidator, lineValidator)
        {
        }
            public SparePartsBillEditViewModel(
            SparePartsBill bill,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<SparePartsBill> billValidator,
            IValidator<SparePartsBillLine> lineValidator)
        {
            if (unitOfWork is null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _untiOfWork = unitOfWork;
            if (applicationContext is null)
            {
                throw new ArgumentNullException(nameof(applicationContext));
            }
            _applicationContext = applicationContext;
            _billValidator = billValidator ?? throw new ArgumentNullException(nameof(billValidator));
            _lineValidator = lineValidator ?? throw new ArgumentNullException(nameof(lineValidator));

            Vehicles.AddRange(_untiOfWork.VehicleRepository.Find(orderBy: q => q.OrderBy(x => x.InternalCode)));
            SpareParts.AddRange(_untiOfWork.SparePartRepository.Find(predicate: x => x.IsEnabled, orderBy: q => q.OrderBy(x => x.Code)));
            Uoms.AddRange(_untiOfWork.UomRepository.Find(x => x.IsEnabled, q => q.OrderBy(x => x.Code)));
            if (bill != null)
            {
                Id = bill.Id;
                BillDate = bill.BillDate;
                Number = bill.Number.ToString();
                Repairs = bill.Repairs;
                _period = bill.Period;
                foreach (var line in bill.Lines)
                {
                    Lines.Add(new SparePartsBillLineEditViewModel(line));
                    if (!SpareParts.Contains(line.SparePart))
                    {
                        SpareParts.Add(line.SparePart);
                    }
                    if (!Uoms.Contains(line.Uom))
                    {
                        Uoms.Add(line.Uom);
                    }
                }
                Vehicle = bill.Vehicle;
            }
            else
            {
                Id = Guid.Empty;
                BillDate = DateTime.Now;
                if (Vehicles.Count > 0)
                    Vehicle = Vehicles[0];
            }
            Lines.ListChanged += (o, e) =>
            {
                HasChanged = true;
                if (e.ListChangedType == ListChangedType.ItemAdded)
                {
                    if (e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                    {
                        Lines[e.NewIndex].Validator = _lineValidator;
                        // .....
                        if (SpareParts.Count > 0)
                        {
                            Lines[e.NewIndex].SparePart = SpareParts[0];
                            Lines[e.NewIndex].Uom = SpareParts[0].PrimaryUom;
                        }
                    }
                }
                if(e.ListChangedType == ListChangedType.ItemDeleted)
                {
                    if (e.NewIndex >= 0 && e.NewIndex < Lines.Count && Lines[e.NewIndex].Id != Guid.Empty)
                    {
                        deletedLines.Add(Lines[e.NewIndex]);
                    }
                }
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
        public Guid Id { get; private set; }
        public string Number
        {
            get => _number;
            private set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(this, nameof(Number));
                }
            }
        }
        public DateTime BillDate
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(this, nameof(BillDate));
                    HasChanged = true;
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if (_vehicle != value)
                {
                    _vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
                    HasChanged = true;
                }
            }
        }
        public string Repairs
        {
            get => _repairs;
            set
            {
                if (_repairs != value)
                {
                    _repairs = value;
                    OnPropertyChanged(this, nameof(Repairs));
                    HasChanged = true;
                }
            }
        }
        public SparePartsBill SparePartsBill => new SparePartsBill()
        {
            Id = Id,
            BillDate = _date,
            Vehicle = _vehicle,
            Period = _period,
            Repairs = _repairs,
            Lines = Lines.Select(l => l.SparePartsBillLine).ToList()
        };
        private decimal FindSparePartUnitPrice(SparePartsBillLineEditViewModel line)
        {
            SparePartsPriceList priceList = _untiOfWork
                .SparePartsPriceListRepository
                .Find(x => x.Period.Id == _period.Id).FirstOrDefault();
            if (priceList == null)
                return 0;
            return priceList.FindUnitPrice(line.SparePart, line.Uom) ?? 0;
        }
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            Period period = _untiOfWork.PeriodRepository.FindOpenPeriod(_date);
            if (period == null)
            {
                modelState.AddError(
                    propertyName: nameof(BillDate),
                    errorMessage: $"No Open Period For Date: {_date}. Please Select another Date or create / open a period for that date.");
                return modelState;
            }
            else
            {
                _period = period;
                modelState.AddErrors(_billValidator.Validate(SparePartsBill));
                if (!modelState.HasErrors)
                {
                    foreach(var line in Lines)
                    {
                        line.UnitPrice = FindSparePartUnitPrice(line);
                        if (line.Uom.Id == line.SparePart.PrimaryUom.Id)
                            line.UomConversionRate = null;
                        else
                        {
                            line.UomConversionRate = _untiOfWork.UomConversionRepository.FindUomConversionRate(line.Uom.Id, line.SparePart.PrimaryUom.Id, line.SparePart.Id);
                            if(line.UomConversionRate == null)
                            {
                                modelState.AddError(
                                    propertyName: nameof(Number),
                                    errorMessage: $"No Conversion Exists Between Uom {line.Uom.Code} and {line.SparePart.PrimaryUom.Code} .");
                            }
                        }
                        ModelState temp = line.Validate(true);
                        if (temp.HasErrors)
                        {
                            modelState.AddErrors(temp);
                            return modelState;
                        }
                    }
                }
            }
            return modelState;
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                ModelState modelState = Validate();
                if (modelState.HasErrors)
                {
                    return false;
                }
                if(Id == Guid.Empty)
                {
                    SparePartsBill sparePartsBill = SparePartsBill;
                    sparePartsBill.Id = Guid.NewGuid();
                    foreach (var line in sparePartsBill.Lines)
                        line.Id = Guid.NewGuid();
                    _untiOfWork.SparePartsBillRepository.Add(sparePartsBill);
                    _untiOfWork.Complete();
                    Number = sparePartsBill.Number.ToString();
                }
                else
                {
                    var oldBill = _untiOfWork.SparePartsBillRepository.Find(key: Id);
                    if (oldBill != null)
                    {
                        oldBill.BillDate = _date;
                        oldBill.Period = _period;
                        oldBill.Repairs = _repairs;
                        oldBill.Vehicle = _vehicle;
                        foreach(var line in deletedLines)
                        {
                            oldBill.Lines.Remove(oldBill.Lines.Where(l => l.Id == line.Id).FirstOrDefault());
                        }
                        foreach(var line in Lines)
                        {
                            if (line.Id == Guid.Empty)
                            {
                                oldBill.Lines.Add(
                                    new SparePartsBillLine()
                                    {
                                        SparePart = line.SparePart,
                                        Notes = line.Notes,
                                        Quantity = line.Quantity,
                                        UnitPrice = line.UnitPrice,
                                        Uom = line.Uom,
                                        UomConversionRate = line.UomConversionRate
                                    }
                                );
                            }
                            else
                            {
                                var oldLine = oldBill.Lines.Where(l => l.Id == line.Id).FirstOrDefault();
                                oldLine.Notes = line.Notes;
                                oldLine.SparePart = line.SparePart;
                                oldLine.Quantity = line.Quantity;
                                oldLine.UnitPrice = line.UnitPrice;
                                oldLine.Uom = line.Uom;
                                oldLine.UomConversionRate = line.UomConversionRate;
                            }
                        }
                        _ = _untiOfWork.Complete();
                    }
                }
                HasChanged = false;
                return true;
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confirm Save",
                    message: "Do You Want To Save Changes?",
                    buttons: MessageBoxButtons.YesNoCancel,
                    icon: MessageBoxIcon.Question
                    );
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
        
        public BindingList<SparePartsBillLineEditViewModel> Lines { get; private set; } = new BindingList<SparePartsBillLineEditViewModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        #region IDataErrorInfo
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        #endregion IDataErrorInfo
    }
}
