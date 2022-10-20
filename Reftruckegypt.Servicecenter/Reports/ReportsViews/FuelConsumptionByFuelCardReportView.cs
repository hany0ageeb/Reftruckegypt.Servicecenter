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
    public partial class FuelConsumptionByFuelCardReportView : Form
    {
        private readonly DateTime _fromDate;
        private readonly DateTime _toDate;
        private readonly IList<ViewModels.FuelConsumptionViewModels.FuelConsumptionSummaryDTO> _data;
        public FuelConsumptionByFuelCardReportView(IList<ViewModels.FuelConsumptionViewModels.FuelConsumptionSummaryDTO> data, DateTime fromdate, DateTime todate)
        {
            _fromDate = fromdate;
            _toDate = todate;
            _data = data;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            //reportViewer1.LocalReport.ReportEmbeddedResource = "";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "FuelConsumptionSummaryDataSet",
                Value = _data
            });
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("FromDateParameter", _fromDate.ToString("yyyy/MM/dd HH:mm:ss")));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ToDateParameter", _toDate.ToString("yyyy/MM/dd HH:mm:ss")));
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = true,
                Margins = new System.Drawing.Printing.Margins()
                {
                    Left = 15,
                    Right = 15,
                    Top = 15,
                    Bottom = 15
                }
            });
        }
        private void FuelConsumptionByFuelCardReportView_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
