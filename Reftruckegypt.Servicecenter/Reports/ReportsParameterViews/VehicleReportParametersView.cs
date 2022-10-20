using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels;
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
    public partial class VehicleReportParametersView : Form
    {
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();
        private readonly VehicleSearchViewModel _searchModel;
        public VehicleReportParametersView(VehicleSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel ?? throw new ArgumentNullException(nameof(searchViewModel));
            _vehicles.AddRange(_searchModel.FindAll());
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            cboVehicles.DataSource = _vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            if (_vehicles.Count > 0)
                cboVehicles.SelectedIndex = 0;
            else
                cboVehicles.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = null;
            if (cboVehicles.SelectedIndex >= 0 && cboVehicles.SelectedIndex < _vehicles.Count)
                vehicle = _vehicles[cboVehicles.SelectedIndex];
            IList<VehicleViewModel> data = _searchModel.FindVehiclesWithRelatedTransactions(
                vehicle?.Id, 
                _fromDate, 
                _toDate);
            ReportsViews.VehicleReportView vehicleReportView = new ReportsViews.VehicleReportView(data, _fromDate, _toDate);
            vehicleReportView.MdiParent = this.MdiParent;
            vehicleReportView.Show();
            Close();
        }

        private void pickFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (pickFromDate.Checked)
            {
                _fromDate = new DateTime(pickFromDate.Value.Year, pickFromDate.Value.Month, pickFromDate.Value.Day,0,0,0);
            }
            else
            {
                _fromDate = null;
            }
        }

        private void picktodate_ValueChanged(object sender, EventArgs e)
        {
            if (picktodate.Checked)
            {
                _toDate = new DateTime(picktodate.Value.Year, picktodate.Value.Month, picktodate.Value.Day, 23, 59, 59);
            }
            else
            {
                _toDate = null;
            }
        }
    }
}
