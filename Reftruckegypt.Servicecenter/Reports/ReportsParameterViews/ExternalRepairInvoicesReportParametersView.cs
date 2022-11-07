using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
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
    public partial class ExternalRepairInvoicesReportParametersView : Form
    {
        private ExternalRepairBillSearchViewModel _searchModel;
        public ExternalRepairInvoicesReportParametersView(ExternalRepairBillSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtbillNumberFrom.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberFrom.Text))
                    return;
                if (!long.TryParse(txtbillNumberFrom.Text, out long valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillNumberFrom, "Invalid Bill Number!");
                }
            };
            txtbillNumberFrom.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberFrom.Text))
                    _searchModel.NumberFrom = null;
                else
                    _searchModel.NumberFrom = long.Parse(txtbillNumberFrom.Text);
                errorProvider1.SetError(txtbillNumberFrom, "");
            };
            // ...
            txtbillNumberTo.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberTo.Text))
                    return;
                if (!long.TryParse(txtbillNumberTo.Text, out long valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillNumberTo, "Invalid Bill Number!");
                }
            };
            txtbillNumberTo.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberTo.Text))
                    _searchModel.NumberTo = null;
                else
                    _searchModel.NumberTo = long.Parse(txtbillNumberTo.Text);
                errorProvider1.SetError(txtbillNumberTo, "");
            };
            // ...
            txtbillAmountFrom.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountFrom.Text))
                    return;
                if (!decimal.TryParse(txtbillAmountFrom.Text, out decimal valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillAmountFrom, "Invalid Amount!");
                }
            };
            txtbillAmountFrom.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountFrom.Text))
                    _searchModel.FromAmount = null;
                else
                    _searchModel.FromAmount = decimal.Parse(txtbillAmountFrom.Text);
                errorProvider1.SetError(txtbillAmountFrom, "");
            };
            // ...
            txtbillAmountTo.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountTo.Text))
                    return;
                if (!decimal.TryParse(txtbillAmountTo.Text, out decimal valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillAmountTo, "Invalid Amount!");
                }
            };
            txtbillAmountTo.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountTo.Text))
                    _searchModel.ToAmount = null;
                else
                    _searchModel.ToAmount = decimal.Parse(txtbillAmountTo.Text);
                errorProvider1.SetError(txtbillAmountTo, "");
            };
            // ...
            pickbillDateFrom.ValueChanged += (o, e) =>
            {
                if (pickbillDateFrom.Checked)
                {
                    _searchModel.FromDate = new DateTime(pickbillDateFrom.Value.Year, pickbillDateFrom.Value.Month, pickbillDateFrom.Value.Day, 0, 0, 0);
                }
                else
                {
                    _searchModel.FromDate = null;
                }
            };
            // ...
            pickbillDateTo.ValueChanged += (o, e) =>
            {
                if (pickbillDateTo.Checked)
                {
                    _searchModel.ToDate = new DateTime(pickbillDateTo.Value.Year, pickbillDateTo.Value.Month, pickbillDateTo.Value.Day, 23, 59, 59);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            cboshops.DataBindings.Clear();
            cboshops.DataSource = _searchModel.ExternalAutoRepairShops;
            cboshops.DisplayMember = nameof(Models.ExternalAutoRepairShop.Name);
            cboshops.ValueMember = nameof(Models.ExternalAutoRepairShop.Self);
            cboshops.DataBindings.Add(new Binding(nameof(cboshops.SelectedItem), _searchModel, nameof(_searchModel.ExternalAutoRepairShop))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboCategories.DataBindings.Clear();
            cboCategories.DataSource = _searchModel.VehicleCategories;
            cboCategories.DisplayMember = nameof(Models.VehicleCategory.Name);
            cboCategories.ValueMember = nameof(Models.VehicleCategory.Self);
            cboCategories.DataBindings.Add(new Binding(nameof(cboCategories.SelectedItem), _searchModel, nameof(_searchModel.VehicleCategory))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cbovehicles.DataBindings.Clear();
            cbovehicles.DataSource = _searchModel.Vehicles;
            cbovehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cbovehicles.ValueMember = nameof(Models.Vehicle.Self);
            cbovehicles.DataBindings.Add(new Binding(nameof(cbovehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            _searchModel.Search();
            ReportsViews.ExternalRepairInvoicesReport reportView = new ReportsViews.ExternalRepairInvoicesReport(_searchModel.ExternalRepairBillVieModels.ToList());
            reportView.MdiParent = this.MdiParent;
            reportView.Show();
            Close();
        }
    }
}
