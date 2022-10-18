using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Reports.ReportsViews
{
    public partial class FuelConsumptionReportView : Form
    {
        private IList<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel> _data;
        public FuelConsumptionReportView(IList<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel> consumptions)
        {
            _data = consumptions;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Reftruckegypt.Servicecenter.Reports.FuelConsumptionReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "FuelConsumptionDataSet",
                Value = _data
            });
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = true
            });
        }
        private void FuelConsumptionReportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void FuelConsumptionReportView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.P)
            {
                reportViewer1.PrintDialog();
            }
        }
    }
}
