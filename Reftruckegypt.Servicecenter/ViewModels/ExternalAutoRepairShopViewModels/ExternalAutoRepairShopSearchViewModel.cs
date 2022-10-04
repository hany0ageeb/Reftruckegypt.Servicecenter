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

namespace Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels
{
    public class ExternalAutoRepairShopSearchViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<ExternalAutoRepairShop> _validator;

        private bool _isDisposed = false;
        private string _name = "";
        private string _address = "";
        private int _selectedIndex = -1;
        private bool _canDelete = false;
        private bool _canEdit = false;
        public ExternalAutoRepairShopSearchViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext, IValidator<ExternalAutoRepairShop> validator)
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
        public string Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(this, nameof(Address));
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
                    IsDeleteEnabled = CanDelete(_selectedIndex);
                }
                if (_selectedIndex < 0 || _selectedIndex >= ExternalAutoRepairShopViewModels.Count)
                {
                    IsEditEnabled = false;
                }
                else
                {
                    IsEditEnabled = true;
                }
            }
        }
        private bool CanDelete(int index)
        {
            if(index >=0 && index < ExternalAutoRepairShopViewModels.Count)
            {
                var shopId = ExternalAutoRepairShopViewModels[index].Id;
                return !_unitOfWork.ExternalRepairBillRepository.Exists(e => e.ExternalAutoRepairShopId == shopId);
            }
            return false;
        }
        public bool IsDeleteEnabled
        {
            get => _canDelete;
            private set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    OnPropertyChanged(this, nameof(IsDeleteEnabled));
                }
            }
        }
        public bool IsEditEnabled
        {
            get => _canEdit;
            private set
            {
                if (_canEdit != value)
                {
                    _canEdit = value;
                    OnPropertyChanged(this, nameof(IsEditEnabled));
                }
            }
        }
        public void Search()
        {
            ExternalAutoRepairShopViewModels.Clear();
            var shops = _unitOfWork.ExternalAutoRepairShopRepository.Find(e => e.Name.Contains(_name) && e.Address.Contains(_address));
            foreach(var shop in shops)
            {
                ExternalAutoRepairShopViewModels.Add(new ExternalAutoRepairShopViewModel(shop));
            }
        }
        public void Delete()
        {
            if(_selectedIndex >= 0 && _selectedIndex < ExternalAutoRepairShopViewModels.Count)
            {
                var result = _applicationContext.DisplayMessage("Confirm Delete", $"Are You Sure You Want To Delete Extenral Shop: {ExternalAutoRepairShopViewModels[_selectedIndex].Name}?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    var shop = _unitOfWork.ExternalAutoRepairShopRepository.Find(ExternalAutoRepairShopViewModels[_selectedIndex].Id);
                    if (shop != null)
                    {
                        _unitOfWork.ExternalAutoRepairShopRepository.Remove(shop);
                        _unitOfWork.Complete();
                    }
                    else
                    {
                        _applicationContext.DisplayMessage("Info", $"External Shop {ExternalAutoRepairShopViewModels[_selectedIndex].Name} no longer exist",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    Search();
                }
            }
        }
        public void Edit()
        {
            if(_selectedIndex >= 0 && _selectedIndex < ExternalAutoRepairShopViewModels.Count)
            {
                var shop = _unitOfWork.ExternalAutoRepairShopRepository.Find(ExternalAutoRepairShopViewModels[_selectedIndex].Id);
                if (shop != null)
                {
                    _applicationContext.DisplayExternalRepairShopEditView(new ExternalAutoRepairShopEditViewModel(_unitOfWork, _applicationContext, _validator,shop));
                    Search();
                }
                else
                {
                    _ = _applicationContext.DisplayMessage("Error", $"External Shop: {ExternalAutoRepairShopViewModels[_selectedIndex].Name} no longer Exist!\n Pleas Reload External Shops Data by clicking search button", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void Create()
        {
            _applicationContext.DisplayExternalRepairShopEditView(new ExternalAutoRepairShopEditViewModel(_unitOfWork, _applicationContext, _validator));
            Search();
        }
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }

        public BindingList<ExternalAutoRepairShopViewModel> ExternalAutoRepairShopViewModels { get; private set; } = new BindingList<ExternalAutoRepairShopViewModel>();
    }
}
