using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Reports.ReportsViews
{
    public partial class ReportView : Form
    {
        private string _title = "";
        private IList _data;
        private string _reportEmbeddedResource = "";
        private string _dataSourceName = "";
        public ReportView(string title, IList data, string embeddedResource, string dataSourceName)
        {
            _title = title;
            _data = data;
            _reportEmbeddedResource = embeddedResource;
            _dataSourceName = dataSourceName;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Text = _title;
            reportViewer1.LocalReport.ReportEmbeddedResource = _reportEmbeddedResource;
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = _dataSourceName,
                Value = _data
            });
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = true,
                Margins = new System.Drawing.Printing.Margins()
                {
                    Bottom = 10,
                    Top = 10,
                    Right = 10,
                    Left = 10
                }
            });
        }
        private void ReportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void ReportView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.P)
            {
                reportViewer1.PrintDialog();
            }
        }
    }
}
