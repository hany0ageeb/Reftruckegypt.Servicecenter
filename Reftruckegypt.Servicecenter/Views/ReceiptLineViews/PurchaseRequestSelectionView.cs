using Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.ReceiptLineViews
{
    public partial class PurchaseRequestSelectionView : Form
    {
        private readonly BindingList<PurchaseRequestSelectorViewModel> _requests = new BindingList<PurchaseRequestSelectorViewModel>();
        public PurchaseRequestSelectionView(IEnumerable<PurchaseRequestSelectorViewModel> requests)
        {
            InitializeComponent();
            Initialize(requests);
        }
        public IList<Guid> SelectedRequests => _requests.Where(x => x.IsSelected).Select(x => x.RequestId).ToList();
        private void Initialize(IEnumerable<PurchaseRequestSelectorViewModel> requests)
        {
            _requests.Clear();
            foreach(var request in requests)
            {
                _requests.Add(request);
            }
            _requests.ListChanged += (o, e) =>
            {
                if(SelectedRequests.Count > 0)
                {
                    btnOk.Enabled = true;
                }
                else
                {
                    btnOk.Enabled = false;
                }
            };
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.AddRange(
                new DataGridViewCheckBoxColumn()
                {
                    ReadOnly = false,
                    DataPropertyName = nameof(PurchaseRequestSelectorViewModel.IsSelected),
                    Name = nameof(PurchaseRequestSelectorViewModel.IsSelected),
                    HeaderText = "|"
                },
                new DataGridViewTextBoxColumn()
                {
                    ReadOnly = true,
                    DataPropertyName = nameof(PurchaseRequestSelectorViewModel.Number),
                    Name = nameof(PurchaseRequestSelectorViewModel.Number),
                    HeaderText = "Number"
                },
                new DataGridViewTextBoxColumn()
                {
                    ReadOnly = true,
                    DataPropertyName = nameof(PurchaseRequestSelectorViewModel.RequestDate),
                    Name = nameof(PurchaseRequestSelectorViewModel.RequestDate),
                    HeaderText = "Date"
                },
                new DataGridViewTextBoxColumn()
                {
                    ReadOnly = true,
                    DataPropertyName = nameof(PurchaseRequestSelectorViewModel.VehicleInternalCode),
                    Name = nameof(PurchaseRequestSelectorViewModel.VehicleInternalCode),
                    HeaderText = "Vehicle"
                });
            dataGridView1.DataSource = _requests;
            btnOk.Enabled = false;
            btnOk.Click += BtnOk_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            foreach (var request in _requests)
            {
                request.IsSelected = false;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
