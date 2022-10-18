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

namespace Reftruckegypt.Servicecenter.Reports.ReportsViews
{
    public partial class VehicleViolationsReportView : Form
    {
        private IList<VehicleViolationViewModel> _data;
        private string _fromDateParameter;
        private string _toDateParameter;
        public VehicleViolationsReportView(
            IList<VehicleViolationViewModel> data, 
            string fromDate = "", 
            string toDate = "")
        {
            _data = data;
            _fromDateParameter = fromDate;
            _toDateParameter = toDate;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Reftruckegypt.Servicecenter.Reports.SpeedViolationReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "VehicleViolationsDataSet",
                Value = _data
            });
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("FromDateParameter", _fromDateParameter));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ToDateParameter", _toDateParameter));
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = true,
                Margins = new System.Drawing.Printing.Margins()
                {
                    Bottom = 10,
                    Left = 10,
                    Right = 10,
                    Top = 10
                }
            });
        }
        private void VehicleViolationsReportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
