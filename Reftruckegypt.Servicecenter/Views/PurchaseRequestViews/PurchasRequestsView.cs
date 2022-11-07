using Reftruckegypt.Servicecenter.ViewModels.PurchaseRequestViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.PurchaseRequestViews
{
    public partial class PurchasRequestsView : Form
    {
        private PurchaseRequestSearchViewModel _searchModel;
        public PurchasRequestsView(PurchaseRequestSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel ?? throw new ArgumentNullException(nameof(searchViewModel));
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            cboParts.DataBindings.Clear();
            cboParts.DataSource = _searchModel.SpareParts;
            cboParts.DisplayMember = nameof(Models.SparePart.Code);
            cboParts.ValueMember = nameof(Models.SparePart.Self);
            cboParts.DataBindings.Add(new Binding(nameof(cboParts.SelectedItem), _searchModel, nameof(_searchModel.SparePart))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
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
            rdbheaders.DataBindings.Clear();
            rdbheaders.DataBindings.Add(new Binding(nameof(rdbheaders.Checked), _searchModel, nameof(_searchModel.DisplayResultByHeader))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            rdblines.DataBindings.Clear();
            rdblines.DataBindings.Add(new Binding(nameof(rdblines.Checked), _searchModel, nameof(_searchModel.DisplayResultByLine))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            pickfromDate.ValueChanged += (o, e) =>
            {
                if (pickfromDate.Checked)
                {
                    _searchModel.FromDate =
                        new DateTime(pickfromDate.Value.Year, pickfromDate.Value.Month, pickfromDate.Value.Day,0,0,0);
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
                    _searchModel.ToDate =
                        new DateTime(picktoDate.Value.Year, picktoDate.Value.Month, picktoDate.Value.Day, 23, 59, 59);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.AutoGenerateColumns = false;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridResults.ReadOnly = true;
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
            InitializeGrid();
            // ...
            btnSearch.Click += (o, e) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    _searchModel.Search();
                    InitializeGrid();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _ = MessageBox.Show(this, ex.Message, "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _ = MessageBox.Show(this, ex.Message, "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                catch (Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            // ....
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }

        public async void ExportToFile()
        {
            try
            {
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    await _searchModel.ExportToExcelAsync(saveFileDialog1.FileName);
                }

            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void InitializeGrid()
        {
            gridResults.Columns.Clear();
            gridResults.DataSource = null;
            if (_searchModel.DisplayResultByHeader)
            {
                gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestDTO.Number),
                    DataPropertyName = nameof(PurchaseRequestDTO.Number),
                    HeaderText = "Number",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestDTO.Description),
                    DataPropertyName = nameof(PurchaseRequestDTO.Description),
                    HeaderText = "Description",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestDTO.VehicleInternalCode),
                    DataPropertyName = nameof(PurchaseRequestDTO.VehicleInternalCode),
                    HeaderText = "Vehicle",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestDTO.RequestDate),
                    DataPropertyName = nameof(PurchaseRequestDTO.RequestDate),
                    HeaderText = "Date",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestDTO.RequestState),
                    DataPropertyName = nameof(PurchaseRequestDTO.RequestState),
                    HeaderText = "Request State",
                    ReadOnly = true
                });
                gridResults.DataSource = _searchModel.PurchaseRequests;
            }
            else
            {
                gridResults.Columns.AddRange(
                    new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.Number),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.Number),
                    HeaderText = "Number",
                    ReadOnly = true
                },
                    new DataGridViewTextBoxColumn()
                    {
                        Name = nameof(PurchaseRequestLineDTO.VehicleInternalCode),
                        DataPropertyName = nameof(PurchaseRequestLineDTO.VehicleInternalCode),
                        HeaderText = "Vehicle",
                        ReadOnly = true
                    },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.RequestDate),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.RequestDate),
                    HeaderText = "Date",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.SparePartCode),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.SparePartCode),
                    HeaderText = "Code",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.SparePartName),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.SparePartName),
                    HeaderText = "Name",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.UomCode),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.UomCode),
                    HeaderText = "Uom",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.RequestedQuantity),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.RequestedQuantity),
                    HeaderText = "Requested Quantity",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(PurchaseRequestLineDTO.ReceivedQuantity),
                    DataPropertyName = nameof(PurchaseRequestLineDTO.ReceivedQuantity),
                    HeaderText = "Received Quantity",
                    ReadOnly = true
                });
                gridResults.DataSource = _searchModel.PurchaseRequestLines;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
