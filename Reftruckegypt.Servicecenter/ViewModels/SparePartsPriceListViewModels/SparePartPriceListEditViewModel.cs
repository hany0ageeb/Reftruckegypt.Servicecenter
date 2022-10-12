using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels
{
    public class SparePartPriceListEditViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IValidator<SparePartsPriceList> _priceListValidator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<SparePartPriceListLine> _lineValidator;

        private string _number;
        private string _name;
        private Period _period;

        private bool _hasChanged = false;

        public SparePartPriceListEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<SparePartsPriceList> listValidator,
            IValidator<SparePartPriceListLine> lineValidator)
            : this(null, unitOfWork, applicationContext, listValidator, lineValidator)
        { }
        public SparePartPriceListEditViewModel(
            SparePartsPriceList list,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<SparePartsPriceList> listValidator,
            IValidator<SparePartPriceListLine> lineValidator)
        {
            if (unitOfWork is null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
            if (applicationContext is null)
            {
                throw new ArgumentNullException(nameof(applicationContext));
            }
            _applicationContext = applicationContext;
            if (listValidator is null)
            {
                throw new ArgumentNullException(nameof(listValidator));
            }
            _priceListValidator = listValidator;
            if (lineValidator is null)
            {
                throw new ArgumentNullException(nameof(lineValidator));
            }
            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(e => e.IsEnabled, q=>q.OrderBy(x => x.Code)));
            Periods.AddRange(_unitOfWork.PeriodRepository.Find(x => x.State == PeriodStates.OpenState && x.SparePartsPriceList == null, orderBy: q => q.OrderBy(x => x.FromDate)));
            Uoms.AddRange(_unitOfWork.UomRepository.Find(x=>x.IsEnabled, q=>q.OrderBy(x=>x.Code)));
            _lineValidator = lineValidator;
            if (list != null)
            {
                _number = list.Number.ToString();
                _name = list.Name;
                _period = list.Period;
                originalLines.AddRange(list.Lines);
                foreach (var line in list.Lines)
                {
                    Lines.Add(new SparePartPriceListLineEditViewModel(line)
                    {
                        Validator = _lineValidator,
                        UnitOfWork = _unitOfWork
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
                if (!Periods.Contains(_period))
                {
                    Periods.Insert(0, _period);
                }
                Id = list.Id;
            }
            else
            {
                Id = Guid.Empty;
                if(Periods.Count > 0)
                    _period = Periods[0];
                
            }
            Lines.ListChanged += (o, e) =>
             {
                 if(e.PropertyDescriptor?.Name != "HasChanged")
                    HasChanged = true;
                 if (e.ListChangedType == ListChangedType.ItemAdded && e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                 {
                     Lines[e.NewIndex].Validator = _lineValidator;
                     Lines[e.NewIndex].UnitOfWork = _unitOfWork;
                     // ... Defaults
                     if(SpareParts.Count > 0)
                     {
                         Lines[e.NewIndex].SparePart = SpareParts[0];
                         Lines[e.NewIndex].Uom = SpareParts[0].PrimaryUom;
                     }
                     Lines[e.NewIndex].UnitPrice = 1;
                 }
                 if(e.ListChangedType == ListChangedType.ItemChanged && e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                 {
                     if(e.PropertyDescriptor?.Name == nameof(SparePartPriceListLineEditViewModel.SparePart) || e.PropertyDescriptor?.Name == nameof(SparePartPriceListLineEditViewModel.Uom))
                     {
                         if(Lines[e.NewIndex].SparePart!=null && Lines[e.NewIndex].Uom!=null)
                            Lines[e.NewIndex].UomConversionRate = _unitOfWork.UomConversionRepository.FindUomConversionRate(Lines[e.NewIndex].Uom.Id, Lines[e.NewIndex].SparePart.PrimaryUom.Id, Lines[e.NewIndex].SparePart.Id);
                     }
                 }
             };
        }
        public Guid Id { get; private set; }
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
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(this, nameof(Name));
                    HasChanged = true;
                }
            }
        }
        public Period Period
        {
            get => _period;
            set
            {
                if(_period != value)
                {
                    _period = value;
                    OnPropertyChanged(this, nameof(Period));
                    HasChanged = true;
                }
            }
        }
        public SparePartsPriceList SparePartsPriceList
        {
            get
            {
                return new SparePartsPriceList()
                {
                    Id = Id,
                    Name = _name,
                    Period = _period,
                    Lines = Lines.Select(x=>x.SparePartPriceListLine).ToList()
                };
            }
        }
        public ModelState Validate()
        {
            SparePartsPriceList sparePartsPriceList = SparePartsPriceList;
            ModelState modelState = _priceListValidator.Validate(sparePartsPriceList);
            if (!modelState.HasErrors)
            {
                foreach (var line in Lines)
                {
                    var temp = line.Validate(true);
                    if (temp.HasErrors)
                    {
                        modelState.AddErrors(temp);
                        return modelState;
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
                if (!modelState.HasErrors)
                {
                    if(Id == Guid.Empty)
                    {
                        var list = SparePartsPriceList;
                        list.Id = Guid.NewGuid();
                        foreach (var l in list.Lines)
                            l.Id = Guid.NewGuid();
                        _unitOfWork.SparePartsPriceListRepository.Add(list);
                        _unitOfWork.Complete();
                        Number = list.Number.ToString();
                    }
                    else
                    {
                        SparePartsPriceList oldList = _unitOfWork.SparePartsPriceListRepository.Find(key: Id);
                        oldList.Name = _name;
                        oldList.Period = _period;
                        foreach(var line in Lines)
                        {
                            if(line.Id == Guid.Empty)
                            {
                                oldList.Lines.Add(new SparePartPriceListLine()
                                {
                                    SparePart = line.SparePart,
                                    Uom = line.Uom,
                                    UomConversionRate = line.UomConversionRate,
                                    UnitPrice = line.UnitPrice
                                });
                            }
                            else
                            {
                                var oldLine = oldList.Lines.Where(x => x.Id == line.Id).FirstOrDefault();
                                if (oldLine != null)
                                {
                                    oldLine.SparePart = line.SparePart;
                                    oldLine.Uom = line.Uom;
                                    oldLine.UnitPrice = line.UnitPrice;
                                    oldLine.UomConversionRate = line.UomConversionRate;
                                }
                            }
                            var toDeleteLines = originalLines.Where(l => !Lines.Select(x => x.Id).Contains(l.Id));
                            foreach (var l in toDeleteLines)
                                oldList.Lines.Remove(l);
                            _unitOfWork.Complete();
                        }
                    }
                     
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
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result =
                    _applicationContext.DisplayMessage(
                        title: "Confirm Save", 
                        message: "Do You Want To Save Changes?", 
                        buttons: MessageBoxButtons.YesNoCancel, 
                        icon: MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
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
        public BindingList<SparePartPriceListLineEditViewModel> Lines { get; private set; } = new BindingList<SparePartPriceListLineEditViewModel>();

        private List<SparePartPriceListLine> originalLines = new List<SparePartPriceListLine>();
        public List<Period> Periods { get; private set; } = new List<Period>();
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        #region IDataErrorInfo
        public string this[string columnName] => Validate()[columnName];
        public string Error => Validate().Error;
        #endregion IDataErrorInfo
    }
}
