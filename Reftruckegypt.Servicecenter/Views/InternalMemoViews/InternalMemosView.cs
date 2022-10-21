using Reftruckegypt.Servicecenter.ViewModels.InternalMemoViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.InternalMemoViews
{
    public partial class InternalMemosView : Form
    {
        private readonly InternalMemoSearchViewModel _searchModel;
        public InternalMemosView(InternalMemoSearchViewModel searchModel)
        {
            _searchModel = searchModel;
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
            txtSubject.DataBindings.Clear();
            txtSubject.DataBindings.Add(new Binding(nameof(txtSubject.Text), _searchModel, nameof(_searchModel.Subject))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtContent.DataBindings.Clear();
            txtContent.DataBindings.Add(new Binding(nameof(txtContent.Text), _searchModel, nameof(_searchModel.CurrentMemoContents))
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
            gridMemos.AllowUserToAddRows = false;
            gridMemos.AllowUserToDeleteRows = false;
            gridMemos.MultiSelect = false;
            gridMemos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridMemos.AutoGenerateColumns = false;
            gridMemos.Columns.Clear();
            gridMemos.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(InternalMemoDTO.Number),
                    DataPropertyName = nameof(InternalMemoDTO.Number),
                    HeaderText = "Number"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(InternalMemoDTO.MemoDate),
                    DataPropertyName = nameof(InternalMemoDTO.MemoDate),
                    HeaderText = "Date"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(InternalMemoDTO.VehicleInternalCode),
                    DataPropertyName = nameof(InternalMemoDTO.VehicleInternalCode),
                    HeaderText = "Vehicle"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(InternalMemoDTO.Header),
                    DataPropertyName = nameof(InternalMemoDTO.Header),
                    HeaderText = "Header"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(InternalMemoDTO.State),
                    DataPropertyName = nameof(InternalMemoDTO.State),
                    HeaderText = "State"
                });
            gridMemos.SelectionChanged += (o, e) =>
            {
                if(gridMemos.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridMemos.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            gridMemos.DataSource = _searchModel.InternalMemos;
            // ...
            btnSearch.Click += (o, e) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _searchModel.Search();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };
            // ...
            btnCreate.Click += (o, e) =>
            {
                try
                {
                    _searchModel.Create();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            };
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) =>
            {
                try
                {
                    _searchModel.Edit();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    _searchModel.Delete();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }

        public async Task ExportToFileAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    await _searchModel.ExportToExcelFileAsync(fileName: saveFileDialog1.FileName);
                }
            }
            catch(Exception ex)
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
