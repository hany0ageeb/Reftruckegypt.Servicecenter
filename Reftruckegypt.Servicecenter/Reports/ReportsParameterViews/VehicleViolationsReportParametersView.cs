using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
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
    public partial class VehicleViolationsReportParametersView : Form
    {
        private VehicleViolationSearchViewModel _searchModel;
        public VehicleViolationsReportParametersView(VehicleViolationSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            pickFromDate.ValueChanged += (o, e) =>
            {
                if (pickFromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(
                        pickFromDate.Value.Year,
                        pickFromDate.Value.Month,
                        pickFromDate.Value.Day, 0, 0, 0);
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
                    _searchModel.ToDate = new DateTime(
                        pickToDate.Value.Year,
                        pickToDate.Value.Month,
                        pickToDate.Value.Day, 23, 59, 59);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _searchModel.Search();
            var data = _searchModel.VehicleViolationViewModels.ToList();
            var result = data.GroupBy(x => new { VehicleCode = x.VehicleCode, VehiclePlateNumber = x.VehiclePlateNumber }).Select(g => new VehicleViolationViewModel() { Count = g.Sum(x => x.Count) , VehicleCode = g.Key.VehicleCode, VehiclePlateNumber = g.Key.VehiclePlateNumber});
            ReportsViews.VehicleViolationsReportView vehicleViolationsReportView = 
                new ReportsViews.VehicleViolationsReportView(result.ToList(), _searchModel.FromDate?.ToString("yyyy/MM/dd HH:mm:ss")??"", _searchModel.ToDate?.ToString("yyyy/MM/dd HH:mm:ss") ??"");
            vehicleViolationsReportView.MdiParent = this.MdiParent;
            vehicleViolationsReportView.Show();
            Close();
        }
    }
}
