using Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.VehicleViews
{
    public partial class VehicleEditView : Form
    {
        private VehicleEditViewModel _editModel;
        private bool _hasChanged = true;
        public VehicleEditView(VehicleEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            chkHasFuelCard.DataBindings.Clear();
            chkHasFuelCard.DataBindings.Add(new Binding(nameof(chkHasFuelCard.Checked), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            /*
            chkHasFuelCard.CheckedChanged += (o, e) =>
            {
                if (chkHasFuelCard.Checked)
                {
                    txtNumber.Enabled = true;
                    txtName.Enabled = true;
                    txtRegistration.Enabled = true;
                }
                else
                {
                    txtNumber.Enabled = false;
                    txtName.Enabled = false;
                    txtRegistration.Enabled = false;
                }
            };
            */
            txtNumber.Enabled = _editModel.HasFuelCard;
            txtName.Enabled = _editModel.HasFuelCard;
            txtRegistration.Enabled = _editModel.HasFuelCard;
            // ...
            /*
            lblnumber.DataBindings.Add(new Binding(nameof(lblnumber.Visible), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            lblname.DataBindings.Add(new Binding(nameof(lblname.Visible), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            lblregistration.DataBindings.Add(new Binding(nameof(lblregistration.Visible), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            */
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _editModel, nameof(_editModel.FuelCardNumber))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Enabled), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _editModel, nameof(_editModel.FuelCardName))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            
            txtName.DataBindings.Add(new Binding(nameof(txtName.Enabled), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            
            // ...
            txtRegistration.DataBindings.Clear();
            txtRegistration.DataBindings.Add(new Binding(nameof(txtRegistration.Text), _editModel, nameof(_editModel.Registration))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            
            txtRegistration.DataBindings.Add(new Binding(nameof(txtRegistration.Enabled), _editModel, nameof(_editModel.HasFuelCard))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            
            // ...
            txtInternalCode.DataBindings.Clear();
            txtInternalCode.DataBindings.Add(new Binding(nameof(txtInternalCode.Text), _editModel, nameof(_editModel.InternalCode))
            {

            });
            // ...
            txtVehicleCode.DataBindings.Clear();
            txtVehicleCode.DataBindings.Add(new Binding(nameof(txtVehicleCode.Text), _editModel, nameof(_editModel.VehicleCode))
            {

            });
            // ...
            txtChassis.DataBindings.Clear();
            txtChassis.DataBindings.Add(new Binding(nameof(txtChassis.Text), _editModel, nameof(_editModel.ChassisNumber))
            {

            });
            // ...
            txtmodelYear.DataBindings.Clear();
            txtmodelYear.DataBindings.Add(new Binding(nameof(txtmodelYear.Text), _editModel, nameof(_editModel.ModelYear))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
            });
            txtmodelYear.Validating += (o, e) =>
            {
                if (!string.IsNullOrEmpty(txtmodelYear.Text))
                {
                    if(!int.TryParse(txtmodelYear.Text, out int year))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtmodelYear, "Invalid Model Year.");
                    }
                    else
                    {
                        if(year <= 0)
                        {
                            e.Cancel = true;
                            errorProvider1.SetError(txtmodelYear, "Invalid Model Year.");
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtmodelYear, "Invalid Model Year.");
                }
            };
            txtmodelYear.Validated += (o, e) =>
            {
                errorProvider1.SetError(txtmodelYear, "");
            };
            // ...
            cboCategories.DataBindings.Clear();
            cboCategories.DataSource = _editModel.VehicleCategorys;
            cboCategories.DisplayMember = nameof(Models.VehicleCategory.Name);
            cboCategories.ValueMember = nameof(Models.VehicleCategory.Self);
            cboCategories.DataBindings.Add(new Binding(nameof(cboCategories.SelectedItem), _editModel, nameof(_editModel.VehicleCategory))
            {

            });
            // ...
            cboModels.DataBindings.Clear();
            cboModels.DataSource = _editModel.VehicleModels;
            cboModels.DisplayMember = nameof(Models.VehicleModel.Name);
            cboModels.ValueMember = nameof(Models.VehicleModel.Self);
            cboModels.DataBindings.Add(new Binding(nameof(cboModels.SelectedItem), _editModel, nameof(_editModel.VehicleModel))
            {

            });
            // ...
            cboDrivers.DataBindings.Clear();
            cboDrivers.DataSource = _editModel.Drivers;
            cboDrivers.DisplayMember = nameof(Models.Driver.Name);
            cboDrivers.ValueMember = nameof(Models.Driver.Self);
            cboDrivers.DataBindings.Add(new Binding(nameof(cboDrivers.SelectedItem), _editModel, nameof(_editModel.Driver))
            {

            });
            // ...
            //cboFuelCards.DataBindings.Clear();
            //cboFuelCards.DataSource = _editModel.FuelCards;
            //cboFuelCards.DisplayMember = nameof(Models.FuelCard.Number);
            //cboFuelCards.ValueMember = nameof(Models.FuelCard.Self);
            //cboFuelCards.DataBindings.Add(new Binding(nameof(cboFuelCards.SelectedItem), _editModel, nameof(_editModel.FuelCard))
            //{

            //});
            // ...
            cboFuelTypes.DataBindings.Clear();
            cboFuelTypes.DataSource = _editModel.FuelTypes;
            cboFuelTypes.DisplayMember = nameof(Models.FuelType.Name);
            cboFuelTypes.ValueMember = nameof(Models.FuelType.Self);
            cboFuelTypes.DataBindings.Add(new Binding(nameof(cboFuelTypes.SelectedItem), _editModel, nameof(_editModel.FuelType))
            {

            });
            // ...
            cboWorkingStates.DataBindings.Clear();
            cboWorkingStates.DataSource = _editModel.WorkingStates;
            cboWorkingStates.DataBindings.Add(new Binding(nameof(cboWorkingStates.SelectedItem), _editModel, nameof(_editModel.WorkingState))
            {

            });
            // ...
            cboMaintenanceLocations.DataBindings.Clear();
            cboMaintenanceLocations.DataSource = _editModel.Locations;
            cboMaintenanceLocations.DisplayMember = nameof(Models.Location.Name);
            cboMaintenanceLocations.ValueMember = nameof(Models.Location.Self);
            cboMaintenanceLocations.DataBindings.Add(new Binding(nameof(cboMaintenanceLocations.SelectedItem), _editModel, nameof(_editModel.MaintenanceLocation))
            {

            });
            // ...
            cboWorkingLocations.DataSource = new List<Models.Location>(_editModel.Locations);
            cboWorkingLocations.DisplayMember = nameof(Models.Location.Name);
            cboWorkingLocations.ValueMember = nameof(Models.Location.Self);
            cboWorkingLocations.DataBindings.Add(new Binding(nameof(cboWorkingLocations.SelectedItem), _editModel, nameof(_editModel.WorkLocation))
            {

            });
            //....
            cboOverAllStates.DataSource = _editModel.OverAllStates;
            cboOverAllStates.DisplayMember = nameof(Models.VehicleOverAllState.Name);
            cboOverAllStates.ValueMember = nameof(Models.VehicleOverAllState.Self);
            cboOverAllStates.DataBindings.Clear();
            cboOverAllStates.DataBindings.Add(new Binding(nameof(cboOverAllStates.SelectedItem), _editModel, nameof(_editModel.OverAllState))
            {

            });
            // ...
            gridLicenses.AllowUserToAddRows = true;
            gridLicenses.AllowUserToDeleteRows = true;
            gridLicenses.AutoGenerateColumns = false;
            gridLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridLicenses.ReadOnly = false;
            gridLicenses.MultiSelect = true;
            gridLicenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLicenses.Columns.Clear();
            gridLicenses.Columns.AddRange(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Plate Number",
                DataPropertyName = nameof(VehicleLicenseEditViewmodel.PlateNumber),
                Name = nameof(VehicleLicenseEditViewmodel.PlateNumber)
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Motor Number",
                DataPropertyName = nameof(VehicleLicenseEditViewmodel.MotorNumber),
                Name = nameof(VehicleLicenseEditViewmodel.MotorNumber)
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Start Date(dd/mm/yyyy)",
                DataPropertyName = nameof(VehicleLicenseEditViewmodel.StartDate),
                Name = nameof(VehicleLicenseEditViewmodel.StartDate)
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "End Date(dd/mm/yyyy)",
                DataPropertyName = nameof(VehicleLicenseEditViewmodel.EndDate),
                Name = nameof(VehicleLicenseEditViewmodel.EndDate)
            },
            new DataGridViewTextBoxColumn()
            {
                HeaderText = "Traffic Dept",
                DataPropertyName = nameof(VehicleLicenseEditViewmodel.TrafficDeparmentName),
                Name = nameof(VehicleLicenseEditViewmodel.TrafficDeparmentName)
            });
            gridLicenses.DataSource = _editModel.Licenses;
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
                        _hasChanged = false;
                        Close();

                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ....
            btnClose.Click += (o, e) =>
            {
                try
                {
                    if (_editModel.Close())
                    {
                        _hasChanged = false;
                        Close();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ....
            FormClosing += (o, e) =>
            {
                try
                {
                    if (_hasChanged && _editModel.HasChanged && e.CloseReason == CloseReason.UserClosing)
                        e.Cancel = !_editModel.Close();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            //....
            errorProvider1.DataSource = _editModel;
        }
    }
}
