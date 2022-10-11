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
    public partial class VehicleKilometerReadingsView : Form
    {
        private VehicleKilometerReadingSearchViewModel _searchModel;
        public VehicleKilometerReadingsView(VehicleKilometerReadingSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            cbovehicles.DataBindings.Clear();
            cbovehicles.DataSource = _searchModel.Vehicels;
            cbovehicles.DisplayMember = nameof(Vehicle.InternalCode);
            cbovehicles.ValueMember = nameof(Vehicle.Self);
            cbovehicles.DataBindings.Add(new Binding(nameof(cbovehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {

            });
            // ...
            pickfromDate.ValueChanged += (o, e) =>
            {
                if (pickfromDate.Checked)
                {
                    _searchModel.FromDate = pickfromDate.Value;
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
                    _searchModel.ToDate = picktoDate.Value;
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            gridReadings.AllowUserToAddRows = false;
            gridReadings.AllowUserToDeleteRows = false;
            gridReadings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridReadings.AutoGenerateColumns = false;
            gridReadings.MultiSelect = false;
            gridReadings.ReadOnly = true;
            gridReadings.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridReadings.Columns.Clear();
            gridReadings.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingViewModel.VehicleInternalCode),
                    DataPropertyName = nameof(VehicleKilometerReadingViewModel.VehicleInternalCode),
                    HeaderText = "Vehicle",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingViewModel.ReadingDate),
                    DataPropertyName = nameof(VehicleKilometerReadingViewModel.ReadingDate),
                    HeaderText = "Reading Date",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingViewModel.Reading),
                    DataPropertyName = nameof(VehicleKilometerReadingViewModel.Reading),
                    HeaderText = "Reading Date",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingViewModel.Notes),
                    DataPropertyName = nameof(VehicleKilometerReadingViewModel.Notes),
                    HeaderText = "Notes",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleKilometerReadingViewModel.State),
                    DataPropertyName = nameof(VehicleKilometerReadingViewModel.State),
                    HeaderText = "State",
                    ReadOnly = true
                }
            );
            gridReadings.DataSource = _searchModel.VehicleKilometerReadingViewModels;
            gridReadings.SelectionChanged += (o, e) =>
            {
                  if (gridReadings.SelectedCells.Count > 0)
                  {
                    _searchModel.SelectedIndex = gridReadings.SelectedCells[0].RowIndex;
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
            btnCreate.Click += (o, e) =>
            {
                _searchModel.Create();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
