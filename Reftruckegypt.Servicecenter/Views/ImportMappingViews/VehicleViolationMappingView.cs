using Npoi.Mapper;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
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
    public partial class VehicleViolationMappingView : Form
    {
        private List<string> _headers = new List<string>();
        private string _fileName;
        public VehicleViolationMappingView(IEnumerable<string> headers, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            if(headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (headers.Count() < 3)
                throw new ArgumentException($"Minimum Columns Header is 3 not {headers.Count()}");
            _headers.AddRange(headers);
            _fileName = fileName;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            cboCount.DataSource = new List<string>(_headers);
            cboCount.SelectedIndex = 2;
            cboInternalCodes.DataSource = new List<string>(_headers);
            cboInternalCodes.SelectedIndex = 0;
            cboViolationDate.DataSource = new List<string>(_headers);
            cboViolationDate.SelectedIndex = 1;
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboNotes.DataSource = temp;
            cboNotes.SelectedIndex = 0;
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboViolationTypes.DataSource = temp;
            cboViolationTypes.SelectedIndex = 0;

        }
        public Mapper Mapper { get; private set; } = null;
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Mapper = new Mapper(_fileName);
            Mapper
                .Map<VehicleViolationViewModel>(cboInternalCodes.SelectedItem.ToString(), nameof(VehicleViolationViewModel.VehicleInternalCode))
                .Map<VehicleViolationViewModel>(cboCount.SelectedItem.ToString(), nameof(VehicleViolationViewModel.Count))
                .Map<VehicleViolationViewModel>(cboViolationDate.SelectedItem.ToString(), nameof(VehicleViolationViewModel.ViolationDate));
            if(cboNotes.SelectedIndex >= 0)
            {
                Mapper.Map<VehicleViolationViewModel>(cboNotes.SelectedItem.ToString(), nameof(VehicleViolationViewModel.Notes));
            }
            if(cboViolationTypes.SelectedIndex >= 0)
            {
                Mapper.Map<VehicleViolationViewModel>(cboNotes.SelectedItem.ToString(), nameof(VehicleViolationViewModel.ViolationTypeName));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Mapper = null;
        }
    }
}
