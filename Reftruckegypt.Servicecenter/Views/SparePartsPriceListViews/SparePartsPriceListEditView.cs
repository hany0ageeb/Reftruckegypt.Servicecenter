using Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.SparePartsPriceListViews
{
    public partial class SparePartsPriceListEditView : Form
    {
        private SparePartPriceListEditViewModel _editModel;
        public SparePartsPriceListEditView(SparePartPriceListEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _editModel, nameof(_editModel.Number))
            { 
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged 
            });
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text),_editModel,nameof(_editModel.Name))
            {

            });
            // ...
            txtsparePartName.DataBindings.Clear();
            txtsparePartName.DataBindings.Add(new Binding(nameof(txtsparePartName.Text), _editModel, nameof(_editModel.SparePartName))
            { 
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboPeriods.DataBindings.Clear();
            cboPeriods.DataSource = _editModel.Periods;
            cboPeriods.DisplayMember = nameof(Models.Period.Name);
            cboPeriods.ValueMember = nameof(Models.Period.Self);
            cboPeriods.DataBindings.Add(new Binding(nameof(cboPeriods.SelectedItem), _editModel, nameof(_editModel.Period)));
            // ...
            gridLines.AllowUserToAddRows = true;
            gridLines.AllowUserToDeleteRows = true;
            gridLines.AutoGenerateColumns = false;
            gridLines.MultiSelect = false;
            gridLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridLines.ReadOnly = false;
            
            gridLines.Columns.Clear();
            gridLines.Columns.AddRange(new DataGridViewComboBoxColumn()
            {
                HeaderText = "Spare Part",
                DataPropertyName = nameof(SparePartPriceListLineEditViewModel.SparePart),
                Name = nameof(SparePartPriceListLineEditViewModel.SparePart),
                DataSource = _editModel.SpareParts,
                DisplayMember = nameof(Models.SparePart.Code),
                ValueMember = nameof(Models.SparePart.Self),
                ReadOnly = false
            },
            new DataGridViewComboBoxColumn()
            {
                HeaderText = "Uom",
                DataPropertyName = nameof(SparePartPriceListLineEditViewModel.Uom),
                Name = nameof(SparePartPriceListLineEditViewModel.Uom),
                DataSource = _editModel.Uoms,
                DisplayMember = nameof(Models.Uom.Code),
                ValueMember = nameof(Models.Uom.Self),
                ReadOnly = false
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Unit Price",
                DataPropertyName = nameof(SparePartPriceListLineEditViewModel.UnitPrice),
                Name = nameof(SparePartPriceListLineEditViewModel.UnitPrice),
                ReadOnly = false
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Uom Conversion Rate",
                DataPropertyName = nameof(SparePartPriceListLineEditViewModel.UomConversionRate),
                Name = nameof(SparePartPriceListLineEditViewModel.UomConversionRate),
                ReadOnly = false
            });
            gridLines.EditingControlShowing += (o, e) =>
            {
                ComboBox editControl = e.Control as ComboBox;
                if(editControl != null)
                {
                    editControl.DropDownStyle = ComboBoxStyle.DropDownList;
                    editControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    editControl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            };
            gridLines.SelectionChanged += (o, e) =>
            {
                if(gridLines.SelectedCells.Count > 0)
                {
                    _editModel.SelectedIndex = gridLines.SelectedCells[0].RowIndex;
                }
                else
                {
                    _editModel.SelectedIndex = -1;
                }
            };
            gridLines.DataSource = _editModel.Lines;
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnSave.Click += (o, e) =>
            {
                if (_editModel.SaveOrUpdate())
                {
                    txtName.ReadOnly = true;
                    gridLines.ReadOnly = true;
                    cboPeriods.Enabled = false;
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                if (_editModel.Close())
                    Close();
            };
            // ..
            FormClosing += (o, e) => e.Cancel = !_editModel.Close();
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
