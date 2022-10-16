using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;
using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels;
using Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels;
using Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels;
using Reftruckegypt.Servicecenter.ViewModels.UomViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Common
{
    public interface IApplicationContext : IDisposable
    {
        DialogResult DisplayMessage(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon);
        void DisplayVehicleCategoryEditView(VehicleCategoryEditViewModel _editModel);
        void DisplayVehicleModelEditView(VehicleModelEditViewModel editModel);
        void DisplayVehicleCategoriesView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayVehicleModelsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayExternalAutoRepairShopsView(bool isExportEnabled = false, string displayName = "Export");
        void DisplayExternalRepairShopEditView(ExternalAutoRepairShopEditViewModel editModel);
        void DisplayExternalRepairBillsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayExternalRepaiBillEditView(ExternalRepairBillEditViewModel editViewModel);
        void DisplayPeriodsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayPeriodEditView(PeriodEditViewModel periodEditViewModel);
        void DisplayKilometerReadingsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayKilometerReadingEditView(VehicleKilometerReadingEditViewModel model);
        void DisplayFuelConsumptionsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayFuelConsumptionEditView(FuelConsumptionEditViewModel fuelConsumptionEditViewModel);
        void DisplayVehicleViolationsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayVehicleViolationEditView(VehicleViolationEditViewModel vehicleVilationEditViewModel);
        void DisplayUomsView();
        void DisplayUomEditView(UomEditViewModel uomEditViewModel);
        void DisplaySparePartsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplaySparePartEditView(SparePartEditViewModel editModel);
        void DisplayUomConversionsView();
        void DisplayUomConversionEditView(UomConversionEditViewModel editModel);
        void DisplayDriverEditView(DriverEditViewModel driverEditViewModel);
        void DisplayDriversView(bool enableExport = false, string exportDisplayName = "Export");
        void DisplayPriceListEditView(SparePartPriceListEditViewModel sparePartPriceListEditViewModel);
        void DisplayPriceListsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplaySparePartsBillEditView(SparePartsBillEditViewModel sparePartsBillEditViewModel);
        void DisplaySparePartsBillsView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayFuelCardsView(bool isExportEnabled = false, string displayName = "Export");
        void DisplayFuelCardEditView(FuelCardEditViewModel editModel);
        void DisplayVehiclesView(bool isExportEnabled = false, string exportDisplayName = "Export");
        void DisplayVehicleEditView(VehicleEditViewModel editModel);
        void DisplayVehicleStateChangeEditView(VehicleStateChangesEditModel vehicleStateChangesEditModel);
        void DisplayVehicleSatetChangesView(bool isExportEnabled = false, string exportDisplayName = "Export");

        void InitializeReportsMenu(IEnumerable<UserReport> reports);
        void DisplayView(Type type);
    }
   
}
