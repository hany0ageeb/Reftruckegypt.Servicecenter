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

namespace Reftruckegypt.Servicecenter.Views.ImportMappingViews
{
    public partial class SparePartMappingView : Form
    {
        private readonly string _fileName;
        private readonly List<string> _headers = new List<string>();
        public SparePartMappingView(List<string> headers, string fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            if (headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (headers.Count < 3)
                throw new ArgumentException("Invalid Columns Count.");
            _headers.AddRange(headers);
            InitializeComponent();
            Initialize();
        }
        public Mapper Mapper { get; private set; }
        private void Initialize()
        {
            cboCode.DataSource = new List<string>(_headers);
            cboCode.SelectedIndex = 0;
            cboName.DataSource = new List<string>(_headers);
            cboName.SelectedIndex = 1;
            cboUom.DataSource = new List<string>(_headers);
            cboUom.SelectedIndex = 2;
            Mapper = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Mapper = new Mapper(_fileName);
            Mapper.SkipBlankRows = true;
            Mapper.HasHeader = true;
            Mapper
                .Map<ViewModels.SparePartViewModels.SparePartViewModel>(cboCode.SelectedItem.ToString(), nameof(ViewModels.SparePartViewModels.SparePartViewModel.Code))
                .Map<ViewModels.SparePartViewModels.SparePartViewModel>(cboName.SelectedItem.ToString(), nameof(ViewModels.SparePartViewModels.SparePartViewModel.Name))
                .Map<ViewModels.SparePartViewModels.SparePartViewModel>(cboUom.SelectedItem.ToString(), nameof(ViewModels.SparePartViewModels.SparePartViewModel.UomCode));

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Mapper = null;
        }
    }
}
