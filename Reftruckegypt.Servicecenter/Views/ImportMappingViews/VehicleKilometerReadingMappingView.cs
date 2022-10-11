using Npoi.Mapper;
using Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels;
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
    public partial class VehicleKilometerReadingMappingView : Form
    {
        private List<string> _headers = new List<string>();
        private string _fileName;
        public VehicleKilometerReadingMappingView(IEnumerable<string> headers, string fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(fileName);
            if (headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (headers.Count() < 3)
                throw new ArgumentException($"Invalid Columns Header Count: {headers.Count()}");
            _headers.AddRange(headers);
            InitializeComponent();
            Initialize();
        }
        public Mapper Mapper { get; private set; }
        private void Initialize()
        {
            cboInternalCodes.DataSource = new List<string>(_headers);
            cboInternalCodes.SelectedIndex = 0;
            cboKilometerReading.DataSource = new List<string>(_headers);
            cboKilometerReading.SelectedIndex = 1;
            cboReadingDate.DataSource = new List<string>(_headers);
            cboReadingDate.SelectedIndex = 2;
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboNotes.DataSource = temp;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Mapper = new Mapper(_fileName);
            Mapper
                .Map<VehicleKilometerReadingViewModel>(cboInternalCodes.SelectedItem.ToString(), nameof(VehicleKilometerReadingViewModel.VehicleInternalCode))
                .Map<VehicleKilometerReadingViewModel>(cboKilometerReading.SelectedItem.ToString(), nameof(VehicleKilometerReadingViewModel.Reading))
                .Map<VehicleKilometerReadingViewModel>(cboReadingDate.SelectedItem.ToString(), nameof(VehicleKilometerReadingViewModel.ReadingDate));
            if (cboNotes.SelectedIndex >= 0)
                Mapper.Map<VehicleKilometerReadingViewModel>(cboNotes.SelectedItem.ToString(), nameof(VehicleKilometerReadingViewModel.Notes));
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Mapper = null;
            DialogResult = DialogResult.Cancel;
        }
    }
}
