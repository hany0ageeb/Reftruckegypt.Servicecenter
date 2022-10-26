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
    public partial class PurchaseRequestsReportView : Form
    {
        private readonly DateTime? _fromDate;
        private readonly DateTime? _toDate;
        private readonly List<ViewModels.PurchaseRequestViewModels.PurchaseRequestLineDTO> _lines;
        public PurchaseRequestsReportView(IList<ViewModels.PurchaseRequestViewModels.PurchaseRequestLineDTO> lines, DateTime? fromDate = null, DateTime? toDate = null)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _lines = new List<ViewModels.PurchaseRequestViewModels.PurchaseRequestLineDTO>();
            _lines.AddRange(lines);
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "PurchaseRequestLineDTODataSet",
                Value = _lines
            });
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = true,
                Margins = new System.Drawing.Printing.Margins()
                {
                    Top = 10,
                    Left = 10,
                    Right = 10,
                    Bottom = 10
                }
            });
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("FromDateParameter", _fromDate?.ToString("yyyy/MM/dd HH:mm:ss") ?? ""));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ToDateParameter", _toDate?.ToString("yyyy/MM/dd HH:mm:ss") ?? ""));
        }
        private void PurchaseRequestsReportView_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
            reportViewer1.Refresh();
        }
    }
}
