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

        public async Task<string> ImportFromExcelAsync(Mapper mapper, IProgress<int> progress)
        {
            return await Task.Run<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                List<SparePartViewModel> sparePartViewModels = mapper.Take<SparePartViewModel>().Select(r => r.Value).ToList();
                List<SparePart> spareParts = new List<SparePart>();
                int currentProgress = 0;
                for(int index = 0; index < sparePartViewModels.Count; index++)
                {
                    if (string.IsNullOrEmpty(sparePartViewModels[index].Code))
                    {
                        stringBuilder.AppendLine($"Invalid Code At Row# {index + 2}");
                        continue;
                    }
                    if (string.IsNullOrEmpty(sparePartViewModels[index].Name))
                    {
                        stringBuilder.AppendLine($"Invalid Name At Row# {index + 2}");
                        continue;
                    }
                    if (string.IsNullOrEmpty(sparePartViewModels[index].UomCode))
                    {
                        stringBuilder.AppendLine($"Invalid Uom At Row# {index + 2}");
                        continue;
                    }
                    string uomCode = sparePartViewModels[index].UomCode;
                    SparePart sparePart = new SparePart()
                    {
                        Code = sparePartViewModels[index].Code,
                        Name = sparePartViewModels[index].Name,
                        PrimaryUom = _unitOfWork.UomRepository.Find(x=>x.Code == uomCode).FirstOrDefault()
                    };
                    ModelState modelState = _validator.Validate(sparePart);
                    if (modelState.HasErrors)
                    {
                        stringBuilder.AppendLine($"Invalid Spare Part At Row# {index+2}: {modelState.Error}");
                        continue;
                    }
                    if(spareParts.Any(x=>x.Code == sparePart.Code))
                    {
                        stringBuilder.AppendLine($"Duplicate Item Code  {sparePart.Code} At Row# {index + 2}");
                        continue;
                    }
                    if (_unitOfWork.SparePartRepository.Exists(x => x.Code == sparePart.Code))
                    {
                        stringBuilder.AppendLine($"Duplicate Item Code {sparePart.Code} At Row# {index + 2}");
                        continue;
                    }
                    spareParts.Add(sparePart);
                    int p = (int)(index / sparePartViewModels.Count * 100.0);
                    if (p != currentProgress)
                    {
                        currentProgress = p;
                        progress.Report(currentProgress);
                    }
                }
                _unitOfWork.SparePartRepository.Add(spareParts);
                _unitOfWork.Complete();
                progress.Report(100);
                return stringBuilder.ToString();
            });
        }
    }
}
