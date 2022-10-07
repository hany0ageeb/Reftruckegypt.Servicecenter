using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Reftruckegypt.Servicecenter.Views.VehicleCategoryViews;
using Reftruckegypt.Servicecenter.Views;
using System.Collections.Generic;
using Reftruckegypt.Servicecenter.Views.VehicleModelViews;
using Reftruckegypt.Servicecenter.Views.ExternalRepairBillViews;
using Reftruckegypt.Servicecenter.Views.ExternalAutoRepairShopViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using Reftruckegypt.Servicecenter.Views.PeriodViews;
using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;
using Reftruckegypt.Servicecenter.Views.VehicleKilometerReadingViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels;
using Reftruckegypt.Servicecenter.Views.FuelConsumptionViews;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;
using Reftruckegypt.Servicecenter.Views.VehicleViolationViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
using Reftruckegypt.Servicecenter.Views.UomViews;
using Reftruckegypt.Servicecenter.ViewModels.UomViewModels;
using Reftruckegypt.Servicecenter.Views.SparePartViews;
using Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels;
using Reftruckegypt.Servicecenter.Views.UomConversionViews;
using Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;
using Reftruckegypt.Servicecenter.Views.DriverViews;

namespace Reftruckegypt.Servicecenter.Common
{
    public class WindowsFormsApplicationContext : IApplicationContext
    {
        private readonly Form _mdiParent = null;
        private readonly Dictionary<Form, IServiceScope> _scopes = new Dictionary<Form, IServiceScope>();
        private bool _isDisposed = false;
        public WindowsFormsApplicationContext(Form mdiParent)
        {
            _mdiParent = mdiParent;
        }

        public void DisplayUomConversionsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            UomConversionsView uomConversionsView = scope.ServiceProvider.GetRequiredService<UomConversionsView>();
            _scopes[uomConversionsView] = scope;
            uomConversionsView.MdiParent = _mdiParent;
            uomConversionsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            uomConversionsView.Show();
        }
        public void DisplaySparePartsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            SparePartsView sparePartsView = scope.ServiceProvider.GetRequiredService<SparePartsView>();
            _scopes[sparePartsView] = scope;
            sparePartsView.MdiParent = _mdiParent;
            sparePartsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            sparePartsView.Show();
        }
        public void DisplayUomsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            UomsView uomsView = scope.ServiceProvider.GetRequiredService<UomsView>();
            _scopes[uomsView] = scope;
            uomsView.MdiParent = _mdiParent;
            uomsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            uomsView.Show();
        }
        public void DisplayVehicleCategoriesView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleCategoriesView vehicleCategoriesView = scope.ServiceProvider.GetRequiredService<VehicleCategoriesView>();
            _scopes[vehicleCategoriesView] = scope;
            vehicleCategoriesView.MdiParent = _mdiParent;
            vehicleCategoriesView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleCategoriesView.Show();
        }
        public void DisplayVehicleViolationsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleViolationsView vehicleViolationsView = scope.ServiceProvider.GetRequiredService<VehicleViolationsView>();
            _scopes[vehicleViolationsView] = scope;
            vehicleViolationsView.MdiParent = _mdiParent;
            vehicleViolationsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleViolationsView.Show();
        }
        public void DisplayFuelConsumptionsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            FuelConsumptionsView fuelConsumptionsView = scope.ServiceProvider.GetRequiredService<FuelConsumptionsView>();
            fuelConsumptionsView.MdiParent = _mdiParent;
            _scopes[fuelConsumptionsView] = scope;
            fuelConsumptionsView.FormClosed += (o, e) =>
             {
                 FormClosed(o as Form);
             };
            fuelConsumptionsView.Show();
        }
        public void DisplayVehicleModelsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleModelsView vehicleModelsView = scope.ServiceProvider.GetRequiredService<VehicleModelsView>();
            _scopes[vehicleModelsView] = scope;
            vehicleModelsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleModelsView.MdiParent = _mdiParent;
            vehicleModelsView.Show();
        }
        public void DisplayExternalAutoRepairShopsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            ExternalAutoRepairShopsView externalAutoRepairShopsView = scope.ServiceProvider.GetRequiredService<ExternalAutoRepairShopsView>();
            _scopes[externalAutoRepairShopsView] = scope;
            externalAutoRepairShopsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            externalAutoRepairShopsView.MdiParent = _mdiParent;
            externalAutoRepairShopsView.Show();
        }
        public void DisplayExternalRepairBillsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            ExternalRepairBillsView externalRepairBillsView = scope.ServiceProvider.GetRequiredService<ExternalRepairBillsView>();
            _scopes[externalRepairBillsView] = scope;
            externalRepairBillsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            externalRepairBillsView.MdiParent = _mdiParent;
            externalRepairBillsView.Show();
        }
        public void DisplayPeriodsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            PeriodsView periodsView = scope.ServiceProvider.GetRequiredService<PeriodsView>();
            _scopes[periodsView] = scope;
            periodsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            periodsView.MdiParent = _mdiParent;
            periodsView.Show();
        }
        public void DisplayKilometerReadingsView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleKilometerReadingsView vehicleKilometerReadingsView = scope.ServiceProvider.GetRequiredService<VehicleKilometerReadingsView>();
            _scopes[vehicleKilometerReadingsView] = scope;
            vehicleKilometerReadingsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleKilometerReadingsView.MdiParent = _mdiParent;
            vehicleKilometerReadingsView.Show();
        }
        public void DisplayDriversView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            DriversView driversView = scope.ServiceProvider.GetRequiredService<DriversView>();
            _scopes[driversView] = scope;
            driversView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            driversView.MdiParent = _mdiParent;
            driversView.Show();
        }
        private void FormClosed(Form sender)
        {
            if (sender != null && _scopes.ContainsKey(sender))
            {
                _scopes[sender].Dispose();
                _scopes.Remove(sender);
            }
        }
        public void DisplaySparePartEditView(SparePartEditViewModel editModel)
        {
            SparePartEditView sparePartEditView = new SparePartEditView(editModel);
            sparePartEditView.ShowInTaskbar = false;
            sparePartEditView.ShowDialog(_mdiParent);
        }
        public void DisplayUomEditView(UomEditViewModel uomEditViewModel)
        {
            UomEditView uomEditView = new UomEditView(uomEditViewModel);
            uomEditView.ShowInTaskbar = false;
            uomEditView.ShowDialog(_mdiParent);
        }
        public void DisplayFuelConsumptionEditView(FuelConsumptionEditViewModel fuelConsumptionEditViewModel)
        {
            FuelConsumptionEditView fuelConsumptionEditView = new FuelConsumptionEditView(fuelConsumptionEditViewModel);
            fuelConsumptionEditView.ShowInTaskbar = false;
            fuelConsumptionEditView.ShowDialog(_mdiParent);
        }
        public void DisplayKilometerReadingEditView(VehicleKilometerReadingEditViewModel model)
        {
            VehicleKilometerReadingEditView vehicleKilometerReadingEditView = new VehicleKilometerReadingEditView(model);
            vehicleKilometerReadingEditView.ShowInTaskbar = false;
            _ = vehicleKilometerReadingEditView.ShowDialog(_mdiParent);
        }
        public void DisplayVehicleCategoryEditView(VehicleCategoryEditViewModel _editModel)
        {
            VehicleCategoryEditView vehicleCategoryEditView = new VehicleCategoryEditView(_editModel)
            {
                //MdiParent = _mdiParent
            };
            vehicleCategoryEditView.ShowDialog(_mdiParent);
        }
        public void DisplayVehicleViolationEditView(VehicleViolationEditViewModel vehicleVilationEditViewModel)
        {
            VehicleViolationEditView vehicleViolationEditView = new VehicleViolationEditView(vehicleVilationEditViewModel);
            vehicleViolationEditView.ShowInTaskbar = false;
            vehicleViolationEditView.Show(_mdiParent);
        }
        public void DisplayVehicleModelEditView(VehicleModelEditViewModel editModel)
        {
            VehicleModelEditView vehicleModelEditView = new VehicleModelEditView(editModel);
            vehicleModelEditView.ShowInTaskbar = false;
            vehicleModelEditView.ShowDialog(_mdiParent);
        }
        public void DisplayExternalRepairShopEditView(ExternalAutoRepairShopEditViewModel editModel)
        {
            ExternalAutoRepairShopEditView externalAutoRepairShopEditView = new ExternalAutoRepairShopEditView(editModel);
            externalAutoRepairShopEditView.ShowInTaskbar = false;
            externalAutoRepairShopEditView.ShowDialog(_mdiParent);
        }
        public void DisplayExternalRepaiBillEditView(ExternalRepairBillEditViewModel editViewModel)
        {
            ExternalRepairBillEditView externalRepairBillEditView = new ExternalRepairBillEditView(editViewModel);
            externalRepairBillEditView.ShowInTaskbar = false;
            externalRepairBillEditView.ShowDialog(_mdiParent);
        }
        public void DisplayPeriodEditView(PeriodEditViewModel periodEditViewModel)
        {
            PeriodEditView periodEditView = new PeriodEditView(periodEditViewModel);
            periodEditView.ShowInTaskbar = false;
            periodEditView.ShowDialog(_mdiParent);
        }
        public void DisplayUomConversionEditView(UomConversionEditViewModel editModel)
        {
            UomConversionEditView uomConversionEditView = new UomConversionEditView(editModel);
            uomConversionEditView.ShowInTaskbar = false;
            uomConversionEditView.ShowDialog(_mdiParent);
        }
        public void DisplayDriverEditView(DriverEditViewModel driverEditViewModel)
        {
            DriverEditView driverEditView = new DriverEditView(driverEditViewModel);
            driverEditView.ShowInTaskbar = false;
            _ = driverEditView.ShowDialog(_mdiParent);
        }
        public DialogResult DisplayMessage(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            switch (buttons)
            {
                case MessageBoxButtons.YesNo:
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        default:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information);
                            break;
                    }
                    break;
                case MessageBoxButtons.YesNoCancel:
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        case MessageBoxIcon.Information:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Information);
                            break;
                        default:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Information);
                            break;

                    }
                    break;
                default:
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        case MessageBoxIcon.Information:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            break;
                        default:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            break;
                    }
                    break;
            }
            switch (result)
            {
                case System.Windows.Forms.DialogResult.None:
                    return DialogResult.None;
                case System.Windows.Forms.DialogResult.Yes:
                    return DialogResult.Yes;
                case System.Windows.Forms.DialogResult.No:
                    return DialogResult.No;
                case System.Windows.Forms.DialogResult.Cancel:
                    return DialogResult.Cancel;
                default:
                    return DialogResult.None;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                foreach(var kvp in _scopes)
                {
                    kvp.Value?.Dispose();
                }
                _isDisposed = true;
            }
        }

       
    }
}
