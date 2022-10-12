using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels
{
    public class UomConversionSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<UomConversion> _validator;

        private bool _isDisposed = false;

        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        private SparePart _sparePart;
        private Uom _fromUom;
        private Uom _toUom;

        public UomConversionSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<UomConversion> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;

            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(orderBy: q => q.OrderBy(e => e.Code)));
            SpareParts.Insert(0, new SparePart() { Id = Guid.Empty, Code = "--ALL--" });
            SparePart = SpareParts[0];

            Uoms.AddRange(_unitOfWork.UomRepository.Find(orderBy: q=>q.OrderBy(x => x.Code)));
            Uoms.Insert(0, new Uom() { Id = Guid.Empty, Code = "--ALL--" });
            FromUom = Uoms[0];
            ToUom = Uoms[0];
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    if (_selectedIndex >= 0 && _selectedIndex < UomConversions.Count)
                    {
                        IsEditEnabled = true;
                        IsDeleteEnabled = true;
                    }
                    else
                    {
                        IsEditEnabled = false;
                        IsDeleteEnabled = false;
                    }
                }
            }
        }
        public bool IsEditEnabled
        {
            get => _isEditEnabled;
            private set
            {
                if (_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
            }
        }
        public bool IsDeleteEnabled
        {
            get => _isDeleteEnabled;
            private set
            {
                if (_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        public SparePart SparePart
        {
            get => _sparePart;
            set
            {
                if (_sparePart != value)
                {
                    _sparePart = value;
                    OnPropertyChanged(this, nameof(SparePart));
                }
            }
        }
        public Uom FromUom
        {
            get => _fromUom;
            set
            {
                if (_fromUom != value)
                {
                    _fromUom = value;
                    OnPropertyChanged(this, nameof(FromUom));
                }
            }
        }
        public Uom ToUom
        {
            get => _toUom;
            set
            {
                if (_toUom != value)
                {
                    _toUom = value;
                    OnPropertyChanged(this, nameof(ToUom));
                }
            }
        }
        public void Search()
        {
            UomConversions.Clear();
            IEnumerable<UomConversion> conversions = _unitOfWork.UomConversionRepository.Find(
                sparePartId: _sparePart.Id,
                fromUomId: _fromUom.Id,
                toUomId: _toUom.Id,
                orderBy: q=>q.OrderBy(x=>x.FromUom.Code).ThenBy(x=>x.ToUom.Code).ThenBy(x=>x.SparePart.Code)
                );
            foreach(UomConversion uomConversion in conversions)
            {
                UomConversions.Add(new UomConversionViewModel(uomConversion));
            }
        }
        public void Create()
        {
            _applicationContext.DisplayUomConversionEditView(new UomConversionEditViewModel(_unitOfWork, _applicationContext, _validator));
            Search();
        }
        public void Edit()
        {
            if (_isEditEnabled)
            {
                var old = _unitOfWork.UomConversionRepository.Find(key: UomConversions[_selectedIndex].Id);
                if (old != null)
                {
                    _applicationContext.DisplayUomConversionEditView(new UomConversionEditViewModel(old, _unitOfWork, _applicationContext, _validator));
                    Search();
                }
                else
                {
                    _applicationContext.DisplayMessage(
                        title: "Error",
                        message: "This Uom Conversion Has beene deleted and no longer exists!",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error
                        );
                    Search();
                }
            }
        }
        public void Delete()
        {
            if (_isDeleteEnabled)
            {
                DialogResult result =
                    _applicationContext.DisplayMessage(
                        title: "Confirm Delete",
                        message: $"Are You Sure You Want To Delete Uom Conversion From Uom {UomConversions[_selectedIndex].FromUomCode} To Uom {UomConversions[_selectedIndex].ToUomCode} ?",
                        buttons: MessageBoxButtons.YesNo,
                        icon: MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    var old = _unitOfWork.UomConversionRepository.Find(key: UomConversions[_selectedIndex].Id);
                    if (old != null)
                    {
                        _unitOfWork.UomConversionRepository.Remove(old);
                        _unitOfWork.Complete();
                    }
                    Search();
                }
            }
        }
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        public List<Uom> Uoms { get; private set; } = new List<Uom>();
        public BindingList<UomConversionViewModel> UomConversions { get; private set; } = new BindingList<UomConversionViewModel>();
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
    }
}
