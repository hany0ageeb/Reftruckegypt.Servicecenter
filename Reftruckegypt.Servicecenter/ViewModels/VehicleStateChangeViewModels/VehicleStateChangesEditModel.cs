using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels
{
    public class VehicleStateChangesEditModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private readonly IValidator<VehicleStateChange> _validator;

        private bool _hasChanged = false;

        public VehicleStateChangesEditModel(
           IUnitOfWork unitOfWork,
           IApplicationContext applicationContext,
           IValidator<VehicleStateChange> validator)
            : this(null,unitOfWork, applicationContext, validator)
        {
        }
            public VehicleStateChangesEditModel(
            IEnumerable<VehicleStateChange> changes,
            IUnitOfWork unitOfWork,
            IApplicationContext applicationContext,
            IValidator<VehicleStateChange> validator)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            _validator = validator;
            Vehicles.AddRange(_unitOfWork.VehicleRepository.Find(q => q.OrderBy(x => x.InternalCode)));
            if (changes != null)
            {
                foreach (var change in changes)
                {
                    originalLines.Add(change);
                    Lines.Add(new VehicleStateChangeEditModel(change)
                    {
                        Validator = _validator
                    });
                    if (!Vehicles.Contains(change.Vehicle))
                    {
                        Vehicles.Add(change.Vehicle);
                    }
                }
            }
            Lines.ListChanged += (o, e) =>
            {
                if (e.PropertyDescriptor?.Name != "HasChanged")
                {
                    HasChanged = true;
                }
                if (e.ListChangedType == ListChangedType.ItemAdded)
                {
                    if (e.NewIndex >= 0 && e.NewIndex < Lines.Count)
                    {
                        Lines[e.NewIndex].Validator = _validator;
                        if (Vehicles.Count > 0)
                            Lines[e.NewIndex].Vehicle = Vehicles[0];
                    }
                    HasChanged = true;
                }
                else if (e.ListChangedType == ListChangedType.ItemDeleted)
                {
                    HasChanged = true;
                }
            };
            HasChanged = false;
        }
        public bool HasChanged
        {
            get => _hasChanged;
            private set
            {
                if(_hasChanged != value)
                {
                    _hasChanged = value;
                    OnPropertyChanged(this, nameof(HasChanged));
                }
            }
        }
        public bool SaveOrUpdate()
        {
            if (_hasChanged)
            {
                for(int index = 0; index<Lines.Count; index++)
                {
                    ModelState modelState = Lines[index].Validate();
                    if (modelState.HasErrors)
                    {
                        _applicationContext.DisplayMessage(
                            title: "Validation Error",
                            message: $"Line # {index + 1} is invalid.\nError Message: {modelState.GetError()}",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }
                foreach(var line in Lines)
                {
                    if(line.Id == Guid.Empty)
                    {
                        VehicleStateChange vehicleStateChange = line.VehicleStateChange;
                        vehicleStateChange.Id = Guid.NewGuid();
                        _unitOfWork.VehicleStateChangeRepository.Add(vehicleStateChange);
                    }
                    else
                    {
                        var oldLine = _unitOfWork.VehicleStateChangeRepository.Find(key: line.Id);
                        oldLine.Notes = line.Notes;
                        oldLine.Vehicle = line.Vehicle;
                        oldLine.ToDate = line.ToDate;
                        oldLine.FromDate = line.FromDate;
                    }
                }
                IEnumerable<VehicleStateChange> deletdLines = originalLines.Where(x => !Lines.Select(z => z.Id).Contains(x.Id));
                foreach(var deletedLine in deletdLines)
                {
                    var line =_unitOfWork.VehicleStateChangeRepository.Find(key: deletedLine.Id);
                    _unitOfWork.VehicleStateChangeRepository.Remove(line);
                }
                _unitOfWork.Complete();
                HasChanged = false;
                return true;
            }
            return true;
        }
        public bool Close()
        {
            if (_hasChanged)
            {
                DialogResult dialogResult =
                    _applicationContext.DisplayMessage(
                        title: "Confrim Save",
                        message: $"Do You Want To Save Changes?",
                        buttons: MessageBoxButtons.YesNoCancel,
                        icon: MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    return SaveOrUpdate();
                }
                else if(dialogResult == DialogResult.No)
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
        private List<VehicleStateChange> originalLines = new List<VehicleStateChange>();
        public BindingList<VehicleStateChangeEditModel> Lines { get; private set; } = new BindingList<VehicleStateChangeEditModel>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
    }
}
