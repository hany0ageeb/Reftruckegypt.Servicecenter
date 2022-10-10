using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleStateChangeViews
{
    public partial class VehicleStateChangesView : Form
    {
        private VehicleStateChangeSearchViewModel _searchModel;
        public VehicleStateChangesView(VehicleStateChangeSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            pickfromDate.ValueChanged += (o, e) =>
            {
                if (pickfromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(
                        pickfromDate.Value.Year,
                        pickfromDate.Value.Month,
                        pickfromDate.Value.Day,
                        0,0,0);
                }
                else
                {
                    _searchModel.FromDate = null;
                }
            };
            // ...
            picktoDate.ValueChanged += (o, e) =>
            {
                if (picktoDate.Checked)
                {
                    _searchModel.ToDate = new DateTime(
                        picktoDate.Value.Year,
                        picktoDate.Value.Month,
                        picktoDate.Value.Day,
                        23, 59, 59);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            btnSearch.Click += (o, e) => _searchModel.Search();
            // ...
            btnCreate.Click += (o, e) => _searchModel.Create();
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) => _searchModel.Edit();
            // ...
            btnDelete.Click += (o, e) => _searchModel.Delete();
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.IsDeleteEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.MultiSelect = false;
            gridResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridResults.ReadOnly = true;
            gridResults.AutoGenerateColumns = false;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridResults.Columns.Clear();
            gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleStateChangeViewModel.VehicleInternalCode),
                DataPropertyName = nameof(VehicleStateChangeViewModel.VehicleInternalCode),
                HeaderText = "Vehicle"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleStateChangeViewModel.FromDate),
                DataPropertyName = nameof(VehicleStateChangeViewModel.FromDate),
                HeaderText = "From Date"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleStateChangeViewModel.ToDate),
                DataPropertyName = nameof(VehicleStateChangeViewModel.ToDate),
                HeaderText = "To Date"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(VehicleStateChangeViewModel.Notes),
                DataPropertyName = nameof(VehicleStateChangeViewModel.Notes),
                HeaderText = "Notes"
            });
            gridResults.DataSource = _searchModel.VehicleStateChanges;
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
