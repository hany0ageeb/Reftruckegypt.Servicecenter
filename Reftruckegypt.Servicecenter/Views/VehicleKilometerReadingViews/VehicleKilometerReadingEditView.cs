using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.ViewModels.VehicleKilometerReadingViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleKilometerReadingViews
{
    public partial class VehicleKilometerReadingEditView : Form
    {
        private VehicleKilometerReadingEditViewModel _editModel;
        public VehicleKilometerReadingEditView(VehicleKilometerReadingEditViewModel editViewModel)
        {
            _editModel = editViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            pickReadingDate.DataBindings.Clear();
            pickReadingDate.DataBindings.Add(new Binding(nameof(pickReadingDate.Value), _editModel, nameof(_editModel.ReadingDate))
            {

            });
            // ...
            gridReadings.AllowUserToAddRows = true;
            gridReadings.AllowUserToDeleteRows = true;
            gridReadings.ReadOnly = false;
            gridReadings.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridReadings.MultiSelect = false;
            gridReadings.AutoGenerateColumns = false;
            gridReadings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridReadings.Columns.Clear();
            gridReadings.Columns.AddRange(
                new DataGridViewComboBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingLineEditViewModel.Vehicle),
                    DataPropertyName = nameof(VehicleKilometerReadingLineEditViewModel.Vehicle),
                    HeaderText = "Vehicle",
                    DataSource = _editModel.Vehicles,
                    DisplayMember = nameof(Vehicle.InternalCode),
                    ValueMember = nameof(Vehicle.Self),
                    ValueType = typeof(Vehicle),
                    ReadOnly = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingLineEditViewModel.Reading),
                    DataPropertyName = nameof(VehicleKilometerReadingLineEditViewModel.Reading),
                    HeaderText = "Reading",
                    ReadOnly = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingLineEditViewModel.Notes),
                    DataPropertyName = nameof(VehicleKilometerReadingLineEditViewModel.Notes),
                    HeaderText = "Notes",
                    ReadOnly = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                }
            );
            gridReadings.DataSource = _editModel.Lines;
            gridReadings.ShowCellErrors = true;
            gridReadings.ShowRowErrors = true;
            gridReadings.EditingControlShowing += (o, e) =>
            {
                ComboBox editControl = e.Control as ComboBox;
                if (editControl != null)
                {
                    editControl.DropDownStyle = ComboBoxStyle.DropDown;
                    editControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    editControl.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            };
            gridReadings.CellValidating += (o, e) =>
            {
                if(e.ColumnIndex == gridReadings.Columns[nameof(VehicleKilometerReadingLineEditViewModel.Reading)].Index)
                {
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        if(decimal.TryParse(e.FormattedValue.ToString(),out decimal reading))
                        {
                            if (reading < 0)
                            {
                                e.Cancel = true;
                                gridReadings.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Reading";
                            }
                        }
                        else
                        {
                            e.Cancel = true;
                            gridReadings.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid Reading";
                        }
                    }
                }
            };
            gridReadings.CellValidated += (o, e) =>
            {
                if (e.ColumnIndex == gridReadings.Columns[nameof(VehicleKilometerReadingLineEditViewModel.Reading)].Index)
                {
                    gridReadings.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                }
            };
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
                        Close();
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
                if (_editModel.Close())
                    Close();
            };
            // ...
            FormClosing += (o, e) =>
            {
                if(e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.MdiFormClosing)
                {
                    e.Cancel = !_editModel.Close();
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
