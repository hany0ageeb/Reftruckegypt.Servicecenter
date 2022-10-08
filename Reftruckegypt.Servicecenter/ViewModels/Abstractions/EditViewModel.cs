using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.ComponentModel;

namespace Reftruckegypt.Servicecenter.ViewModels.Abstractions
{
    public abstract class EditViewModel<T> : ViewModelBase, IDataErrorInfo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<T> _validator;
        private readonly T _model;
        public EditViewModel(
            T model,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<T> validator)
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
            if (validator != null)
            {
                _validator = validator;
            }
            _model = model;
        }
        private bool _hasChanged = false;
        public bool HasChanged
        {
            get => _hasChanged;
            protected set
            {
                if (_hasChanged != value)
                {
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public abstract T Model { get; }
        public virtual ModelState Validate()
        {
            return _validator.Validate(_model);
        }
        public abstract bool SaveOrUpdate();
        public virtual bool Close()
        {
            if (_hasChanged)
            {
                DialogResult result = _applicationContext.DisplayMessage(
                    title: "Confrim Save",
                    message: "Do You Want To Save Changes?",
                    buttons: MessageBoxButtons.YesNoCancel,
                    icon: MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    return SaveOrUpdate();
                }
                else if (result == DialogResult.No)
                {
                    HasChanged = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public virtual string Error => Validate().Error;
        public virtual string this[string columnName] => Validate()[columnName];
    }
}
