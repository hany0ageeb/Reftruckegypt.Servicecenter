using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;

namespace Reftruckegypt.Servicecenter.Views.DriverViews
{
    public partial class DriversView : Form
    {
        private DriverSearchViewModel _searchModel;
        public DriversView(DriverSearchViewModel driverSearchViewModel)
        {
            _searchModel = driverSearchViewModel;
            InitializeComponent();
            Initialize();
        }
        public void ExportToFile()
        {
            try
            {
                if (_searchModel.Drivers.Count > 0)
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
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _searchModel, nameof(_searchModel.Name))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtLicenseNumber.DataBindings.Clear();
            txtLicenseNumber.DataBindings.Add(new Binding(nameof(txtLicenseNumber.Text), _searchModel, nameof(_searchModel.LicenseNumber))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            pickfromdate.ValueChanged += (o, e) =>
            {
                if (pickfromdate.Checked)
                {
                    _searchModel.EndDateFrom = new DateTime(pickfromdate.Value.Year, pickfromdate.Value.Month, pickfromdate.Value.Day,0,0,0);
                }
                else
                {
                    _searchModel.EndDateFrom = null;
                }
            };
            // ...
            picktodate.ValueChanged += (o, e) =>
            {
                if (picktodate.Checked)
                {
                    _searchModel.EndDateTo = new DateTime(picktodate.Value.Year, picktodate.Value.Month, picktodate.Value.Day, 23, 59, 59);
                }
                else
                {
                    _searchModel.EndDateTo = null;
                }
            };
            // ...
            gridDrivers.AllowUserToDeleteRows = false;
            gridDrivers.AllowUserToAddRows = false;
            gridDrivers.AutoGenerateColumns = false;
            gridDrivers.ReadOnly = true;
            gridDrivers.MultiSelect = false;
            gridDrivers.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridDrivers.Columns.Clear();
            gridDrivers.Columns.AddRange(
                new DataGridViewCheckBoxColumn(){
                    Name = nameof(Models.Driver.IsEnabled),
                    DataPropertyName = nameof(Models.Driver.IsEnabled),
                    HeaderText = "Enabled"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(Models.Driver.Name),
                    DataPropertyName = nameof(Models.Driver.Name),
                    HeaderText = "Enabled"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(Models.Driver.LicenseNumber),
                    DataPropertyName = nameof(Models.Driver.LicenseNumber),
                    HeaderText = "License Number"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(Models.Driver.TrafficDepartmentName),
                    DataPropertyName = nameof(Models.Driver.TrafficDepartmentName),
                    HeaderText = "Traffic Department"
                });
            gridDrivers.DataSource = _searchModel.Drivers;
            gridDrivers.SelectionChanged += (o, e) =>
            {
                if(gridDrivers.SelectedCells.Count > 0)
                {
                    _searchModel.Selectedindex = gridDrivers.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.Selectedindex = 1;
                }
                
            };
            // ...
            btnSearch.Click += (o, e) =>
            {
                _searchModel.Search();
            };
            // ...
            btnCreate.Click += (o, e) =>
            {
                _searchModel.Create();
            };
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.IsDeleteEnabled)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            btnDelete.Click += (o, e) =>
            {
                 _searchModel.Delete();
            };
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            btnEdit.Click += (o, e) =>
            {
                _searchModel.Edit();
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                Close();
            };
            // ...
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }
    }
}
