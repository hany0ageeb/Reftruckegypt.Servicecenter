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

namespace Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels
{
    public class FuelCardSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<FuelCard> _validator;
        private bool _isDisposed = false;
        private int _selectedIndex = -1;
        private bool _isDeleteEnabled = false;
        private bool _isEditEnabled = false;

        private string _number = "";
        private string _name = "";
        private string _registration = "";

        public void ExportToFile(string fileName)
        {
            Mapper mapper = new Mapper();
            mapper.Save(fileName, SearchResult);
        }

        private Vehicle _vehicle;

        public FuelCardSearchViewModel(
            IUnitOfWork unitOfWork, 
            IApplicationContext applicationContext,
            IValidator<FuelCard> validator)
        {
            if (unitOfWork is null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
            if (applicationContext is null)
            {
                throw new ArgumentNullException(nameof(applicationContext));
            }
            _applicationContext = applicationContext;
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            Vehicles.Insert(0, new Vehicle() { Id = Guid.Empty, InternalCode = "--ALL--" });
            _vehicle = Vehicles[0];
        }
        public string Number
        {
            get => _number;
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(this, nameof(Number));
                }
            }
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
        public string Registration
        {
            get => _registration;
            set
            {
                if (_registration != value)
                {
                    _registration = value;
                    OnPropertyChanged(this, nameof(Registration));
                }
            }
        }
        public Vehicle Vehicle
        {
            get => _vehicle;
            set
            {
                if(_vehicle != value)
                {
                    _vehicle = value;
                    OnPropertyChanged(this, nameof(Vehicle));
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
                    IsEditEnabled = CanEditSelectedRecord();
                    IsDeleteEnabled = CanDeleteSelectedRecord();
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
        protected bool CanDeleteSelectedRecord()
        {
            if( _selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                Guid id = SearchResult[_selectedIndex].Id;
                return !_unitOfWork.FuelConsumptionRepository.Exists(x => x.FuelCardId == id);
            }
            return false;
        }
        protected bool CanEditSelectedRecord()
        {
            if ( _selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                return true;
            }
            return false;
        }
        public void Search()
        {
            SearchResult.Clear();
            IEnumerable<FuelCard> fuelCards =
                _unitOfWork
                .FuelCardRepository
                .Find(_name, _number, _registration, _vehicle.Id, q => q.OrderBy(x => x.Number));
            foreach(FuelCard fuelCard in fuelCards)
            {
                SearchResult.Add(new FuelCardViewModel(fuelCard));
            }
        }
        public void Create()
        {
            _applicationContext.DisplayFuelCardEditView(new FuelCardEditViewModel(_unitOfWork, _applicationContext, _validator));
            Search();
        }
        public void Edit()
        {
            if(_isEditEnabled && _selectedIndex >= 0 && _selectedIndex < SearchResult.Count)
            {
                FuelCard fuelCard = _unitOfWork.FuelCardRepository.Find(key: SearchResult[_selectedIndex].Id);
                if (fuelCard != null)
                {
                    _applicationContext.DisplayFuelCardEditView(
                        new FuelCardEditViewModel(fuelCard, _unitOfWork, _applicationContext, _validator));
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage(
                        title: "Error", 
                        message: $"Fuel Card # {SearchResult[_selectedIndex].Number} has been deleted and no longer exist.", 
                        buttons: MessageBoxButtons.OK, 
                        icon: MessageBoxIcon.Error);
                    Search();
                }
            }
        }
        public void Delete()
        {
            if(_isDeleteEnabled && _selectedIndex >=0 && _selectedIndex < SearchResult.Count)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confirm Delete",
                    message: $"Are You Sure You Want To Delete Fuel Card # {SearchResult[_selectedIndex].Number}?",
                    buttons: MessageBoxButtons.YesNo,
                    icon: MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    FuelCard oldCard = _unitOfWork.FuelCardRepository.Find(key: SearchResult[_selectedIndex].Id);
                    if(oldCard != null)
                    {
                        _unitOfWork.FuelCardRepository.Remove(oldCard);
                        _unitOfWork.Complete();
                    }
                    Search();
                }
            }
        }
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
        public BindingList<FuelCardViewModel> SearchResult { get; private set; } = new BindingList<FuelCardViewModel>();
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = false;
            }
        }
    }
}
