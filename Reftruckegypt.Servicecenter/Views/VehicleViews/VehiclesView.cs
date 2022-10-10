using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleViews
{
    public partial class VehiclesView : Form
    {
        private VehicleSearchViewModel _searchModel;
        public VehiclesView(VehicleSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtChassis.DataBindings.Clear();
            txtChassis.DataBindings.Add(new Binding(nameof(txtChassis.Text), _searchModel, nameof(_searchModel.ChassisNumber))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtInternalCode.DataBindings.Clear();
            txtInternalCode.DataBindings.Add(new Binding(nameof(txtInternalCode.Text), _searchModel, nameof(_searchModel.InternalCode))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtMotorNumber.DataBindings.Clear();
            txtMotorNumber.DataBindings.Add(new Binding(nameof(txtMotorNumber.Text), _searchModel, nameof(_searchModel.MotorNumber))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtPlateNumber.DataBindings.Clear();
            txtPlateNumber.DataBindings.Add(new Binding(nameof(txtPlateNumber.Text), _searchModel, nameof(_searchModel.PlateNumber))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboCategories.DataBindings.Clear();
            cboCategories.DataSource = _searchModel.VehicleCategories;
            cboCategories.DisplayMember = nameof(Models.VehicleCategory.Name);
            cboCategories.ValueMember = nameof(Models.VehicleCategory.Self);
            cboCategories.DataBindings.Add(new Binding(nameof(cboCategories.SelectedItem),_searchModel,nameof(_searchModel.VehicleCategory))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboFuelCards.DataBindings.Clear();
            cboFuelCards.DataSource = _searchModel.FuelCards;
            cboFuelCards.DisplayMember = nameof(Models.FuelCard.Number);
            cboFuelCards.ValueMember = nameof(Models.FuelCard.Self);
            cboFuelCards.DataBindings.Add(new Binding(nameof(cboFuelCards.SelectedItem), _searchModel, nameof(_searchModel.FuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboFuelTypes.DataBindings.Clear();
            cboFuelTypes.DataSource = _searchModel.FuelTypes;
            cboFuelTypes.DisplayMember = nameof(Models.FuelType.Name);
            cboFuelTypes.ValueMember = nameof(Models.FuelType.Self);
            cboFuelTypes.DataBindings.Add(new Binding(nameof(cboFuelTypes.SelectedItem), _searchModel, nameof(_searchModel.FuelType))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboModels.DataBindings.Clear();
            cboModels.DataSource = _searchModel.VehicleModels;
            cboModels.DisplayMember = nameof(Models.VehicleModel.Name);
            cboModels.ValueMember = nameof(Models.VehicleModel.Self);
            cboModels.DataBindings.Add(new Binding(nameof(cboModels.SelectedItem), _searchModel, nameof(_searchModel.VehicleModel))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboWorkingState.DataBindings.Clear();
            cboWorkingState.DataSource = _searchModel.WorkingStates;
            cboWorkingState.DataBindings.Add(new Binding(nameof(cboWorkingState.SelectedItem), _searchModel, nameof(_searchModel.WorkingState))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboMaintenanceLocation.DataBindings.Clear();
            cboMaintenanceLocation.DataSource = _searchModel.Locations;
            cboMaintenanceLocation.DisplayMember = nameof(Models.Location.Name);
            cboMaintenanceLocation.ValueMember = nameof(Models.Location.Self);
            cboMaintenanceLocation.DataBindings.Add(new Binding(nameof(cboMaintenanceLocation.SelectedItem), _searchModel, nameof(_searchModel.MaintenanceLocation))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboWorkingLocation.DataBindings.Clear();
            cboWorkingLocation.DataSource = new List<Models.Location>(_searchModel.Locations);
            cboWorkingLocation.DisplayMember = nameof(Models.Location.Name);
            cboWorkingLocation.ValueMember = nameof(Models.Location.Self);
            cboWorkingLocation.DataBindings.Add(new Binding(nameof(cboWorkingLocation.SelectedItem), _searchModel, nameof(_searchModel.WorkingLocation))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridResults.AutoGenerateColumns = false;
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridResults.MultiSelect = false;
            gridResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridResults.ReadOnly = true;
            gridResults.Columns.Clear();
            gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.InternalCode),
                DataPropertyName = nameof(VehicleViewModel.InternalCode),
                HeaderText = "Internal Code"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.PlateNumber),
                DataPropertyName = nameof(VehicleViewModel.PlateNumber),
                HeaderText = "Plate Number"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.ChassisNumber),
                DataPropertyName = nameof(VehicleViewModel.ChassisNumber),
                HeaderText = "Chassis"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.ModelName),
                DataPropertyName = nameof(VehicleViewModel.ModelName),
                HeaderText = "Model"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.ModelYear),
                DataPropertyName = nameof(VehicleViewModel.ModelYear),
                HeaderText = "Model Year"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.OvallStateName),
                DataPropertyName = nameof(VehicleViewModel.OvallStateName),
                HeaderText = "Over All State"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.WorkingLocationName),
                DataPropertyName = nameof(VehicleViewModel.WorkingLocationName),
                HeaderText = "Working Location"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.WorkingState),
                DataPropertyName = nameof(VehicleViewModel.WorkingState),
                HeaderText = "State"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.FuelCardNumber),
                DataPropertyName = nameof(VehicleViewModel.FuelCardNumber),
                HeaderText = "Fuel Card"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleViewModel.FuelTypeName),
                DataPropertyName = nameof(VehicleViewModel.FuelTypeName),
                HeaderText = "Fuel Type"
            });
            gridResults.SelectionChanged += (o, e) =>
            {
                if(gridResults.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridResults.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            gridResults.DataSource = _searchModel.SearchResult;
            // ...
            btnSearch.Click += (o, e) => _searchModel.Search();
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.IsDeleteEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnDelete.Click += (o, e) => _searchModel.Delete();
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) => _searchModel.Edit();
            // ...
            btnCreate.Click += (o, e) => _searchModel.Create();
            // ....
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ExportToFile()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    _searchModel.ExportToFile(saveFileDialog1.FileName);
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
    }
}
