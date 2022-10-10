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

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels
{
    public class SparePartsPriceListSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<SparePartsPriceList> _listValidator;
        private readonly IValidator<SparePartPriceListLine> _lineValidator;
        
        private DateTime? _fromDate;
        private DateTime? _toDte;
        private SparePart _sparePart;
        private bool _resultByHeader = true;
        private bool _resultByLine = false;
        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;
        public SparePartsPriceListSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<SparePartsPriceList> listValidator,
            IValidator<SparePartPriceListLine> lineValidator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _listValidator = listValidator;
            _lineValidator = lineValidator;

            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(orderBy: q=>q.OrderBy(x=>x.Code)));
            SpareParts.Insert(0, new SparePart() { Id = Guid.Empty, Code = "--ALL--" });

            _sparePart = SpareParts[0];
        }
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged(this, nameof(SelectedIndex));
                    IsEditEnabled = CanEditSelectedList();
                    IsDeleteEnabled = CanDeleteSelectedList();
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
                if(_isDeleteEnabled != value)
                {
                    _isDeleteEnabled = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        private bool CanDeleteSelectedList()
        {
            if(Lines.Count > 0)
            {
                if(_selectedIndex >=0 && _selectedIndex < Lines.Count)
                {
                    return Lines[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else if(Headers.Count > 0)
            {
                if (_selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    return Headers[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        private bool CanEditSelectedList()
        {
            if (Lines.Count > 0)
            {
                if (_selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    return Lines[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else if (Headers.Count > 0)
            {
                if (_selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    return Headers[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public DateTime? FromDate
        {
            get => _fromDate;
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged(this, nameof(FromDate));
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
        public DateTime? ToDate
        {
            get => _toDte;
            set
            {
                if (_toDte != value)
                {
                    _toDte = value;
                    OnPropertyChanged(this, nameof(ToDate));
                }
            }
        }
        public bool HeaderResult
        {
            get => _resultByHeader;
            set
            {
                if (_resultByHeader != value)
                {
                    _resultByHeader = value;
                    OnPropertyChanged(this, nameof(HeaderResult));
                    LineResult = false;
                }
            }
        }
        public bool LineResult
        {
            get => _resultByLine;
            set
            {
                if (_resultByLine != value)
                {
                    _resultByLine = value;
                    OnPropertyChanged(this, nameof(LineResult));
                    HeaderResult = false;
                }
            }
        }
        public void Search()
        {
            Headers.Clear();
            Lines.Clear();
            if (_resultByHeader)
            {
                IEnumerable<SparePartsPriceList> lists =
                    _unitOfWork
                    .SparePartsPriceListRepository
                    .Find(
                        fromDate: _fromDate,
                        toDate: _toDte,
                        orderBy: q => q.OrderBy(x => x.Period.FromDate));
                foreach(var list in lists)
                {
                    Headers.Add(new SparePartsPriceListHeaderViewModel(list));
                }
            }
            else if (_resultByLine)
            {
                IEnumerable<SparePartPriceListLine> lines =
                    _unitOfWork.SparePartPriceListLineRepository
                    .Find(
                        fromDate: _fromDate,
                        todate: ToDate,
                        sparePartId: _sparePart?.Id,
                        orderBy: q => q.OrderBy(x => x.SparePartsPriceList.Period.FromDate).ThenBy(x => x.SparePart.Code));
                foreach (SparePartPriceListLine line in lines)
                {
                    Lines.Add(new SparePartsPriceListLineViewModel(line));
                }
                    
            }
        }
        public void Create()
        {
            _applicationContext.DisplayPriceListEditView(
                new SparePartPriceListEditViewModel(_unitOfWork, _applicationContext, _listValidator, _lineValidator));
        }
        public void Edit()
        {
            if (Headers.Count > 0)
            {
                if (_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    var list = _unitOfWork.SparePartsPriceListRepository.Find(key: Headers[_selectedIndex].Id);
                    _applicationContext.DisplayPriceListEditView(
                        new SparePartPriceListEditViewModel(
                            list,
                            _unitOfWork,
                            _applicationContext,
                            _listValidator,
                            _lineValidator
                            ));
                }
            }
            else if(Lines.Count > 0)
            {
                if (_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    var list = _unitOfWork.SparePartsPriceListRepository.Find(key: Lines[_selectedIndex].ListId);
                    var firstLine = list.Lines.Where(x => x.Id == Lines[_selectedIndex].Id).FirstOrDefault();
                    if (firstLine != null)
                    {
                        list.Lines.Remove(firstLine);
                        list.Lines.Insert(0, firstLine);
                    }
                    _applicationContext.DisplayPriceListEditView(
                        new SparePartPriceListEditViewModel(
                            list,
                            _unitOfWork,
                            _applicationContext,
                            _listValidator,
                            _lineValidator
                            ));
                }
            }
        }
        public void Delete()
        {
            if (Headers.Count > 0) 
            {
                if (_isDeleteEnabled && _selectedIndex >= 0 &&_selectedIndex < Headers.Count)
                {
                    DialogResult result = _applicationContext
                        .DisplayMessage(
                            title: "Confirm Delete",
                            message: $"Are You Sure You want to delete Price List# ${Headers[_selectedIndex].Number}?",
                            buttons: MessageBoxButtons.YesNo,
                            icon: MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        var old = _unitOfWork.SparePartsPriceListRepository.Find(key: Headers[_selectedIndex].Id);
                        if (old != null)
                        {
                            _unitOfWork.SparePartsPriceListRepository.Remove(old);
                            _unitOfWork.Complete();
                            Search();
                        }
                        else
                        {
                            // ....
                        }
                    }
                }
            }
            else if(Lines.Count > 0)
            {
                if (_isDeleteEnabled && _selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    DialogResult result = _applicationContext
                        .DisplayMessage(
                            title: "Confirm Delete",
                            message: $"Are You Sure You want to delete Price List Line # ${Lines[_selectedIndex].SparePartName}?",
                            buttons: MessageBoxButtons.YesNo,
                            icon: MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var old = _unitOfWork.SparePartPriceListLineRepository.Find(key: Lines[_selectedIndex].Id);
                        if (old != null)
                        {
                            _unitOfWork.SparePartPriceListLineRepository.Remove(old);
                            _unitOfWork.Complete();
                            Search();
                        }
                        else
                        {
                            // ....
                        }
                    }
                }
            }
        }

        public void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            if(Headers.Count > 0)
            {
                mapper.Save(fileName, Headers);
            }
            else if(Lines.Count > 0)
            {
                mapper.Save(fileName, Lines);
            }
        }

        public BindingList<SparePartsPriceListHeaderViewModel> Headers { get; private set; } = new BindingList<SparePartsPriceListHeaderViewModel>();
        public BindingList<SparePartsPriceListLineViewModel> Lines { get; private set; } = new BindingList<SparePartsPriceListLineViewModel>();
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        private bool _isDisposed = false;
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
