using Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels;
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
    public partial class PurchaseRequestsReportParametersView : Form
    {
        private readonly PurchaseRequestSearchViewModel _searchModel;
        public PurchaseRequestsReportParametersView(PurchaseRequestSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            _searchModel.DisplayResultByLine = true;
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
                    _searchModel.FromDate =
                        new DateTime(pickfromDate.Value.Year, pickfromDate.Value.Month, pickfromDate.Value.Day, 0, 0, 0);
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
                    _searchModel.ToDate =
                        new DateTime(picktoDate.Value.Year, picktoDate.Value.Month, picktoDate.Value.Day, 23, 59, 59);
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
            try
            {
                Cursor = Cursors.WaitCursor;
                _searchModel.Search();
                ReportsViews.PurchaseRequestsReportView purchaseRequestsReportView = new ReportsViews.PurchaseRequestsReportView(_searchModel.PurchaseRequestLines.ToList(), _searchModel.FromDate, _searchModel.ToDate);
                purchaseRequestsReportView.MdiParent = this.MdiParent;
                purchaseRequestsReportView.Show();
                Close();
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
