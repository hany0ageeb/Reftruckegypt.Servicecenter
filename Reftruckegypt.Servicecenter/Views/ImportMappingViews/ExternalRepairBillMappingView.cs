using Npoi.Mapper;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.ImportMappingViews
{
    public partial class ExternalRepairBillMappingView : Form
    {
        private readonly string _fileName;
        private readonly List<string> _headers = new List<string>();
        public ExternalRepairBillMappingView(List<string> headers, string fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            if(headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (headers.Count < 4)
                throw new ArgumentException("Invalid Columns Count.");
            _headers.AddRange(headers);
            InitializeComponent();
            Initialize();
        }
        public Mapper Mapper { get; private set; }
        private void Initialize()
        {
            cboAmount.DataSource = new List<string>(_headers);
            cboAmount.SelectedIndex = 3;
            cboExternalRepaiShops.DataSource = new List<string>(_headers);
            cboExternalRepaiShops.SelectedIndex = 2;
            cboInternalCodes.DataSource = new List<string>(_headers);
            cboInternalCodes.SelectedIndex = 0;
            cboReadingDate.DataSource = new List<string>(_headers);
            cboReadingDate.SelectedIndex = 1;
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboRepairs.DataSource = temp;
            cboRepairs.SelectedIndex = -1;
            cboRepairs.DataSource = temp;
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboSupplierInvoiceNum.DataSource = temp;
            cboSupplierInvoiceNum.SelectedIndex = -1;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Mapper = new Mapper(_fileName);
            Mapper.HasHeader = true;
            Mapper.SkipBlankRows = true;
            Mapper
                .Map<ExternalRepairBillViewModel>(cboInternalCodes.SelectedItem.ToString(), nameof(ExternalRepairBillViewModel.VehicleInternalCode))
                .Map<ExternalRepairBillViewModel>(cboReadingDate.SelectedItem.ToString(), nameof(ExternalRepairBillViewModel.BillDate))
                .Map<ExternalRepairBillViewModel>(cboAmount.SelectedItem.ToString(), nameof(ExternalRepairBillViewModel.TotalAmount))
                .Map<ExternalRepairBillViewModel>(cboExternalRepaiShops.SelectedItem.ToString(), nameof(ExternalRepairBillViewModel.ExternalAutoRepairShopName));
            if (cboRepairs.SelectedIndex >= 0 && !string.IsNullOrEmpty(cboRepairs.SelectedItem.ToString()))
                Mapper.Map<ExternalRepairBillViewModel>(cboRepairs.SelectedItem.ToString(), nameof(ExternalRepairBillViewModel.Repairs));
            if (cboSupplierInvoiceNum.SelectedIndex >= 0 && !string.IsNullOrEmpty(cboSupplierInvoiceNum.SelectedItem.ToString()))
                Mapper.Map<ExternalRepairBillViewModel>(cboSupplierInvoiceNum.SelectedItem.ToString(), nameof(ExternalRepairBillViewModel.SupplierBillNumber));
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Mapper = null;
            DialogResult = DialogResult.Cancel;
        }
    }
}
