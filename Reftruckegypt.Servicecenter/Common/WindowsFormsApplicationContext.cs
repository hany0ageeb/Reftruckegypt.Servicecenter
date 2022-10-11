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
using Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;
using Reftruckegypt.Servicecenter.Views.SparePartsBillViews;
using Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels;
using Reftruckegypt.Servicecenter.Views.FuelCardViews;
using Reftruckegypt.Servicecenter.Views.VehicleViews;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels;
using Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels;
using Reftruckegypt.Servicecenter.Views.VehicleStateChangeViews;

using Reftruckegypt.Servicecenter.Models;
using System;

namespace Reftruckegypt.Servicecenter.Common
{
    public class WindowsFormsApplicationContext : IApplicationContext
    {
        private readonly MainView _mdiParent = null;
        private readonly Dictionary<Form, EventHandler> _exportActions = new Dictionary<Form, EventHandler>();
        private readonly Dictionary<Form, IServiceScope> _scopes = new Dictionary<Form, IServiceScope>();
        private bool _isDisposed = false;
        public WindowsFormsApplicationContext(MainView mdiParent)
        {
            _mdiParent = mdiParent;
        }

        public void DisplayFuelCardsView(bool isExportEnabled = false, string displayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            FuelCardsView fuelCardsView = scope.ServiceProvider.GetRequiredService<FuelCardsView>();
            _scopes[fuelCardsView] = scope;
            fuelCardsView.MdiParent = _mdiParent;
            _mdiParent.IsExportEnabled = isExportEnabled;
            _mdiParent.SetExportDisplayName(displayName);
            if (isExportEnabled)
            {
                _exportActions.Add(fuelCardsView, (o, e) =>
                 {
                     fuelCardsView.ExportToFile();
                 });
                _mdiParent.AddExportAction(_exportActions[fuelCardsView]);
            }
            fuelCardsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            fuelCardsView.Show();
        }
        public void DisplayVehicleEditView(VehicleEditViewModel editModel)
        {
            VehicleEditView vehicleEditView = new VehicleEditView(editModel);
            vehicleEditView.ShowInTaskbar = true;
            vehicleEditView.ShowDialog(_mdiParent);
        }
        public void DisplayFuelCardEditView(FuelCardEditViewModel editModel)
        {
            FuelCardEditView fuelCardEditView = new FuelCardEditView(editModel);
            fuelCardEditView.ShowInTaskbar = false;
            fuelCardEditView.ShowDialog(_mdiParent);
        }
        public void DisplaySparePartsBillEditView(SparePartsBillEditViewModel sparePartsBillEditViewModel)
        {
            SparePartsBillEditView sparePartsBillEditView = new SparePartsBillEditView(sparePartsBillEditViewModel);
            sparePartsBillEditView.ShowInTaskbar = false;
            sparePartsBillEditView.ShowDialog(_mdiParent);
        }

        public void DisplaySparePartsBillsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            SparePartsBillsView billsView = scope.ServiceProvider.GetRequiredService<SparePartsBillsView>();
            _scopes[billsView] = scope;
            billsView.MdiParent = _mdiParent;
            billsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(billsView, (o, e) =>
                 {
                     billsView.ExportToFile();
                 });
            }
            billsView.Show();
        }
        public void DisplayPriceListsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            Views.SparePartsPriceListViews.PriceListsView priceListsView = scope.ServiceProvider.GetRequiredService<Views.SparePartsPriceListViews.PriceListsView>();
            _scopes[priceListsView] = scope;
            priceListsView.MdiParent = _mdiParent;
            priceListsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(priceListsView, (o, e) =>
                {
                    priceListsView.ExportToFile();
                });
            }
            priceListsView.Show();
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
        public void DisplaySparePartsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            SparePartsView sparePartsView = scope.ServiceProvider.GetRequiredService<SparePartsView>();
            _scopes[sparePartsView] = scope;
            sparePartsView.MdiParent = _mdiParent;
            sparePartsView.FormClosed += (o, e) =>
            {
               
                FormClosed(o as Form);
            };
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(sparePartsView, (o, e) =>
                {
                    sparePartsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[sparePartsView]);
            }
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
        public void DisplayVehicleCategoriesView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleCategoriesView vehicleCategoriesView = scope.ServiceProvider.GetRequiredService<VehicleCategoriesView>();
            _scopes[vehicleCategoriesView] = scope;
            vehicleCategoriesView.MdiParent = _mdiParent;
            vehicleCategoriesView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(vehicleCategoriesView, (o, e) =>
                {
                    vehicleCategoriesView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[vehicleCategoriesView]);
            }
            vehicleCategoriesView.Show();
        }
        public void DisplayVehicleViolationsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleViolationsView vehicleViolationsView = scope.ServiceProvider.GetRequiredService<VehicleViolationsView>();
            _scopes[vehicleViolationsView] = scope;
            vehicleViolationsView.MdiParent = _mdiParent;
            vehicleViolationsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(vehicleViolationsView, (o, e) =>
                {
                    vehicleViolationsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[vehicleViolationsView]);
            }
            vehicleViolationsView.Show();
        }
        public void DisplayFuelConsumptionsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            FuelConsumptionsView fuelConsumptionsView = scope.ServiceProvider.GetRequiredService<FuelConsumptionsView>();
            fuelConsumptionsView.MdiParent = _mdiParent;
            _scopes[fuelConsumptionsView] = scope;
            fuelConsumptionsView.FormClosed += (o, e) =>
             {
                 FormClosed(o as Form);
             };
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(fuelConsumptionsView, (o, e) =>
                {
                    fuelConsumptionsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[fuelConsumptionsView]);
            }
            
            fuelConsumptionsView.Show();
        }
        public void DisplayVehicleModelsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleModelsView vehicleModelsView = scope.ServiceProvider.GetRequiredService<VehicleModelsView>();
            _scopes[vehicleModelsView] = scope;
            vehicleModelsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleModelsView.MdiParent = _mdiParent;
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = true;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(vehicleModelsView, (o, e) =>
                {
                    vehicleModelsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[vehicleModelsView]);
            }
            vehicleModelsView.Show();
        }
        public void DisplayExternalAutoRepairShopsView(bool isExportEnabled = false, string displayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            ExternalAutoRepairShopsView externalAutoRepairShopsView = scope.ServiceProvider.GetRequiredService<ExternalAutoRepairShopsView>();
            _scopes[externalAutoRepairShopsView] = scope;
            externalAutoRepairShopsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            externalAutoRepairShopsView.MdiParent = _mdiParent;
            _mdiParent.IsExportEnabled = isExportEnabled;
            _mdiParent.SetExportDisplayName(displayName);
            if (_mdiParent.IsExportEnabled)
            {
                _exportActions.Add(externalAutoRepairShopsView, (o, e) =>
                 {
                     externalAutoRepairShopsView.ExportToFile();
                 });
                _mdiParent.AddExportAction(_exportActions[externalAutoRepairShopsView]);
            }
            externalAutoRepairShopsView.Show();
        }
        public void DisplayExternalRepairBillsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            ExternalRepairBillsView externalRepairBillsView = scope.ServiceProvider.GetRequiredService<ExternalRepairBillsView>();
            _scopes[externalRepairBillsView] = scope;
            externalRepairBillsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            externalRepairBillsView.MdiParent = _mdiParent;
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = isExportEnabled;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(externalRepairBillsView, (o, e) =>
                {
                    externalRepairBillsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[externalRepairBillsView]);
            }
            externalRepairBillsView.Show();
        }
        public void DisplayPeriodsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            PeriodsView periodsView = scope.ServiceProvider.GetRequiredService<PeriodsView>();
            _scopes[periodsView] = scope;
            periodsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            periodsView.MdiParent = _mdiParent;
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = isExportEnabled;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(periodsView, (o, e) =>
                {
                    periodsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[periodsView]);
            }
            periodsView.Show();
        }
        public void DisplayKilometerReadingsView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleKilometerReadingsView vehicleKilometerReadingsView = scope.ServiceProvider.GetRequiredService<VehicleKilometerReadingsView>();
            _scopes[vehicleKilometerReadingsView] = scope;
            vehicleKilometerReadingsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleKilometerReadingsView.MdiParent = _mdiParent;
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = isExportEnabled;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(vehicleKilometerReadingsView, (o, e) =>
                {
                    vehicleKilometerReadingsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[vehicleKilometerReadingsView]);
            }
            vehicleKilometerReadingsView.Show();
        }

        public void DisplayVehicleSatetChangesView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleStateChangesView vehicleKilometerReadingsView = scope.ServiceProvider.GetRequiredService<VehicleStateChangesView>();
            _scopes[vehicleKilometerReadingsView] = scope;
            vehicleKilometerReadingsView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleKilometerReadingsView.MdiParent = _mdiParent;
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = isExportEnabled;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(vehicleKilometerReadingsView, (o, e) =>
                {
                    vehicleKilometerReadingsView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[vehicleKilometerReadingsView]);
            }
            vehicleKilometerReadingsView.Show();
        }
        public void DisplayDriversView(bool enableExport = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            DriversView driversView = scope.ServiceProvider.GetRequiredService<DriversView>();
            _scopes[driversView] = scope;
            driversView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            if (enableExport)
            {
                _mdiParent.IsExportEnabled = enableExport;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(driversView, (o, e) =>
                {
                    driversView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[driversView]);
            }
            driversView.MdiParent = _mdiParent;
            driversView.Show();
        }
        public void DisplayVehiclesView(bool isExportEnabled = false, string exportDisplayName = "Export")
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehiclesView vehiclesView = scope.ServiceProvider.GetRequiredService<VehiclesView>();
            _scopes[vehiclesView] = scope;
            vehiclesView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehiclesView.MdiParent = _mdiParent;
            if (isExportEnabled)
            {
                _mdiParent.IsExportEnabled = isExportEnabled;
                _mdiParent.SetExportDisplayName(exportDisplayName);
                _exportActions.Add(vehiclesView, (o, e) =>
                {
                    vehiclesView.ExportToFile();
                });
                _mdiParent.AddExportAction(_exportActions[vehiclesView]);
            }
            vehiclesView.Show();
        }
        private void FormClosed(Form sender)
        {
            if (sender != null && _scopes.ContainsKey(sender))
            {
                if (_exportActions.ContainsKey(sender))
                {
                    _mdiParent.RemoveExportAction(_exportActions[sender]);
                    _exportActions.Remove(sender);
                }
                _mdiParent.IsExportEnabled = false;
                _mdiParent.SetExportDisplayName("Export");
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
        public void DisplayPriceListEditView(SparePartPriceListEditViewModel sparePartPriceListEditViewModel)
        {
            Views.SparePartsPriceListViews.SparePartsPriceListEditView sparePartsPriceListEditView = new Views.SparePartsPriceListViews.SparePartsPriceListEditView(sparePartPriceListEditViewModel);
            sparePartsPriceListEditView.ShowInTaskbar = false;
            _ = sparePartsPriceListEditView.ShowDialog(_mdiParent);
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

        public void DisplayVehicleStateChangeEditView(VehicleStateChangesEditModel vehicleStateChangesEditModel)
        {
            VehicleStateChangesEditView vehicleStateChangesEditView = new Views.VehicleStateChangeViews.VehicleStateChangesEditView(vehicleStateChangesEditModel);
            vehicleStateChangesEditView.ShowInTaskbar = false;
            vehicleStateChangesEditView.ShowDialog(_mdiParent);
        }

    }
}
