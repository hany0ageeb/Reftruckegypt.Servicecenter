using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Reports.ReportsParameterViews
{
    public partial class FuelConsumptionReportParametersView : Form
    {
        private FuelConsumptionSearchViewModel _searchModel;
        public FuelConsumptionReportParametersView(FuelConsumptionSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initilaize();
        }
        private void Initilaize()
        {
            // ...
            cboCategories.DataBindings.Clear();
            cboCategories.DataSource = _searchModel.VehicleCategories;
            cboCategories.DisplayMember = nameof(Models.VehicleCategory.Name);
            cboCategories.ValueMember = nameof(Models.VehicleCategory.Self);
            cboCategories.DataBindings.Add(new Binding(nameof(cboCategories.SelectedItem), _searchModel, nameof(_searchModel.VehicleCategory))
            {

            });
            // ...
            cboFuelCards.DataBindings.Clear();
            cboFuelCards.DataSource = _searchModel.FuelCards;
            cboFuelCards.DisplayMember = nameof(Models.FuelCard.Number);
            cboFuelCards.ValueMember = nameof(Models.FuelCard.Self);
            cboFuelCards.DataBindings.Add(new Binding(nameof(cboFuelCards.SelectedItem), _searchModel, nameof(_searchModel.FuelCard))
            {

            });
            // ...
            cboFuelTypes.DataBindings.Clear();
            cboFuelTypes.DataSource = _searchModel.FuelTypes;
            cboFuelTypes.DisplayMember = nameof(Models.FuelType.Name);
            cboFuelTypes.ValueMember = nameof(Models.FuelType.Self);
            cboFuelTypes.DataBindings.Add(new Binding(nameof(cboFuelTypes.SelectedItem), _searchModel, nameof(_searchModel.FuelType))
            {

            });
            // ...
            cboModels.DataBindings.Clear();
            cboModels.DataSource = _searchModel.VehicleModels;
            cboModels.DisplayMember = nameof(Models.VehicleModel.Name);
            cboModels.ValueMember = nameof(Models.VehicleModel.Self);
            cboModels.DataBindings.Add(new Binding(nameof(cboModels.SelectedItem), _searchModel, nameof(_searchModel.VehicleModel))
            {

            });
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {

            });
            // ...
            pickFromDate.ValueChanged += (o, e) =>
            {
                if (pickFromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(pickFromDate.Value.Year, pickFromDate.Value.Month, pickFromDate.Value.Day, 0, 0, 0);
                }
                else
                {
                    _searchModel.FromDate = null;
                }
            };
            // ...
            pickToDate.ValueChanged += (o, e) =>
            {
                if (pickToDate.Checked)
                {
                    _searchModel.ToDate = new DateTime(pickToDate.Value.Year, pickToDate.Value.Month, pickToDate.Value.Day, 23, 59, 59);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ....

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchModel.Search();
            ReportsViews.FuelConsumptionReportView fuelConsumptionReportView = new ReportsViews.FuelConsumptionReportView(_searchModel.FuelConsumptions.ToList())
            {
                MdiParent = this.MdiParent
            };
            fuelConsumptionReportView.Show();
            Close();
        }
    }
}
