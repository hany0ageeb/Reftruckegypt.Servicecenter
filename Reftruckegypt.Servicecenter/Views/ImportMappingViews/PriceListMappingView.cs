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
    public partial class PriceListMappingView : Form
    {
        private List<string> _headers = new List<string>();
        private string _fileName;
        public PriceListMappingView(
            IList<string> headers, 
            string fileName)
        {
            if (headers.Count < 4)
                throw new ArgumentException("Invalid File Headers Count.");
            _headers.AddRange(headers);
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException($"Invalid File Name: {fileName}");
            InitializeComponent();
            Initialize();
        }
        public Mapper Mapper { get; private set; } = null;
        private void Initialize()
        {
            cboPriceListName.DataSource = new List<string>(_headers);
            if (_headers.Count > 0)
                cboPriceListName.SelectedIndex = 0;
            cboPeriodName.DataSource = new List<string>(_headers);
            if (_headers.Count > 1)
                cboPriceListName.SelectedIndex = 1;
            cboUnitPrice.DataSource = new List<string>(_headers);
            if (_headers.Count > 2)
                cboPriceListName.SelectedIndex = 2;
            cboPartCode.DataSource = new List<string>(_headers);
            if (_headers.Count > 3)
                cboPriceListName.SelectedIndex = 3;
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboUomCode.DataSource = temp;
            cboUomCode.SelectedIndex = 0;
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboConversionRate.DataSource = temp;
            cboConversionRate.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Mapper = new Mapper(_fileName) 
            { 
                HasHeader = true,
                FirstRowIndex = 0,
                SkipBlankRows = true
            };
            Mapper
                .Map<ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel>(cboPriceListName.SelectedItem.ToString(), nameof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel.Name))
                .Map<ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel>(cboPeriodName.SelectedItem.ToString(), nameof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel.PeriodName))
                .Map<ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel>(cboPartCode.SelectedItem.ToString(), nameof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel.SparePartCode))
                .Map<ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel>(cboUnitPrice.SelectedItem.ToString(), nameof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel.UnitPrice));
            if(cboUomCode.SelectedIndex >= 1 && cboUomCode.SelectedIndex <= _headers.Count )
                Mapper.Map<ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel>(cboUomCode.SelectedItem.ToString(), nameof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel.UomCode));
            if(cboConversionRate.SelectedIndex >= 1 && cboConversionRate.SelectedIndex <= _headers.Count)
                Mapper.Map<ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel>(cboConversionRate.SelectedItem.ToString(), nameof(ViewModels.SparePartsPriceListViewModels.SparePartsPriceListLineViewModel.ConversionRate));
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Mapper = null;
        }
    }
}
