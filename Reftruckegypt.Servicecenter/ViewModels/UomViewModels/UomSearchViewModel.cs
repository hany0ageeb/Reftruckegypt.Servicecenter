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

namespace Reftruckegypt.Servicecenter.ViewModels.UomViewModels
{
    public class UomSearchViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<Uom> _validator;
        private string _name = "";
        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = true;
        private int _selectedIndex = -1;
        public UomSearchViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<Uom> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;
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
                    IsDeleteEnabled = CanDeleteSelectedUom();
                }
            }
        }
        public bool IsEditEnabled => _isEditEnabled;
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
        private bool CanDeleteSelectedUom()
        {
            if(_selectedIndex >= 0 && _selectedIndex < Uoms.Count)
            {
                Guid selectedUomId = Uoms[_selectedIndex].Id;
               if ( 
                    _unitOfWork.SparePartPriceListLineRepository.Exists(
                        e=>e.UomId == selectedUomId ) ||
                    _unitOfWork.SparePartsBillLineRepository.Exists(
                        e=>e.UomId == selectedUomId ) ||
                    _unitOfWork.UomConversionRepository.Exists(
                        e => e.FromUomId == selectedUomId || e.ToUomId == selectedUomId))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public void Search()
        {
            Uoms.Clear();
            IList<Uom> uoms = _unitOfWork.UomRepository.Find(
                predicate: u => u.Code.Contains(_name) || u.Name.Contains(_name),
                orderBy: q => q.OrderBy(u => u.Code))
            .ToList();
            foreach(Uom uom in uoms)
            {
                Uoms.Add(uom);
            }
        }
        public void Create()
        {
            _applicationContext.DisplayUomEditView(new UomEditViewModel(_unitOfWork, _applicationContext, _validator));
            Search();
        }
        public void Edit()
        {
            if (_selectedIndex >= 0 && _selectedIndex < Uoms.Count)
            {
                _applicationContext.DisplayUomEditView(new UomEditViewModel(Uoms[_selectedIndex], _unitOfWork, _applicationContext, _validator));
                Search();
            }
        }
        public void Delete()
        {
            if(_selectedIndex >= 0 && _selectedIndex < Uoms.Count)
            {
                Uom uom = _unitOfWork.UomRepository.Find(key: Uoms[_selectedIndex].Id);
                if (uom != null)
                {
                    DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Uom: {Uoms[_selectedIndex].Code} ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _unitOfWork.UomRepository.Remove(uom);
                        _ = _unitOfWork.Complete();
                        Search();
                    }
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"The Current Uom: {Uoms[_selectedIndex].Code} no longer exists in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public BindingList<Uom> Uoms { get; private set; } = new BindingList<Uom>();
    }
}
