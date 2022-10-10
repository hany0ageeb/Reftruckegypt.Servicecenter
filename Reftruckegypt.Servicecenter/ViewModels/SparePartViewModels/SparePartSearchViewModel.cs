using Npoi.Mapper;
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

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels
{
    public class SparePartSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<SparePart> _validator;
        private bool _isDisposed = false;
        private string _codeOrName = "";

        private int _selectedIndex = -1;
        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = false;
        public SparePartSearchViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<SparePart> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _applicationContext = applicationContext;
        }
        public string CodeOrName
        {
            get => _codeOrName;
            set
            {
                if(_codeOrName != value)
                {
                    _codeOrName = value;
                    OnPropertyChanged(this, nameof(CodeOrName));
                }
            }
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if(_selectedIndex != value)
                {
                    _selectedIndex = value;
                    IsDeleteEnabled = CanDeleteSelectedItem();
                    if (_selectedIndex == -1)
                        IsEditEnabled = false;
                    else
                        IsEditEnabled = true;
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
        public bool CanDeleteSelectedItem()
        {
            if(_selectedIndex >= 0 && _selectedIndex < SpareParts.Count)
            {
                Guid currentPartId = SpareParts[_selectedIndex].Id;
                if (_unitOfWork.UomConversionRepository.Exists(x=>x.SparePartId == currentPartId) || 
                    _unitOfWork.SparePartsBillLineRepository.Exists(x=>x.SparePartId == currentPartId)||
                    _unitOfWork.SparePartPriceListLineRepository.Exists(x=>x.SparePartId == currentPartId))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public bool IsEditEnabled 
        {
            get => _isEditEnabled;
            set
            {
                if(_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
            }
        }
        public void Search()
        {
            SpareParts.Clear();
            IEnumerable<SparePart> parts = _unitOfWork.SparePartRepository.Find(
                predicate: x => x.Name.Contains(_codeOrName) || x.Code.Contains(_codeOrName),
                orderBy: q=>q.OrderBy(x=>x.Code));
            foreach(SparePart part in parts)
            {
                SpareParts.Add(new SparePartViewModel(part));
            }
        }
        public void Create()
        {
            _applicationContext.DisplaySparePartEditView(new SparePartEditViewModel( _unitOfWork, _applicationContext, _validator));
            Search();
        }
        public void Edit()
        {
            if (_selectedIndex >= 0 && _selectedIndex < SpareParts.Count && _isDeleteEnabled)
            {
                SparePart sparePart = _unitOfWork.SparePartRepository.Find(key: SpareParts[_selectedIndex].Id);
                if(sparePart != null)
                {
                    _applicationContext.DisplaySparePartEditView(new SparePartEditViewModel(sparePart, _unitOfWork, _applicationContext, _validator));
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"Spare Part: {SpareParts[_selectedIndex].Name} has been deleted and no longer exist!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Search();
            }
        }

        internal void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, SpareParts);
        }

        public void Delete()
        {
            if(_selectedIndex>= 0 && _selectedIndex < SpareParts.Count && _isDeleteEnabled)
            {
                DialogResult result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Spare Part: {SpareParts[_selectedIndex].Name}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    SparePart sparePart = _unitOfWork.SparePartRepository.Find(key: SpareParts[_selectedIndex].Id);
                    if (sparePart != null)
                    {
                        _unitOfWork.SparePartRepository.Remove(sparePart);
                        _unitOfWork.Complete();
                    }
                    Search();
                }
            }
        }
        #region IDisposable
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }
        #endregion IDisposable

        public BindingList<SparePartViewModel> SpareParts { get; private set; } = new BindingList<SparePartViewModel>();
    }
}
