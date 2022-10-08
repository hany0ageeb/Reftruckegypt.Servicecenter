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
        void DisplayVehicleCategoriesView();
        void DisplayVehicleModelsView();
        void DisplayExternalAutoRepairShopsView();
        void DisplayExternalRepairShopEditView(ExternalAutoRepairShopEditViewModel editModel);
        void DisplayExternalRepairBillsView();
        void DisplayExternalRepaiBillEditView(ExternalRepairBillEditViewModel editViewModel);
        void DisplayPeriodsView();
        void DisplayPeriodEditView(PeriodEditViewModel periodEditViewModel);
        void DisplayKilometerReadingsView();
        void DisplayKilometerReadingEditView(VehicleKilometerReadingEditViewModel model);
        void DisplayFuelConsumptionsView();
        void DisplayFuelConsumptionEditView(FuelConsumptionEditViewModel fuelConsumptionEditViewModel);
        void DisplayVehicleViolationsView();
        void DisplayVehicleViolationEditView(VehicleViolationEditViewModel vehicleVilationEditViewModel);
        void DisplayUomsView();
        void DisplayUomEditView(UomEditViewModel uomEditViewModel);
        void DisplaySparePartsView();
        void DisplaySparePartEditView(SparePartEditViewModel editModel);
        void DisplayUomConversionsView();
        void DisplayUomConversionEditView(UomConversionEditViewModel editModel);
        void DisplayDriverEditView(DriverEditViewModel driverEditViewModel);
        void DisplayDriversView();
        void DisplayPriceListEditView(SparePartPriceListEditViewModel sparePartPriceListEditViewModel);
        void DisplayPriceListsView();
        void DisplaySparePartsBillEditView(SparePartsBillEditViewModel sparePartsBillEditViewModel);
        void DisplaySparePartsBillsView();
        void DisplayFuelCardsView();
        void DisplauFuelCardEditView(FuelCardEditViewModel editModel);
        void DisplayFuelCardEditView(FuelCardEditViewModel fuelCardEditViewModel);
    }
   
}
