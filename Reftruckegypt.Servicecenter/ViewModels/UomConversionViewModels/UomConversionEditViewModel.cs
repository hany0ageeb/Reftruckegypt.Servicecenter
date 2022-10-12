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
                _originalLines.Add(uomConversion);
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
                if(e.PropertyDescriptor?.Name!="HasChanged")
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
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                ModelState modelState = Validate();
                if (modelState.HasErrors)
                {
                    if (!string.IsNullOrEmpty(modelState.GetError("DuplicateLineError")))
                    {
                        _applicationContext.DisplayMessage("Error", modelState.GetError("DuplicateLineError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }
                var deletedLines = _originalLines.Where(x => !Lines.Select(l => l.Id).Contains(x.Id)).ToList();
                if (deletedLines.Count > 0)
                    _unitOfWork.UomConversionRepository.Remove(deletedLines);
                foreach (var line in Lines)
                {
                   
                    var uomConversion = line.UomConversion;
                    if (line.Id == Guid.Empty)
                    {
                        
                        uomConversion.Id = Guid.NewGuid();
                        _unitOfWork.UomConversionRepository.Add(uomConversion);
                    }
                    else
                    {
                        var oldLine = _unitOfWork.UomConversionRepository.Find(key: line.Id);
                        if(oldLine != null)
                        {
                            oldLine.Notes = uomConversion.Notes;
                            oldLine.Rate = uomConversion.Rate;
                            oldLine.FromUom = uomConversion.FromUom;
                            oldLine.ToUom = uomConversion.ToUom;
                            oldLine.SparePart = uomConversion.SparePart;
                        }
                    }
                    
                }
                _unitOfWork.Complete();
                HasChanged = false;
                return true;
            }
            return true;
        }
        public ModelState Validate()
        {
            ModelState modelState = new ModelState();
            if (_hasChanged)
            {
                if (!modelState.HasErrors)
                {
                    var duplicateLines = Lines
                        .Select(x => x.UomConversion)
                        .GroupBy(x => new { FromUomId = x.FromUomId, ToUomId = x.ToUomId, SparePartId = x.SparePartId })
                        .Where(g=>g.Count() >1)
                        .SelectMany(x => x.Select(z=>z))
                        .ToList();
                    if (duplicateLines.Count > 0)
                    {
                        modelState.AddError("DuplicateLineError", $"Line From Uom = {duplicateLines[0].FromUom.Code}, To Uom = {duplicateLines[0].ToUom.Code} Is Duplicate.");
                        return modelState;
                    }
                }
                var deletedLines = _originalLines.Where(x => !Lines.Select(l => l.Id).Contains(x.Id)).ToList();
                foreach (var line in Lines)
                {
                    var temp = line.Validate(true);
                    if (temp.HasErrors)
                    {
                        modelState.AddErrors(temp);
                    }
                    else
                    {
                        if(line.Id == Guid.Empty)
                        {
                            if(_unitOfWork.UomConversionRepository.Exists(x => x.FromUomId == line.FromUom.Id && x.ToUom.Id == line.ToUom.Id && !deletedLines.Select(t => t.Id).Contains(x.Id)))
                            {
                                modelState.AddError("DuplicateLineError", $"Line From Uom = {line.FromUom.Code}, To Uom = {line.ToUom.Code} Is Duplicated.");
                                return modelState;
                            }
                            
                        }
                        else
                        {
                            if (_unitOfWork.UomConversionRepository.Exists(x => x.Id != line.Id && x.FromUomId == line.FromUom.Id && x.ToUom.Id == line.ToUom.Id && !deletedLines.Select(t => t.Id).Contains(x.Id)))
                            {
                                modelState.AddError("DuplicateLineError", $"Line From Uom = {line.FromUom.Code}, To Uom = {line.ToUom.Code} Is Duplicated.");
                                return modelState;
                            }
                        }
                    }
                }
            }
            return modelState;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confirm Save", 
                    message: "Do You Want To Save Changes?",
                    buttons: MessageBoxButtons.YesNoCancel,
                    icon: MessageBoxIcon.Question);
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
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        public BindingList<UomConversionLineEditViewModel> Lines { get; private set; } = new BindingList<UomConversionLineEditViewModel>();

        private List<UomConversion> _originalLines = new List<UomConversion>();

    }
}
