using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;
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
    public partial class InternalRepairInvoicesParametersView : Form
    {
        private SparePartsBillSearchViewModel _searchModel;
        public InternalRepairInvoicesParametersView(SparePartsBillSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            rdbheaders.DataBindings.Clear();
            rdbheaders.DataBindings.Add(new Binding(nameof(rdbheaders.Checked), _searchModel, nameof(_searchModel.DisplayResultByHeader))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            rdblines.DataBindings.Clear();
            rdblines.DataBindings.Add(new Binding(nameof(rdblines.Checked), _searchModel, nameof(_searchModel.DisplayResultByLine))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboParts.DataBindings.Clear();
            cboParts.DataSource = _searchModel.SpareParts;
            cboParts.DisplayMember = nameof(Models.SparePart.Code);
            cboParts.ValueMember = nameof(Models.SparePart.Self);
            cboParts.DataBindings.Add(new Binding(nameof(cboParts.SelectedItem), _searchModel, nameof(_searchModel.SparePart))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
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
            pickfromDate.ValueChanged += (o, e) =>
            {
                if (pickfromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(pickfromDate.Value.Year, pickfromDate.Value.Month, pickfromDate.Value.Day, 0, 0, 0);
                }
                else
                {
                    _searchModel.FromDate = null;
                }
            };
            // ...
            picktoDate.ValueChanged += (o, e) =>
            {
                if (picktoDate.Checked)
                {
                    _searchModel.ToDate = new DateTime(picktoDate.Value.Year, picktoDate.Value.Month, picktoDate.Value.Day, 0, 0, 0);
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
            if (_searchModel.DisplayResultByHeader)
            {
                ReportsViews.ReportView reportView = new ReportsViews.ReportView("Internal Repiar Invoices Summary", _searchModel.Headers.ToList(), "Reftruckegypt.Servicecenter.Reports.InternalRepairInvoicesSummaryReport.rdlc", "InternalInvoiceHeaderDataSet");
                reportView.MdiParent = this.MdiParent;
                reportView.Show();
                Close();
            }
            else
            {
                ReportsViews.ReportView reportView = new ReportsViews.ReportView("Internal Repiar Invoices Details", _searchModel.Lines.ToList(), "Reftruckegypt.Servicecenter.Reports.InternalRepairInvoiceLinesReport.rdlc", "InternalInvoicesLinesDataSet");
                reportView.MdiParent = this.MdiParent;
                reportView.Show();
                Close();
            }
        }
    }
}
