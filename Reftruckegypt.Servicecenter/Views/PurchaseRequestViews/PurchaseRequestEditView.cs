using Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.PurchaseRequestViews
{
    public partial class PurchaseRequestEditView : Form
    {
        private PurchaseRequestEditViewModel _editModel;
        public PurchaseRequestEditView(PurchaseRequestEditViewModel editModel)
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
            txtDescription.DataBindings.Clear();
            txtDescription.DataBindings.Add(new Binding(nameof(txtDescription.Text), _editModel, nameof(_editModel.Description))
            {

            });
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _editModel, nameof(_editModel.Vehicle)));
            cboVehicles.DataSource = _editModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            // ...
            pickrequestDate.DataBindings.Clear();
            pickrequestDate.DataBindings.Add(new Binding(nameof(pickrequestDate.Value), _editModel, nameof(_editModel.RequestDate)));
            // ....
            txtpartName.DataBindings.Clear();
            txtpartName.DataBindings.Add(new Binding(nameof(txtpartName.Text), _editModel, nameof(_editModel.CurrentLineSparePartName)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            // ...
            gridLines.AllowUserToAddRows = true;
            gridLines.AllowUserToDeleteRows = true;
            gridLines.AutoGenerateColumns = false;
            gridLines.MultiSelect = false;
            gridLines.ReadOnly = false;
            gridLines.Columns.Clear();
            gridLines.Columns.AddRange(new DataGridViewComboBoxColumn()
            {
                Name = nameof(PurchaseRequestLineEditViewModel.SparePart),
                DataPropertyName = nameof(PurchaseRequestLineEditViewModel.SparePart),
                HeaderText = "Spare Part",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataSource = _editModel.SpareParts,
                DisplayMember = nameof(Models.SparePart.Code),
                ValueMember = nameof(Models.SparePart.Self),
                ValueType = typeof(Models.SparePart)
            },
            new DataGridViewComboBoxColumn()
            {
                Name = nameof(PurchaseRequestLineEditViewModel.Uom),
                DataPropertyName = nameof(PurchaseRequestLineEditViewModel.Uom),
                HeaderText = "Uom",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataSource = _editModel.Uoms,
                DisplayMember = nameof(Models.Uom.Code),
                ValueMember = nameof(Models.Uom.Self),
                ValueType = typeof(Models.Uom),
                ReadOnly = true
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(PurchaseRequestLineEditViewModel.RequestedQuantity),
                DataPropertyName = nameof(PurchaseRequestLineEditViewModel.RequestedQuantity),
                HeaderText = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(PurchaseRequestLineEditViewModel.Notes),
                DataPropertyName = nameof(PurchaseRequestLineEditViewModel.Notes),
                HeaderText = "Notes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
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
            gridLines.EditingControlShowing += (o, e) =>
            {
                ComboBox editControl = e.Control as ComboBox;
                if (editControl != null)
                {
                    editControl.DropDownStyle = ComboBoxStyle.DropDown;
                    editControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    editControl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            };
            gridLines.CellValidating += (o, e) =>
            {
                if(e.ColumnIndex == gridLines.Columns[nameof(PurchaseRequestLineEditViewModel.RequestedQuantity)].Index)
                {
                    if(!decimal.TryParse(e.FormattedValue.ToString(), out decimal qty))
                    {
                        e.Cancel = true;
                        gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Quantity.";
                    }
                    else
                    {
                        if(qty <= 0)
                        {
                            e.Cancel = true;
                            gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Quantity.";
                        }
                    }
                }
            };
            gridLines.CellValidated += (o, e) =>
            {
                if (e.ColumnIndex == gridLines.Columns[nameof(PurchaseRequestLineEditViewModel.RequestedQuantity)].Index)
                {
                    gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
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
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (_editModel.SaveOrUpdate())
                    {
                        txtDescription.ReadOnly = true;
                        txtpartName.ReadOnly = true;
                        gridLines.ReadOnly = true;
                        cboVehicles.Enabled = false;
                        pickrequestDate.Enabled = false;
                    }
                    else
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (_editModel.Close())
                        Close();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };
            // ...
            FormClosing += (o, e) =>
            {
                if (_editModel.HasChanged && e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = !_editModel.Close();
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
