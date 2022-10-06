using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels
{
    public class UomConversionEditViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<UomConversion> _validator;

        private bool _hasChanged = false;
        public UomConversionEditViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<UomConversion> validator)
            : this(null, unitOfWork, applicationContext, validator)
        {

        }
        public UomConversionEditViewModel(
            UomConversion uomConversion,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<UomConversion> validator)
        {
            if (unitOfWork is null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (applicationContext is null)
            {
                throw new ArgumentNullException(nameof(applicationContext));
            }

            if (validator is null)
            {
                throw new ArgumentNullException(nameof(validator));
            }
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;
            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(predicate: x => x.IsEnabled, orderBy: q => q.OrderBy(x => x.Code)));
            SpareParts.Insert(0, new SparePart() { Id = Guid.Empty, Code = "--ALL--" });
            Uoms.AddRange(_unitOfWork.UomRepository.Find(predicate: x => x.IsEnabled, orderBy: q => q.OrderBy(x => x.Code)));
            if (uomConversion != null)
            {
                Lines.Add(
                    new UomConversionLineEditViewModel(uomConversion)
                    {
                        Validator = _validator
                    }
                );
                if (uomConversion.SparePart != null)
                {
                    if (!SpareParts.Contains(uomConversion.SparePart))
                    {
                        SpareParts.Add(uomConversion.SparePart);
                    }
                    if (!Uoms.Contains(uomConversion.FromUom))
                    {
                        Uoms.Add(uomConversion.FromUom);
                    }
                    if (!Uoms.Contains(uomConversion.ToUom))
                    {
                        Uoms.Add(uomConversion.ToUom);
                    }
                }
                else
                {
                    Lines[Lines.Count - 1].SparePart = SpareParts[0];
                }
            }
            Lines.ListChanged += (o, e) =>
            {
                HasChanged = true;
                // ... add default values ...
                if (e.ListChangedType == ListChangedType.ItemAdded)
                {
                    if (e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                    {
                        Lines[e.NewIndex].Validator = _validator;
                        Lines[e.NewIndex].Rate = 1.0M;
                        if (SpareParts.Count > 0)
                            Lines[e.NewIndex].SparePart = SpareParts[0];
                        if (Uoms.Count > 0)
                        {
                            Lines[e.NewIndex].FromUom = Uoms[0];
                            Lines[e.NewIndex].ToUom = Uoms[0];
                        }
                        if (Uoms.Count > 1)
                        {
                            Lines[e.NewIndex].ToUom = Uoms[1];
                        }
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
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        public BindingList<UomConversionLineEditViewModel> Lines { get; private set; } = new BindingList<UomConversionLineEditViewModel>();

    }
}
