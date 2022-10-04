using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleModelViews
{
    public partial class VehicleModelsView : Form
    {
        private readonly VehicleModelSearchViewModel _searchModel;
        public VehicleModelsView(VehicleModelSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text),_searchModel,nameof(_searchModel.Name))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.CanDeleteVehicleModel))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.CanEditVehicleModel)) 
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            vehicleModelsGrid.AutoGenerateColumns = false;
            vehicleModelsGrid.AllowUserToAddRows = false;
            vehicleModelsGrid.AllowUserToDeleteRows = false;
            vehicleModelsGrid.MultiSelect = false;
            vehicleModelsGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            vehicleModelsGrid.ReadOnly = true;
            vehicleModelsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            vehicleModelsGrid.Columns.Clear();
            vehicleModelsGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleModelViewModel.Name),
                    DataPropertyName = nameof(VehicleModelViewModel.Name),
                    HeaderText = "Name",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleModelViewModel.Description),
                    DataPropertyName = nameof(VehicleModelViewModel.Description),
                    HeaderText = "Description",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleModelViewModel.DefaultFuelTypeName),
                    DataPropertyName = nameof(VehicleModelViewModel.DefaultFuelTypeName),
                    HeaderText = "Default Fuel Type"
                }
             );
            vehicleModelsGrid.DataSource = _searchModel.VehicleModelViewModels;
            vehicleModelsGrid.SelectionChanged += (o, e) =>
            {
                if (vehicleModelsGrid.SelectedCells.Count > 0)
                    _searchModel.SelectedIndex = vehicleModelsGrid.SelectedCells[0].RowIndex;
                else
                    _searchModel.SelectedIndex = -1;
            };
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchModel.Search();
            if(_searchModel.VehicleModelViewModels.Count > 0)
            {
                vehicleModelsGrid.Rows[0].Cells[0].Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (vehicleModelsGrid.SelectedCells.Count > 0)
                {
                    _searchModel.Delete(vehicleModelsGrid.SelectedCells[0].RowIndex);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try 
            {
                if(vehicleModelsGrid.SelectedCells.Count > 0)
                {
                    _searchModel.Edit(vehicleModelsGrid.SelectedCells[0].RowIndex);
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
