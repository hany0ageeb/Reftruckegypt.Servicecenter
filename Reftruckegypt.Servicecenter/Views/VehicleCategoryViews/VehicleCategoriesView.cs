using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleCategoryViews
{
    public partial class VehicleCategoriesView : Form
    {
        private VehicleCategorySearchViewModel _searchModel;
        public VehicleCategoriesView(VehicleCategorySearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _searchModel, nameof(_searchModel.Name)));
            // ....
            btnSearch.Click += (o, e) =>
            {
                _searchModel.Search();
            };
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.CanDelete)));
            btnDelete.Click += (o, e) =>
            {
                try
                {
                    _searchModel.Delete();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.CanEdit)));
            btnEdit.Click += (o, e) =>
            {
                try
                {
                    _searchModel.Edit();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            vehicleCategoriesGrid.ReadOnly = true;
            vehicleCategoriesGrid.AllowUserToAddRows = false;
            vehicleCategoriesGrid.AllowUserToDeleteRows = false;
            vehicleCategoriesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            vehicleCategoriesGrid.AutoGenerateColumns = false;
            vehicleCategoriesGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            vehicleCategoriesGrid.MultiSelect = false;
            vehicleCategoriesGrid.Columns.Clear();
            vehicleCategoriesGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleCategoryViewModel.Name),
                    DataPropertyName = nameof(VehicleCategoryViewModel.Name),
                    ReadOnly = true,
                    HeaderText = "Name"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleCategoryViewModel.Description),
                    DataPropertyName = nameof(VehicleCategoryViewModel.Description),
                    ReadOnly = true,
                    HeaderText = "Description"
                },
                new DataGridViewCheckBoxColumn()
                {
                    Name = nameof(VehicleCategoryViewModel.IsChassisNumberRequired),
                    DataPropertyName = nameof(VehicleCategoryViewModel.IsChassisNumberRequired),
                    ReadOnly = true,
                    HeaderText = "Chassis Number Required"
                },
                new DataGridViewCheckBoxColumn()
                {
                    Name = nameof(VehicleCategoryViewModel.IsFuelCardRequired),
                    DataPropertyName = nameof(VehicleCategoryViewModel.IsFuelCardRequired),
                    ReadOnly = true,
                    HeaderText = "Fuel Card Required"
                }
             );
            vehicleCategoriesGrid.DataBindings.Clear();
            vehicleCategoriesGrid.DataSource = _searchModel.VehicleCategoryViews;
            vehicleCategoriesGrid.SelectionChanged += (o, e) =>
            {
                if (vehicleCategoriesGrid.SelectedCells.Count > 0)
                    _searchModel.SelectedVehicelCategoryChanged(vehicleCategoriesGrid.SelectedCells[0].RowIndex);
                else
                    _searchModel.SelectedVehicelCategoryChanged(-1);
            };
            _searchModel.SelectedVehicleCategoryChanged += (o, e) =>
             {
                 vehicleCategoriesGrid.ClearSelection();
                 if (e.Index >= 0 && e.Index < vehicleCategoriesGrid.Rows.Count)
                 {
                     vehicleCategoriesGrid.Rows[e.Index].Selected = true;
                 }
             };
            // ....
            // ....
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _searchModel.Create();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void ExportToFile()
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
