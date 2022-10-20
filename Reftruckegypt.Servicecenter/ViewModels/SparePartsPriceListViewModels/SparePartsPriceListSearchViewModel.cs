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
            Search();
        }
        public void Edit()
        {
            if (Headers.Count > 0)
            {
                if (_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    var list = _unitOfWork.SparePartsPriceListRepository.Find(key: Headers[_selectedIndex].Id);
                    if (list != null)
                    {
                        _applicationContext.DisplayPriceListEditView(
                            new SparePartPriceListEditViewModel(
                                list,
                                _unitOfWork,
                                _applicationContext,
                                _listValidator,
                                _lineValidator
                                ));
                        Search();
                    }
                    else
                    {
                        _applicationContext.DisplayMessage(
                            title: "Error", 
                            message: $"{Headers[_selectedIndex].Name} has been deleted and no longer exist.", 
                            buttons: MessageBoxButtons.OK, 
                            icon: MessageBoxIcon.Error);
                        Search();
                    }
                }
            }
            else if(Lines.Count > 0)
            {
                if (_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    var list = _unitOfWork.SparePartsPriceListRepository.Find(key: Lines[_selectedIndex].ListId);
                    var firstLine = list.Lines.Where(x => x.Id == Lines[_selectedIndex].Id).FirstOrDefault();
                    if (list != null)
                    {
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
                        Search();
                    }
                    else
                    {
                        _ = _applicationContext.DisplayMessage(
                           title: "Error",
                           message: $"Price List: {Lines[_selectedIndex].Name} has been deleted and no longer exist.",
                           buttons: MessageBoxButtons.OK,
                           icon: MessageBoxIcon.Error);
                        Search();
                    }
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

        public Task<string> ImportFromExcelFileAsync(Mapper mapper, IProgress<int> progress)
        {
            return Task.Run<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                List<SparePartsPriceListLineViewModel> linesViewModel =
                    mapper.Take<SparePartsPriceListLineViewModel>().Select(r => r.Value).ToList();
                List<SparePartsPriceList> priceLists = new List<SparePartsPriceList>();
                IEnumerable<IGrouping<(string ListName, string PeriodName), SparePartsPriceListLineViewModel>> groups = 
                    linesViewModel.GroupBy(x => (ListName: x.Name, x.PeriodName));
                foreach(IGrouping<(string ListName, string PeriodName), SparePartsPriceListLineViewModel> group in groups)
                {
                    progress.Report(0);
                    SparePartsPriceList priceList = new SparePartsPriceList()
                    {
                        Name = group.Key.ListName,
                        Period = 
                            _unitOfWork.PeriodRepository.Find(x => x.Name.Equals(group.Key.PeriodName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault()
                    };
                    if(priceList.Period == null || priceList.Period.State != PeriodStates.OpenState || priceList.Period.SparePartsPriceList != null || priceLists.Any(p=>p.Period.Id == priceList.Period.Id))
                    {
                        stringBuilder.AppendLine($"Invalid Period Name: {group.Key.PeriodName} Or The Period has an associated price list.");
                        continue;
                    }
                    if (_unitOfWork.SparePartsPriceListRepository.Exists(x=>x.Name.Equals(group.Key.ListName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        stringBuilder.AppendLine($"Invalid Price List Name: Price List Name {group.Key.PeriodName} already exist");
                        continue;
                    }
                    foreach(SparePartsPriceListLineViewModel line in group)
                    {
                        SparePartPriceListLine priceListLine = new SparePartPriceListLine()
                        {
                            SparePart = 
                                _unitOfWork.SparePartRepository.Find(x=>x.Code.Equals(line.SparePartCode)).FirstOrDefault(),
                            UnitPrice = line.UnitPrice
                        };
                        if(priceListLine.SparePart == null)
                        {
                            stringBuilder.AppendLine($"Invalid Part Code: {line.SparePartCode} .");
                            continue;
                        }
                        if (string.IsNullOrEmpty(line.UomCode))
                        {
                            priceListLine.Uom = priceListLine.SparePart?.PrimaryUom;
                        }
                        else
                        {
                            priceListLine.Uom = _unitOfWork.UomRepository.Find(x => x.Code.Equals(line.UomCode, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                        }
                        if(priceListLine.Uom == null)
                        {
                            stringBuilder.AppendLine($"Invalid Uom Code: {line.UomCode} .");
                            continue;
                        }
                        if(priceListLine.Uom.Id != priceListLine.SparePart.PrimaryUom.Id)
                        {
                            if (line.ConversionRate.HasValue)
                            {
                                priceListLine.UomConversionRate = line.ConversionRate;
                                if(priceListLine.UomConversionRate <= 0)
                                {
                                    _ = stringBuilder.AppendLine($"Invalid Uom Conversion Rate: {line.ConversionRate} .");
                                    continue;
                                }
                            }
                            else
                            {
                                priceListLine.UomConversionRate = _unitOfWork.UomConversionRepository.FindUomConversionRate(priceListLine.Uom.Id, priceListLine.SparePart.PrimaryUom.Id, priceListLine.SparePart.Id);
                                if (!priceListLine.UomConversionRate.HasValue)
                                {
                                    _ = stringBuilder.AppendLine($"Invalid Uom Conversion Rate: No Conversion Exist Between {priceListLine.Uom.Code} and {priceListLine.SparePart.PrimaryUom.Code} .");
                                    continue;
                                }
                            }
                        }
                        if (priceList.Lines.Any(x => x.SparePart.Id == priceListLine.SparePart.Id))
                        {
                            _ = stringBuilder.AppendLine($"Duplicate Spare Part Code {priceListLine.SparePart.Code} in the same Price List {priceList.Name}");
                            continue;
                        }
                        else
                        {
                            priceList.Lines.Add(priceListLine);
                        }
                    }
                    progress.Report(100);
                    priceLists.Add(priceList);
                }
                progress.Report(0);
                _unitOfWork.SparePartsPriceListRepository.Add(priceLists);
                _unitOfWork.Complete();
                progress.Report(100);
                return stringBuilder.ToString();
            });
            
        }

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
