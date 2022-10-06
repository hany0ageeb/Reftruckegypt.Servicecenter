using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels;

namespace Reftruckegypt.Servicecenter.Views.UomConversionViews
{
    public partial class UomConversionEditView : Form
    {
        private UomConversionEditViewModel _editModel;
        public UomConversionEditView(UomConversionEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            gridConversions.AllowUserToAddRows = true;
            gridConversions.AllowUserToDeleteRows = true;
            gridConversions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridConversions.AutoGenerateColumns = false;
            gridConversions.ReadOnly = false;
            gridConversions.MultiSelect = false;
            gridConversions.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridConversions.Columns.Clear();
            gridConversions.Columns.AddRange(new DataGridViewComboBoxColumn()
            {
                DataPropertyName = nameof(UomConversionLineEditViewModel.SparePart),
                Name = nameof(UomConversionLineEditViewModel.SparePart),
                DataSource = _editModel.SpareParts,
                DisplayMember = nameof(Models.SparePart.Code),
                ValueMember = nameof(Models.SparePart.Self),
                ValueType = typeof(Models.SparePart),
                HeaderText = "Spare Part"
            },
            new DataGridViewComboBoxColumn()
            {
                DataPropertyName = nameof(UomConversionLineEditViewModel.FromUom),
                Name = nameof(UomConversionLineEditViewModel.FromUom),
                DataSource = _editModel.Uoms,
                DisplayMember = nameof(Models.Uom.Code),
                ValueMember = nameof(Models.Uom.Self),
                ValueType = typeof(Models.Uom),
                HeaderText = "From Uom"
            },
            new DataGridViewComboBoxColumn()
            {
                DataPropertyName = nameof(UomConversionLineEditViewModel.ToUom),
                Name = nameof(UomConversionLineEditViewModel.ToUom),
                DataSource = _editModel.Uoms,
                DisplayMember = nameof(Models.Uom.Code),
                ValueMember = nameof(Models.Uom.Self),
                ValueType = typeof(Models.Uom),
                HeaderText = "To Uom"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionLineEditViewModel.Rate),
                DataPropertyName = nameof(UomConversionLineEditViewModel.Rate),
                HeaderText = "Conversion Rate"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionLineEditViewModel.Notes),
                DataPropertyName = nameof(UomConversionLineEditViewModel.Notes),
                HeaderText = "Notes"
            });
            gridConversions.DataSource = _editModel.Lines;
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
        }
    }
}
