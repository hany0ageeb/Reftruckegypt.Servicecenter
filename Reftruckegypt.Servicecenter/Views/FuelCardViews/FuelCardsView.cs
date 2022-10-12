using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels;

namespace Reftruckegypt.Servicecenter.Views.FuelCardViews
{
    public partial class FuelCardsView : Form
    {
        private FuelCardSearchViewModel _searchModel;
        public FuelCardsView(FuelCardSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        public void ExportToFile()
        {
            try
            {
                if (_searchModel.SearchResult.Count > 0)
                {
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
        }
        private void Initialize()
        {
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _searchModel, nameof(_searchModel.Name))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _searchModel, nameof(_searchModel.Number))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtRegistration.DataBindings.Clear();
            txtRegistration.DataBindings.Add(new Binding(nameof(txtRegistration.Text), _searchModel, nameof(_searchModel.Registration))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.ReadOnly = true;
            gridResults.MultiSelect = false;
            gridResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridResults.AutoGenerateColumns = false;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResults.Columns.Clear();
            gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
            {
                Name= nameof(FuelCardViewModel.Number),
                DataPropertyName = nameof(FuelCardViewModel.Number),
                HeaderText = "Number"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(FuelCardViewModel.Name),
                DataPropertyName = nameof(FuelCardViewModel.Name),
                HeaderText = "Name"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(FuelCardViewModel.Registration),
                DataPropertyName = nameof(FuelCardViewModel.Registration),
                HeaderText = "Registration"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(FuelCardViewModel.VehicleInternalCode),
                DataPropertyName = nameof(FuelCardViewModel.VehicleInternalCode),
                HeaderText = "Vehicle Internal Code"
            });
            gridResults.DataSource = _searchModel.SearchResult;
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
            // ...
            btnSearch.Click += (o, e) => _searchModel.Search();
            // ...
            btnCreate.Click += (o, e) => _searchModel.Create();
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
    }
}
