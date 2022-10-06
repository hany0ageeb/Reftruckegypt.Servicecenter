using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleViolationViews
{
    public partial class VehicleViolationsView : Form
    {
        private VehicleViolationSearchViewModel _searchModel;
        public VehicleViolationsView(VehicleViolationSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent(); 
            Initialize();
        }
        private void Initialize()
        {
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboViolationTypes.DataBindings.Clear();
            cboViolationTypes.DataSource = _searchModel.ViolationTypes;
            cboViolationTypes.DisplayMember = nameof(Models.ViolationType.Name);
            cboViolationTypes.ValueMember = nameof(Models.ViolationType.Self);
            cboViolationTypes.DataBindings.Add(new Binding(nameof(cboViolationTypes.SelectedItem), _searchModel, nameof(_searchModel.ViolationType))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            pickFromDate.ValueChanged += (o, e) =>
            {
                if (pickFromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(pickFromDate.Value.Year, pickFromDate.Value.Month, pickFromDate.Value.Day, 0, 0, 0);
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
            gridViolations.ReadOnly = true;
            gridViolations.AllowUserToDeleteRows = false;
            gridViolations.AllowUserToAddRows = false;
            gridViolations.AutoGenerateColumns = false;
            gridViolations.MultiSelect = false;
            gridViolations.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridViolations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridViolations.Columns.Clear();
            gridViolations.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationViewModel.State),
                    DataPropertyName = nameof(VehicleViolationViewModel.State),
                    HeaderText = "State"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationViewModel.VehicleInternalCode),
                    DataPropertyName = nameof(VehicleViolationViewModel.VehicleInternalCode),
                    HeaderText = "Vehicle"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationViewModel.ViolationTypeName),
                    DataPropertyName = nameof(VehicleViolationViewModel.ViolationTypeName),
                    HeaderText = "Violation Type"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationViewModel.ViolationDate),
                    DataPropertyName = nameof(VehicleViolationViewModel.ViolationDate),
                    HeaderText = "Date"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationViewModel.Count),
                    DataPropertyName = nameof(VehicleViolationViewModel.Count),
                    HeaderText = "Count"
                }
            );
            gridViolations.DataSource = _searchModel.VehicleViolationViewModels;
            gridViolations.SelectionChanged += (o, e) =>
            {
                if (gridViolations.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridViolations.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            // ...
            btnSearch.Click += (o, e) =>
            {
                _searchModel.Search();
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
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled)) 
            { 
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged 
            });
            btnEdit.Click += (o, e) =>
            {
                _searchModel.Edit();
            };
            // ...
            btnCreate.Click += (o, e) =>
            {
                _searchModel.Create();
            };
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
