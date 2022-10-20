using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;

namespace Reftruckegypt.Servicecenter.Reports.ReportsParameterViews
{
    public partial class FuelConsumptionByFuelCardReportParametersView : Form
    {
        private readonly FuelConsumptionSearchViewModel _searchModel;
        public FuelConsumptionByFuelCardReportParametersView(FuelConsumptionSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(pickFromDate.Value > pickToDate.Value)
            {
                _ = MessageBox.Show(this, $"{pickFromDate.Value} is greater than {pickToDate.Value} !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = _searchModel.GenerateFuelConsumptionReportData(
                new DateTime(pickFromDate.Value.Year, pickFromDate.Value.Month, pickFromDate.Value.Day, 0, 0, 0),
                new DateTime(pickToDate.Value.Year, pickToDate.Value.Month, pickToDate.Value.Day,23,59,59));
            ReportsViews.FuelConsumptionByFuelCardReportView fuelConsumptionByFuelCardReportView =
                new ReportsViews.FuelConsumptionByFuelCardReportView(
                    data,
                    new DateTime(pickFromDate.Value.Year, pickFromDate.Value.Month, pickFromDate.Value.Day, 0, 0, 0),
                    new DateTime(pickToDate.Value.Year, pickToDate.Value.Month, pickToDate.Value.Day, 23, 59, 59));
            fuelConsumptionByFuelCardReportView.MdiParent = this.MdiParent;
            fuelConsumptionByFuelCardReportView.Show();
            Close();
        }
    }
}
