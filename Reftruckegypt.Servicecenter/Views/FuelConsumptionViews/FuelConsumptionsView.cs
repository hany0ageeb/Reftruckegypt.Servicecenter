using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;

namespace Reftruckegypt.Servicecenter.Views.FuelConsumptionViews
{
    public partial class FuelConsumptionsView : Form
    {
        private FuelConsumptionSearchViewModel _searchModel;
        public FuelConsumptionsView(FuelConsumptionSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initilaize();
        }
        private void Initilaize()
        {
            // ...
            cboCategories.DataBindings.Clear();
            cboCategories.DataSource = _searchModel.VehicleCategories;
            cboCategories.DisplayMember = nameof(Models.VehicleCategory.Name);
            cboCategories.ValueMember = nameof(Models.VehicleCategory.Self);
            cboCategories.DataBindings.Add(new Binding(nameof(cboCategories.SelectedItem), _searchModel, nameof(_searchModel.VehicleCategory))
            {

            });
            // ...
            cboFuelCards.DataBindings.Clear();
            cboFuelCards.DataSource = _searchModel.FuelCards;
            cboFuelCards.DisplayMember = nameof(Models.FuelCard.Number);
            cboFuelCards.ValueMember = nameof(Models.FuelCard.Self);
            cboFuelCards.DataBindings.Add(new Binding(nameof(cboFuelCards.SelectedItem), _searchModel, nameof(_searchModel.FuelCard))
            {

            });
            // ...
            cboFuelTypes.DataBindings.Clear();
            cboFuelTypes.DataSource = _searchModel.FuelTypes;
            cboFuelTypes.DisplayMember = nameof(Models.FuelType.Name);
            cboFuelTypes.ValueMember = nameof(Models.FuelType.Self);
            cboFuelTypes.DataBindings.Add(new Binding(nameof(cboFuelTypes.SelectedItem), _searchModel, nameof(_searchModel.FuelType))
            {

            });
            // ...
            cboModels.DataBindings.Clear();
            cboModels.DataSource = _searchModel.VehicleModels;
            cboModels.DisplayMember = nameof(Models.VehicleModel.Name);
            cboModels.ValueMember = nameof(Models.VehicleModel.Self);
            cboModels.DataBindings.Add(new Binding(nameof(cboModels.SelectedItem), _searchModel, nameof(_searchModel.VehicleModel))
            {

            });
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {

            });
            // ...
            pickFromDate.ValueChanged += (o, e) =>
            {
                if (pickFromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(pickFromDate.Value.Year, pickFromDate.Value.Month, pickFromDate.Value.Day,0,0,0);
                }
                else
                {
                    _searchModel.FromDate = null;
                }
            };
            // ...
            pickToDate.ValueChanged += (o, e) =>
            {
                 if (pickToDate.Checked)
                 {
                    _searchModel.ToDate = new DateTime(pickToDate.Value.Year, pickToDate.Value.Month, pickToDate.Value.Day, 23, 59, 59);
                }
                 else
                 {
                    _searchModel.ToDate = null;
                 }
            };
            // ...
            btnSearch.Click += (o, e) =>
            {
                _searchModel.Search();
            };
            // ...
            gridConsumptions.AllowUserToAddRows = false;
            gridConsumptions.AllowUserToDeleteRows = false;
            gridConsumptions.AutoGenerateColumns = false;
            gridConsumptions.MultiSelect = false;
            gridConsumptions.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridConsumptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridConsumptions.ReadOnly = true;
            gridConsumptions.Columns.Clear();
            gridConsumptions.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.State),
                    DataPropertyName = nameof(FuelConsumptionViewModel.State),
                    HeaderText = "State",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.VehicleInternalCode),
                    DataPropertyName = nameof(FuelConsumptionViewModel.VehicleInternalCode),
                    HeaderText = "Vehicle",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.FuelCardNumber),
                    DataPropertyName = nameof(FuelConsumptionViewModel.FuelCardNumber),
                    HeaderText = "Fuel Card Number",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.FuelCardName),
                    DataPropertyName = nameof(FuelConsumptionViewModel.FuelCardName),
                    HeaderText = "Fuel Card Name",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.ConsumptionDate),
                    DataPropertyName = nameof(FuelConsumptionViewModel.ConsumptionDate),
                    HeaderText = "Date",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.QuantityInLiters),
                    DataPropertyName = nameof(FuelConsumptionViewModel.QuantityInLiters),
                    HeaderText = "Quantity (LT)",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.FuelTypeName),
                    DataPropertyName = nameof(FuelConsumptionViewModel.FuelTypeName),
                    HeaderText = "Fuel",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.AmountInEGP),
                    DataPropertyName = nameof(FuelConsumptionViewModel.AmountInEGP),
                    HeaderText = "Amount(EGP)",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionViewModel.Notes),
                    DataPropertyName = nameof(FuelConsumptionViewModel.Notes),
                    HeaderText = "Notes",
                    ReadOnly = true
                }
            );
            gridConsumptions.DataSource = _searchModel.FuelConsumptions;
            gridConsumptions.SelectionChanged += (o, e) =>
            {
                if(gridConsumptions.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridConsumptions.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.IsDeleteEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnDelete.Click += (o, e) =>
            {
                 _searchModel.Delete();
            };
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled),_searchModel, nameof(_searchModel.IsEditEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) =>
            {
                _searchModel.Edit();
            };
            // ....
            btnCreate.Click += (o, e) =>
            {
                _searchModel.Create();
            };
            // ....
            // ...
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }
        public void ExportToFile()
        {
            try
            {
                if (_searchModel.FuelConsumptions.Count > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        _searchModel.ExportToFile(saveFileDialog1.FileName);
                    }

                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
