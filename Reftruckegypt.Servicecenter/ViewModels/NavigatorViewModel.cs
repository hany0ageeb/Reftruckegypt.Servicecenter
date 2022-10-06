using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels
{
    public class NavigatorViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private bool _isDisposed = false;
        public NavigatorViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            var commands = _unitOfWork.UserCommandRepository.Find(
                predicate: com => com.IsEnabled,
                orderBy: q=>q.OrderBy(e=>e.Sequence)).ToList();
            UserCommands.Clear();
            foreach(var command in commands)
            {
                switch (command.Name)
                {
                    case nameof(VehicleCategory):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleCategoriesView();
                        };
                        break;
                    case nameof(VehicleModel):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleModelsView();
                        };
                        break;
                    case nameof(ExternalAutoRepairShop):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayExternalAutoRepairShopsView();
                        };
                        break;
                    case nameof(ExternalRepairBill):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayExternalRepairBillsView();
                        };
                        break;
                    case nameof(Period):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayPeriodsView();
                        };
                        break;
                    case nameof(VehicleKilometerReading):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayKilometerReadingsView();
                        };
                        break;
                    case nameof(FuelConsumption):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayFuelConsumptionsView();
                        };
                        break;
                    case nameof(VehicleViolation):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleViolationsView();
                        };
                        break;
                    case nameof(Uom):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayUomsView();
                        };
                        break;
                    case nameof(SparePart):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplaySparePartsView();
                        };
                        break;
                    case nameof(UomConversion):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayUomConversionsView();
                        };
                        break;
                }
                UserCommands.Add(command);
            }
        }
        public bool Close()
        {
            var result = _applicationContext.DisplayMessage("Confirm", "Are you sure you want to exits?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return false;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }

        public BindingList<Models.UserCommand> UserCommands { get; private set; } = new BindingList<Models.UserCommand>();

    }
    
}
