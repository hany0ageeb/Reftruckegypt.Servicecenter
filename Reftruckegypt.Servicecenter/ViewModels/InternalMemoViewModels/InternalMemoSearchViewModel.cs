using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.InternalMemoViewModels
{
    public class InternalMemoSearchViewModel : ViewModelBase, IDisposable
    {
        private bool _isDisposed = false;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;

        private Vehicle _vehicle;
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private string _subject = "";

        private int _selectedindex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;

        public InternalMemoSearchViewModel(
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));

            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            Vehicles.Insert(0, Vehicle.Empty);
            _vehicle = Vehicles[0];
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
        public string Subject
        {
            get => _subject;
            set
            {
                if (_subject != value)
                {
                    _subject = value;
                    OnPropertyChanged(this, nameof(Subject));
                }
            }
        }
        public string CurrentMemoContents
        {
            get
            {
                if(_selectedindex >= 0 && _selectedindex < InternalMemos.Count)
                {
                    return InternalMemos[_selectedindex].Content;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public int SelectedIndex
        {
            get => _selectedindex;
            set
            {
                if (_selectedindex != value)
                {
                    _selectedindex = value;
                    IsEditEnabled = CanEditSelectedMemo();
                    IsDeleteEnabled = CanDeleteSelectedMemo();
                    OnPropertyChanged(this, nameof(CurrentMemoContents));
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
        private bool CanEditSelectedMemo()
        {
            if(_selectedindex >= 0 && _selectedindex < InternalMemos.Count)
            {
                return InternalMemos[_selectedindex].State == PeriodStates.OpenState;
            }
            return false;
        }
        private bool CanDeleteSelectedMemo()
        {
            if (_selectedindex >= 0 && _selectedindex < InternalMemos.Count)
            {
                return InternalMemos[_selectedindex].State == PeriodStates.OpenState;
            }
            return false;
        }
        public void Search()
        {
            InternalMemos.Clear();
            IEnumerable<InternalMemo> internalMemos = 
                _unitOfWork.InternalMemoRepository.Find(
                    vehicleId: _vehicle.Id,
                    fromDate: _fromDate,
                    toDate: _toDate,
                    header: _subject,
                    orderBy: q => q.OrderByDescending(x=>x.MemoDate));
            foreach(InternalMemo internalMemo in internalMemos)
            {
                InternalMemos.Add(new InternalMemoDTO(internalMemo));
            }
        }
        public void Create()
        {

        }
        public void Edit()
        {
            if(_isEditEnabled && _selectedindex >= 0 && _selectedindex < InternalMemos.Count)
            {
                InternalMemo internalMemo = _unitOfWork.InternalMemoRepository.Find(key: InternalMemos[_selectedindex].Id);
                if (internalMemo != null)
                {
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"Internal Memeo# {InternalMemos[_selectedindex].Number} no longer exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public void Delete()
        {
            if(_isDeleteEnabled && _selectedindex >= 0 && _selectedindex < InternalMemos.Count)
            {
                DialogResult result =
                    _applicationContext.DisplayMessage(
                        title: "Confirm Delete", 
                        message: $"Are You Sure You Want To Delete Internal Memeo # {InternalMemos[_selectedindex].Number} ?", 
                        buttons: MessageBoxButtons.YesNo, 
                        icon: MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    InternalMemo internalMemo = _unitOfWork.InternalMemoRepository.Find(key: InternalMemos[_selectedindex].Id);
                    if (internalMemo != null)
                    {
                        _unitOfWork.InternalMemoRepository.Remove(internalMemo);
                        _unitOfWork.Complete();
                    }
                    Search();
                }
            }
        }
        public BindingList<InternalMemoDTO> InternalMemos { get; private set; } = new BindingList<InternalMemoDTO>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
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
