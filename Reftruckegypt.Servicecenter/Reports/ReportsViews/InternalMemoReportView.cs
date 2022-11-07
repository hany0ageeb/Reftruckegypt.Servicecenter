using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Reports.ReportsViews
{
    public partial class InternalMemoReportView : Form
    {
        private List<ViewModels.InternalMemoViewModels.InternalMemoDTO> _memos = new List<ViewModels.InternalMemoViewModels.InternalMemoDTO>();
        public InternalMemoReportView(IList<ViewModels.InternalMemoViewModels.InternalMemoDTO> memos)
        {
            _memos.AddRange(memos);
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "InternalMemoDTODataSet",
                Value = _memos
            });
            reportViewer1.SetPageSettings(new PageSettings()
            {
                Landscape = false,
                Margins = new Margins()
                {
                    Top = 10,
                    Left = 10,
                    Bottom = 10,
                    Right = 10
                }
            });
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        private void InternalMemoReportView_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
