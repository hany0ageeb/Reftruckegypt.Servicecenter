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
            _unitOfWork = unitOfWork ??  throw new ArgumentNullException(nameof(unitOfWork));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
            var commands = _unitOfWork.UserCommandRepository.Find(
                predicate: com => com.IsEnabled,
                orderBy: q=>q.OrderBy(e=>e.Sequence)).ToList();
            var reports = _unitOfWork
                .UserReportRepository
                .Find(
                predicate: rpt => rpt.IsEnabled,
                orderBy: q => q.OrderBy(e=>e.Sequence)).ToList();
            // ... set each report action accoring to its name
            foreach(var report in reports)
            {
                report.Execute = () =>
                {
                    _applicationContext.DisplayView(Type.GetType(report.ParameterViewTypeName));
                };
            }
            _applicationContext.InitializeReportsMenu(reports);
            UserCommands.Clear();
            foreach(var command in commands)
            {
                switch (command.Name)
                {
                    case nameof(VehicleCategory):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleCategoriesView(true, "Export Vehicle Categories");
                        };
                        break;
                    case nameof(VehicleModel):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleModelsView(true, "Export Vehicle Models");
                        };
                        break;
                    case nameof(ExternalAutoRepairShop):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayExternalAutoRepairShopsView(true, "Export External Shops");
                        };
                        break;
                    case nameof(ExternalRepairBill):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayExternalRepairBillsView(isExportEnabled: true, exportDisplayName: "Export External Repair Bills");
                        };
                        break;
                    case nameof(Period):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayPeriodsView(true, "Export Periods");
                        };
                        break;
                    case nameof(VehicleKilometerReading):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayKilometerReadingsView(true, "Export Kilometer Readings");
                        };
                        break;
                    case nameof(FuelConsumption):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayFuelConsumptionsView(isExportEnabled: true, exportDisplayName: "Export Fuel Consumptions Data");
                        };
                        break;
                    case nameof(VehicleViolation):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleViolationsView(true, "Export Vehicle Violations");
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
                            _applicationContext.DisplaySparePartsView(true, "Export Spare Parts");
                        };
                        break;
                    case nameof(UomConversion):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayUomConversionsView();
                        };
                        break;
                    case nameof(Driver):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayDriversView(enableExport: true, exportDisplayName: "Export Drivers Data");
                        };
                        break;
                    case nameof(SparePartsPriceList):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayPriceListsView(true, "Export Price Lists");
                        };
                        break;
                    case nameof(SparePartsBill):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplaySparePartsBillsView(true, "Export Internal Invoices");
                        };
                        break;
                    case nameof(FuelCard):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayFuelCardsView(true, "Export Fuel Cards");
                        };
                        break;
                    case nameof(Vehicle):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehiclesView(true, "EXport Vehicles");
                        };
                        break;
                    case nameof(VehicleStateChange):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleSatetChangesView(true, "Export");
                        };
                        break;
                    case nameof(InternalMemo):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayInternalMemosView(enableExport: true, exportDisplayName: "Export Internal Memos ...");
                        };
                        break;
                    case nameof(PurchaseRequest):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayPurchaseRequestsView(enableExport: true, exportDisplayName: "Export Purchase Requests ...");
                        };
                        break;
                    case nameof(ReceiptLine):
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayReceiptLinesView(enableExport: true, exportDisplayName: "Export Receipts");
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
