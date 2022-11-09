using Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;

namespace Reftruckegypt.Servicecenter.Views.ImportMappingViews
{
    public partial class InternalRepairInvoiceMappingView : Form
    {
        private readonly string _fileName;
        private readonly List<string> _headers = new List<string>();
        public InternalRepairInvoiceMappingView(List<string> headers, string fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            if (headers == null)
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
            cboInternalCodes.DataSource = new List<string>(_headers);
            cboInternalCodes.SelectedIndex = 0;
            // ...
            cboInvoiceDate.DataSource = new List<string>(_headers);
            cboInvoiceDate.SelectedIndex = 1;
            // ...
            cboQuantity.DataSource = new List<string>(_headers);
            cboQuantity.SelectedIndex = 2;
            // ...
            cboSpareParts.DataSource = new List<string>(_headers);
            cboSpareParts.SelectedIndex = 3;
            // ...
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboUnitPrice.DataSource = temp;
            cboUnitPrice.SelectedIndex = 0;
            // ....
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboRepairs.DataSource = temp;
            cboRepairs.SelectedIndex = 0;
            // ......
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Mapper = new Mapper(_fileName);
            Mapper.HasHeader = true;
            Mapper.SkipBlankRows = true;
            Mapper
                .Map<SparePartsBillLineViewModel>(cboInternalCodes.SelectedItem.ToString(), nameof(SparePartsBillLineViewModel.VehicleInternalCode))
                .Map<SparePartsBillLineViewModel>(cboInvoiceDate.SelectedItem.ToString(), nameof(SparePartsBillLineViewModel.BillDate))
                .Map<SparePartsBillLineViewModel>(cboQuantity.SelectedItem.ToString(), nameof(SparePartsBillLineViewModel.Quantity))
                .Map<SparePartsBillLineViewModel>(cboSpareParts.SelectedItem.ToString(), nameof(SparePartsBillLineViewModel.SparePartCode));
            if (cboRepairs.SelectedIndex > 0)
                Mapper.Map<SparePartsBillLineViewModel>(cboRepairs.SelectedItem.ToString(), nameof(SparePartsBillLineViewModel.Repairs));
            if (cboUnitPrice.SelectedIndex > 0)
                Mapper.Map<SparePartsBillLineViewModel>(cboUnitPrice.SelectedItem.ToString(), nameof(SparePartsBillLineViewModel.UnitPrice));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Mapper = null;
            DialogResult = DialogResult.Cancel;
        }
    }
}
