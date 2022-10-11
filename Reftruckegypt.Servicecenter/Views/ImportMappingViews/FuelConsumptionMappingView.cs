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
            cboAmount.DataSource = new List<string>(_headers);
            if(_headers.Count > 3)
                cboAmount.SelectedIndex = 3;
            // ...
            cboConsumptionDate.DataSource = new List<string>(_headers);
            if(_headers.Count >= 2)
                cboConsumptionDate.SelectedIndex = 1;
            // ...
            cboInternalCodes.DataSource = new List<string>(_headers);
            if (_headers.Count >= 1)
                cboInternalCodes.DataSource = new List<string>(_headers);
            // ...
            cboQuantity.DataSource = new List<string>(_headers);
            if (_headers.Count >= 3)
                cboQuantity.SelectedIndex = 2;
            // ...
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboFuelCard.DataSource = new List<string>(temp);
            cboFuelCard.SelectedIndex = 0;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboFuelType.DataSource = temp;
            cboFuelType.SelectedIndex = 0;
            // ...
            temp = new List<string>();
            temp.Insert(0, "");
            cboNotes.DataSource = temp;
            cboNotes.SelectedIndex = 0;
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
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboAmount.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.AmountInEGP))
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboConsumptionDate.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.ConsumptionDate))
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboInternalCodes.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.VehicleInternalCode))
                .Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboQuantity.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.QuantityInLiters));
            if(cboNotes.SelectedIndex > 0)
                Mapper.Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboNotes.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.Notes));
            if(cboFuelCard.SelectedIndex > 0)
                Mapper.Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboFuelCard.SelectedItem.ToString(), nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.FuelCardNumber));
            if (cboFuelType.SelectedIndex > 0)
                Mapper.Map<ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel>(cboFuelType.SelectedItem.ToString(),nameof(ViewModels.FuelConsumptionViewModels.FuelConsumptionViewModel.FuelTypeName));
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
