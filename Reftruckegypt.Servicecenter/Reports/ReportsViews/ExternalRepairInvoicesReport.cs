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
    public partial class ExternalRepairInvoicesReport : Form
    {
        IList<ViewModels.ExternalRepairBillViewModels.ExternalRepairBillViewModel> _data;
        public ExternalRepairInvoicesReport(IList<ViewModels.ExternalRepairBillViewModels.ExternalRepairBillViewModel> _invoices)
        {
            _data = _invoices;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Reftruckegypt.Servicecenter.Reports.ExternalRepairInvoicesReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "ExternalRepairBillsDataSet",
                Value = _data
            });
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = true
            });
        }
        private void ExternalRepairInvoicesReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
