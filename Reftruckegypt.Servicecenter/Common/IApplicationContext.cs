using Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Common
{
    public interface IApplicationContext
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
    }
   
}
