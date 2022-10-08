using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels.Abstractions
{
    public abstract class SearchViewModelBase<T> : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private bool _isDisposed = false;
        private int _selectedIndex = -1;
        private bool _isEditEnabled = false;
        private bool _isDeleteEnabled = false;
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
                    IsDeleteEnabled = CanDeleteSelectedRecord();
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
        protected virtual bool CanDeleteSelectedRecord()
        {
            if (_selectedIndex < 0 || _selectedIndex > SearchResult.Count)
                return false;
            return true;
        }
        protected virtual bool CanEditSelectedRecord()
        {
            if (_selectedIndex < 0 || _selectedIndex > SearchResult.Count)
                return false;
            return true;
        }
        public abstract void Search();
        public abstract void Edit();
        public abstract void Delete();
        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = false;
            }
        }
        public BindingList<T> SearchResult { get; private set; } = new BindingList<T>();
    }
}
