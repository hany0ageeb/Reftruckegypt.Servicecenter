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
    public partial class InternalMemoReportParametersView : Form
    {
        private readonly ViewModels.InternalMemoViewModels.InternalMemoSearchViewModel _searchModel;
        public InternalMemoReportParametersView(ViewModels.InternalMemoViewModels.InternalMemoSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemoNumber.Text))
            {
                MessageBox.Show(this, "Error", "Please Enter Internal Memo Number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IList<ViewModels.InternalMemoViewModels.InternalMemoDTO> memos = _searchModel.Find(txtMemoNumber.Text);
            if(memos.Count == 0)
            {
                MessageBox.Show(this, $"No Internal Memeo Found With Number {txtMemoNumber.Text}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReportsViews.InternalMemoReportView internalMemoReportView = new ReportsViews.InternalMemoReportView(memos);
            internalMemoReportView.MdiParent = this.MdiParent;
            internalMemoReportView.Show();
            Close();
        }
    }
}
