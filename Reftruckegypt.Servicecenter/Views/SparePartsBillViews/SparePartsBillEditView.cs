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

namespace Reftruckegypt.Servicecenter.Views.SparePartsBillViews
{
    public partial class SparePartsBillEditView : Form
    {
        private SparePartsBillEditViewModel _editModel;
        private bool _hasChanged = true;
        public SparePartsBillEditView(SparePartsBillEditViewModel editViewModel)
        {
            _editModel = editViewModel;
            _hasChanged = editViewModel.HasChanged;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _editModel, nameof(_editModel.Number))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            txtRepairs.DataBindings.Clear();
            txtRepairs.DataBindings.Add(new Binding(nameof(txtRepairs.Text), _editModel, nameof(_editModel.Repairs))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            pickbillDate.DataBindings.Clear();
            pickbillDate.DataBindings.Add(new Binding(nameof(pickbillDate.Value), _editModel, nameof(_editModel.BillDate))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cbovehicles.DataBindings.Clear();
            cbovehicles.DataSource = _editModel.Vehicles;
            cbovehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cbovehicles.ValueMember = nameof(Models.Vehicle.Self);
            cbovehicles.DataBindings.Add(new Binding(nameof(cbovehicles.SelectedItem), _editModel, nameof(_editModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridLines.AllowUserToAddRows = true;
            gridLines.AllowUserToDeleteRows = true;
            gridLines.MultiSelect = false;
            gridLines.ReadOnly = false;
            gridLines.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridLines.AutoGenerateColumns = false;
            
            gridLines.Columns.Clear();
            gridLines.Columns.AddRange(new DataGridViewComboBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.SparePart),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.SparePart),
                HeaderText = "Spare Part",
                DataSource = _editModel.SpareParts,
                DisplayMember = nameof(Models.SparePart.Code),
                ValueMember = nameof(Models.SparePart.Self),
                ValueType = typeof(Models.SparePart),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewComboBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.Uom),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.Uom),
                HeaderText = "Unit Of Measure",
                DataSource = _editModel.Uoms,
                DisplayMember = nameof(Models.Uom.Code),
                ValueMember = nameof(Models.Uom.Self),
                ValueType = typeof(Models.Uom),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.Quantity),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.Quantity),
                HeaderText = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.UnitPrice),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.UnitPrice),
                HeaderText = "Unit Price",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.Notes),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.Notes),
                HeaderText = "Notes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            gridLines.EditingControlShowing += (o, e) =>
            {
                ComboBox comboBox = e.Control as ComboBox;
                if (comboBox != null)
                {
                    comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                    comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            };
            gridLines.CellValidating += (o, e) =>
            {
                if(e.ColumnIndex == gridLines.Columns[nameof(SparePartsBillLineEditViewModel.Quantity)].Index)
                {
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        if (decimal.TryParse(e.FormattedValue.ToString(),out decimal q))
                        {
                            if (q <= 0)
                            {
                                e.Cancel = true;
                                gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Quantity";
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Quantity";
                        }
                    }
                }
                else if (e.ColumnIndex == gridLines.Columns[nameof(SparePartsBillLineEditViewModel.UnitPrice)].Index)
                {
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        if (decimal.TryParse(e.FormattedValue.ToString(), out decimal u))
                        {
                            if(u < 0)
                            {
                                e.Cancel = true;
                                gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Unit Price";
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Unit Price";
                        }
                    }
                }
            };
            gridLines.CellValidated += (o, e) =>
            {
                if (e.ColumnIndex == gridLines.Columns[nameof(SparePartsBillLineEditViewModel.Quantity)].Index)
                {
                    gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                }
                else if (e.ColumnIndex == gridLines.Columns[nameof(SparePartsBillLineEditViewModel.UnitPrice)].Index)
                {
                    gridLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                }
            };
            gridLines.SelectionChanged += (o, e) =>
            {
                if(gridLines.SelectedCells.Count > 0)
                {
                    int rowIndex = gridLines.SelectedCells[0].RowIndex;
                    if (rowIndex >=0 && rowIndex < gridLines.Rows.Count)
                    {
                        var sparePart = gridLines.Rows[rowIndex].Cells[nameof(SparePartsBillLineEditViewModel.SparePart)].Value as Models.SparePart;
                        if (sparePart != null)
                        {
                            txtItemName.Text = sparePart.Name;
                        }
                        else
                        {
                            txtItemName.Text = "";
                        }
                    }
                }
                else
                {
                    txtItemName.Text = "";
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
                    if (_editModel.SaveOrUpdate())
                    {
                        txtRepairs.ReadOnly = true;
                        pickbillDate.Enabled = false;
                        cbovehicles.Enabled = false;
                        btnSave.Enabled = false;
                        gridLines.ReadOnly = true;
                        System.Media.SystemSounds.Beep.Play();
                        _hasChanged = false;
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
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                try
                {
                    if (_hasChanged && _editModel.Close())
                    {
                        _hasChanged = false;
                        Close();
                    }
                    else
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            FormClosing += (o, e) =>
            {
                try
                {
                    if ( _hasChanged && e.CloseReason == CloseReason.UserClosing)
                    {
                        e.Cancel = !_editModel.Close();
                        if (e.Cancel)
                            System.Media.SystemSounds.Hand.Play();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
