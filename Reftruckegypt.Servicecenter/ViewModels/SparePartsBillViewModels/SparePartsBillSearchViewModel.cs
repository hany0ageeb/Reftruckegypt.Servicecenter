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

namespace Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels
{
    public class SparePartsBillSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<SparePartsBill> _billValidator;
        private readonly IValidator<SparePartsBillLine> _lineValidator;

        private bool _isDisposed = false;
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private Vehicle _vehicle;
        private SparePart _sparePart;
        private VehicleCategory _vehicleCategory;
        private bool _displayResultByHeader = true;
        private bool _displayResultByLine = false;
        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        public SparePartsBillSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<SparePartsBill> billValidator,
            IValidator<SparePartsBillLine> lineValidator)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            _billValidator = billValidator ?? throw new ArgumentNullException(nameof(billValidator));
            _lineValidator = lineValidator ?? throw new ArgumentNullException(nameof(lineValidator));

            SpareParts.AddRange(_unitOfWork.SparePartRepository.Find(orderBy: q => q.OrderBy(x => x.Code)));
            SpareParts.Insert(0, new SparePart() { Id = Guid.Empty, Code = "--ALL--" });
            _sparePart = SpareParts[0];
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q=>q.OrderBy(x => x.InternalCode)));
            Vehicles.Insert(0, new Vehicle() { Id = Guid.Empty, InternalCode = "--ALL--" });
            _vehicle = Vehicles[0];
            VehicleCategories.AddRange(_unitOfWork.VehicleCategoryRepository.Find(orderBy: q => q.OrderBy(x => x.Name)));
            VehicleCategories.Insert(0, VehicleCategory.empty);
            _vehicleCategory = VehicleCategories[0];

        }
        public bool DisplayResultByHeader
        {
            get => _displayResultByHeader;
            set
            {
                if (_displayResultByHeader != value)
                {
                    _displayResultByHeader = value;
                    OnPropertyChanged(this, nameof(DisplayResultByHeader));
                    if (_displayResultByHeader)
                        DisplayResultByLine = false;
                    else
                        DisplayResultByLine = true;
                }
            }
        }
        public bool DisplayResultByLine
        {
            get => _displayResultByLine;
            set
            {
                if(_displayResultByLine != value)
                {
                    _displayResultByLine = value;
                    OnPropertyChanged(this, nameof(DisplayResultByLine));
                    if (_displayResultByLine)
                        DisplayResultByHeader = false;
                    else
                        DisplayResultByHeader = true;
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
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged(this, nameof(SelectedIndex));
                    IsDeleteEnabled = CanDeleteSelectedRecord();
                    IsEditEnabled = CanEditSelectedRecord();
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
                }
            }
        }
        public VehicleCategory VehicleCategory
        {
            get => _vehicleCategory;
            set
            {
                if (_vehicleCategory != value)
                {
                    _vehicleCategory = value;
                    OnPropertyChanged(this, nameof(VehicleCategory));
                }
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
                    OnPropertyChanged(this, nameof(SparePart));
                }
            }
        }
        public DateTime? ToDate
        {
            get => _toDate;
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged(this, nameof(ToDate));
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
        private bool CanEditSelectedRecord()
        {
            if (_displayResultByHeader)
            {
                if(_selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    return Headers[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else if (_displayResultByLine)
            {
                if (_selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    return Lines[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        private bool CanDeleteSelectedRecord()
        {
            if (_displayResultByHeader)
            {
                if (_selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    return Headers[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else if (_displayResultByLine)
            {
                if (_selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    return Lines[_selectedIndex].State == PeriodStates.OpenState;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public void Search()
        {
            Headers.Clear();
            Lines.Clear();
            if (_displayResultByHeader)
            {
                IEnumerable<SparePartsBill> bills =
                    _unitOfWork
                    .SparePartsBillRepository
                    .Find(
                        vehicleId: _vehicle?.Id,
                        vehicleCategoryId: _vehicleCategory?.Id,
                        fromDate: _fromDate,
                        toDate: _toDate,
                        orderBy: q => q.OrderByDescending(x => x.BillDate).ThenBy(x => x.Vehicle.InternalCode));
                foreach (var bill in bills)
                    Headers.Add(new SparePartsBillHeaderViewModel(bill));
            }
            else if (_displayResultByLine)
            {
                IEnumerable<SparePartsBillLine> lines =
                    _unitOfWork
                    .SparePartsBillLineRepository
                    .Find(
                        vehicleId: _vehicle?.Id,
                        vehicleCategoryId: _vehicleCategory?.Id,
                        fromDate: _fromDate,
                        toDate: _toDate,
                        sparePartId: _sparePart.Id,
                        orderBy: q => q.OrderByDescending(x => x.SparePartsBill.BillDate).ThenBy(x => x.SparePartsBill.Vehicle.InternalCode).ThenBy(x => x.SparePart.Code)
                        );
                foreach(var line in lines)
                {
                    Lines.Add(new SparePartsBillLineViewModel(line));
                }
            }
        }
        public void Create()
        {
            _applicationContext.DisplaySparePartsBillEditView(new SparePartsBillEditViewModel(_unitOfWork, _applicationContext, _billValidator, _lineValidator));
            Search();
        }
        public void Edit()
        {
            if (_displayResultByHeader)
            {
                if(_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    SparePartsBill bill = _unitOfWork.SparePartsBillRepository.Find(key: Headers[_selectedIndex].Id);
                    if(bill != null)
                    {
                        _applicationContext.DisplaySparePartsBillEditView(new SparePartsBillEditViewModel(bill, _unitOfWork, _applicationContext, _billValidator, _lineValidator));
                        Search();
                    }
                    else
                    {
                        _ = _applicationContext.DisplayMessage(
                            title: "Error",
                            message: $"Spare Parts Bill# {Headers[_selectedIndex].Number} has been deleted and n longet exist",
                            buttons: MessageBoxButtons.OK,
                            icon: MessageBoxIcon.Error);
                        Search();
                    }
                }
            }
            else if (_displayResultByLine)
            {
                if (_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    SparePartsBill bill = _unitOfWork.SparePartsBillRepository.Find(key: Lines[_selectedIndex].BillId);
                    if (bill != null)
                    {
                        var first = bill.Lines.Where(x => x.Id == Lines[_selectedIndex].Id).FirstOrDefault();
                        if (first != null)
                        {
                            bill.Lines.Remove(first);
                            bill.Lines.Insert(0, first);
                        }
                        else
                        {
                            _ = _applicationContext.DisplayMessage(
                          title: "Error",
                          message: $"Spare Parts Bill Line For{Lines[_selectedIndex].SparePartCode} has been deleted and n longet exist",
                          buttons: MessageBoxButtons.OK,
                          icon: MessageBoxIcon.Error);
                            Search();
                        }
                    }
                    else
                    {
                        _ = _applicationContext.DisplayMessage(
                           title: "Error",
                           message: $"Spare Parts Bill# {Lines[_selectedIndex].Number} has been deleted and n longet exist",
                           buttons: MessageBoxButtons.OK,
                           icon: MessageBoxIcon.Error);
                        Search();
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

        public void Delete()
        {
            if (_displayResultByHeader)
            {
                if (_isDeleteEnabled && _selectedIndex >= 0 && _selectedIndex < Headers.Count)
                {
                    DialogResult result = _applicationContext.DisplayMessage(
                        title: "Confirm Delete",
                        message: $"Are You Sure You Want To Delete Bill# {Headers[_selectedIndex].Number}?",
                        buttons: MessageBoxButtons.YesNo,
                        icon: MessageBoxIcon.Question
                        );
                    if(result == DialogResult.Yes)
                    {
                        SparePartsBill bill = _unitOfWork.SparePartsBillRepository.Find(key: Headers[_selectedIndex].Id);
                        if (bill != null)
                        {
                            _unitOfWork.SparePartsBillRepository.Remove(bill);
                            _unitOfWork.Complete();
                            Search();
                        }
                        else
                        {
                            Search();
                        }
                    }
                }
            }
            else if (_displayResultByLine)
            {
                if (_isDeleteEnabled && _selectedIndex >= 0 && _selectedIndex < Lines.Count)
                {
                    DialogResult result = _applicationContext.DisplayMessage(
                        title: "Confirm Delete",
                        message: $"Are You Sure You Want To Delete Line Of Spare Part {Lines[_selectedIndex].SparePartCode}?",
                        buttons: MessageBoxButtons.YesNo,
                        icon: MessageBoxIcon.Question
                        );
                    if (result == DialogResult.Yes)
                    {
                        SparePartsBillLine line = _unitOfWork.SparePartsBillLineRepository.Find(key: Lines[_selectedIndex].Id);
                        if (line != null)
                        {
                            _unitOfWork.SparePartsBillLineRepository.Remove(line);
                            _unitOfWork.Complete();
                            Search();
                        }
                        else
                        {
                            Search();
                        }
                    }
                }
            }
        }
        private decimal FindSparePartUnitPrice(SparePart sparePart, Uom uom, Period period)
        {
            if (period == null)
                return 0;
            SparePartsPriceList priceList = _unitOfWork
                .SparePartsPriceListRepository
                .Find(x => x.Period.Id == period.Id).FirstOrDefault();
            if (priceList == null)
                return 0;
            return priceList.FindUnitPrice(sparePart, uom) ?? 0;
        }
        public Task<string> ImportFromExcelFileAsync(Mapper mapper, IProgress<int> progress)
        {
            return Task.Run<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                List<SparePartsBillLineViewModel> excelLines = mapper.Take<SparePartsBillLineViewModel>().Select(r=>r.Value).ToList();
                progress.Report(25);
                List<SparePartsBill> internalBills = new List<SparePartsBill>();
                List<SparePartsBill> validBills = new List<SparePartsBill>();
                var bills = excelLines.GroupBy(e => new { VehicleInternalCode = e.VehicleInternalCode, BillDate = e.BillDate, Repairs = e.Repairs });
                foreach(var bill in bills)
                {
                    SparePartsBill b = new SparePartsBill()
                    {
                        Vehicle = _unitOfWork.VehicleRepository.Find(x => x.InternalCode == bill.Key.VehicleInternalCode).FirstOrDefault(),
                        BillDate = bill.Key.BillDate,
                        Period = _unitOfWork.PeriodRepository.FindOpenPeriod(bill.Key.BillDate),
                        Repairs = bill.Key.Repairs
                    };
                    foreach(var l in bill)
                    {
                        var line = new SparePartsBillLine()
                        {
                            Quantity = l.Quantity,
                            SparePart = _unitOfWork.SparePartRepository.Find(x => x.Code == l.SparePartCode).FirstOrDefault(),
                            Uom = string.IsNullOrEmpty(l.UomCode) ? SparePart?.PrimaryUom : _unitOfWork.UomRepository.Find(x => x.Code == l.UomCode).FirstOrDefault()
                        };
                        line.UnitPrice = l.UnitPrice.HasValue ? l.UnitPrice.Value : l.UnitPrice.HasValue ? l.UnitPrice.Value : FindSparePartUnitPrice(line.SparePart, line.Uom, b.Period);
                        if (line?.Uom?.Id == line.SparePart?.PrimaryUom?.Id)
                            line.UomConversionRate = null;
                        else
                            line.UomConversionRate = _unitOfWork.UomConversionRepository.FindUomConversionRate(line.Uom.Id, line.SparePart.PrimaryUom.Id, line.SparePart.Id);
                        b.Lines.Add(line);
                    }
                    internalBills.Add(b);
                }
                progress.Report(50);
                
                foreach(var internalBill in internalBills)
                {
                    bool billLinesHasErrors = false;
                    ModelState modelState =  _billValidator.Validate(internalBill);
                    if (modelState.HasErrors)
                    {
                        stringBuilder.AppendLine(modelState.Error);
                        continue;
                    }
                    foreach(var line in internalBill.Lines)
                    {
                        ModelState lineState = _lineValidator.Validate(line);
                        if (lineState.HasErrors)
                        {
                            stringBuilder.AppendLine(lineState.Error);
                            billLinesHasErrors = true;
                            break;
                        }
                    }
                    if (billLinesHasErrors)
                    {
                        billLinesHasErrors = false;
                        continue;
                    }
                    validBills.Add(internalBill);
                }
                progress.Report(75);
                _unitOfWork.SparePartsBillRepository.Add(validBills);
                _unitOfWork.Complete();
                progress.Report(100);
                return stringBuilder.ToString();
            });
        }

        public BindingList<SparePartsBillHeaderViewModel> Headers { get; private set; } = new BindingList<SparePartsBillHeaderViewModel>();
        public BindingList<SparePartsBillLineViewModel> Lines { get; private set; } = new BindingList<SparePartsBillLineViewModel>();
        public List<SparePart> SpareParts { get; private set; } = new List<SparePart>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public List<VehicleCategory> VehicleCategories { get; private set; } = new List<VehicleCategory>();
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
