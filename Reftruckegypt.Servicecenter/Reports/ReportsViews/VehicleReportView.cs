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
    public partial class VehicleReportView : Form
    {
        private readonly List<ViewModels.VehicleViewModels.VehicleViewModel> _data = new List<ViewModels.VehicleViewModels.VehicleViewModel>();
        private readonly DateTime? _fromDate = null;
        private readonly DateTime? _toDate = null;
        public VehicleReportView(IList<ViewModels.VehicleViewModels.VehicleViewModel> data,
            DateTime? fromDate = null, DateTime? toDate = null)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _data.AddRange(data);
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "VehicleViewModelDataSet",
                Value = _data
            });
            if (_data.Count > 0)
            {
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "FuelConsumptionViewModelDataSet",
                    Value = _data[0].FuelConsumptions
                });
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "ExternalRepairInvoiceDataSet",
                    Value = _data[0].ExternalRepairBills
                });
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "SparePartInvoiceLineViewModelDataSet",
                    Value = _data[0].SparePartsBills
                });
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "KilometerReadingViewModelDataSet",
                    Value = _data[0].KilometerReadings
                });
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "VehicleViolationViewModelDataSet",
                    Value = _data[0].VehicleViolations
                });
            }
            else
            {
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "FuelConsumptionViewModelDataSet",
                    Value = new List<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>()
                });
                // ...
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "ExternalRepairInvoiceDataSet",
                    Value = new List<ViewModels.ExternalRepairBillViewModels.ExternalRepairBillViewModel>()
                });
                // ...
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "SparePartInvoiceLineViewModelDataSet",
                    Value = new List<ViewModels.SparePartsBillViewModels.SparePartsBillLineViewModel>()
                });
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "KilometerReadingViewModelDataSet",
                    Value = new List<ViewModels.VehicleKilometerReadingViewModels.VehicleKilometerReadingViewModel>()
                });
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
                {
                    Name = "VehicleViolationViewModelDataSet",
                    Value = new List<ViewModels.VehicleKilometerReadingViewModels.VehicleKilometerReadingViewModel>()
                });
            }
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("FromDateParameter", _fromDate?.ToString("yyyy/MM/dd HH:mm:ss")??""));
            reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ToDateParameter", _toDate?.ToString("yyyy/MM/dd HH:mm:ss") ?? ""));
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings()
            {
                Landscape = false,
                Margins = new System.Drawing.Printing.Margins()
                {
                    Top = 10,
                    Left = 10,
                    Bottom = 10,
                    Right = 10
                }
            });
        }
        private void VehicleReportView_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
