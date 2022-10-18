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
    public partial class FuelConsumptionMappingView : Form
    {
        private List<string> _headers = new List<string>();
        private string _fileName;
        public FuelConsumptionMappingView(List<string> headers, string fileName)
        {
            if (headers == null)
                throw new ArgumentNullException(nameof(headers));
            if (headers.Count < 4)
                throw new ArgumentOutOfRangeException($"The Minimum Numer of Columns is 4 ...");
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException(nameof(fileName));
            _fileName = fileName;
            _headers.AddRange(headers);
            InitializeComponent();
            Initialize();
        }
        public Mapper Mapper { get; private set; }
        private void Initialize()
        {
            cboFuelCard.DataSource = new List<string>(_headers);
            if(_headers.Count > 0)
                cboFuelCard.SelectedIndex = 0;
            // ...
            cboAmount.DataSource = new List<string>(_headers);
            if(_headers.Count >= 5)
                cboAmount.SelectedIndex = 5;
            // ...
            cboConsumptionDate.DataSource = new List<string>(_headers);
            if(_headers.Count >= 8)
                cboConsumptionDate.SelectedIndex = 8;
            // ...
            cboQuantity.DataSource = new List<string>(_headers);
            if (_headers.Count >= 3)
                cboQuantity.SelectedIndex = 4;
            // ...
            DialogResult = DialogResult.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Mapper = null;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Mapper = new Mapper(_fileName);
            Mapper.HasHeader = true;
            Mapper.SkipBlankRows = true;
            Mapper
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO>(cboAmount.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO.AmountConsumed))
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO>(cboConsumptionDate.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO.FuelConsumptionDate))
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO>(cboQuantity.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO.QuantityConsumed))
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO>(cboFuelCard.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionDTO.FuelCardNumber));
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
