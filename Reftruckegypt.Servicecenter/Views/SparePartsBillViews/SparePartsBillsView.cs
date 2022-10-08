using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;

namespace Reftruckegypt.Servicecenter.Views.SparePartsBillViews
{
    public partial class SparePartsBillsView : Form
    {
        private SparePartsBillSearchViewModel _searchModel;
        public SparePartsBillsView(SparePartsBillSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            rdbheaders.DataBindings.Clear();
            rdbheaders.DataBindings.Add(new Binding(nameof(rdbheaders.Checked), _searchModel, nameof(_searchModel.DisplayResultByHeader))
            { 
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            rdblines.DataBindings.Clear();
            rdblines.DataBindings.Add(new Binding(nameof(rdblines.Checked), _searchModel, nameof(_searchModel.DisplayResultByLine))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
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
            pickfromDate.ValueChanged += (o, e) =>
            {
                if (pickfromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(pickfromDate.Value.Year, pickfromDate.Value.Month, pickfromDate.Value.Day, 0, 0, 0);
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
                    _searchModel.ToDate = new DateTime(picktoDate.Value.Year, picktoDate.Value.Month, picktoDate.Value.Day, 0, 0, 0);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            btnSearch.Click+= (o, e) => 
            {
                InitializeResultGrid();
                _searchModel.Search();
            };
            // ...
            btnCreate.Click += (o, e) => _searchModel.Create();
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.IsDeleteEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnDelete.Click += (o, e) => { _searchModel.Delete(); };
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) => _searchModel.Edit();
            // ...
            gridResults.ReadOnly = true;
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.AutoGenerateColumns = false;
            gridResults.MultiSelect = false;
            gridResults.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            
            InitializeResultGrid();
            // ....
        }
        private void InitializeResultGrid()
        {
            gridResults.Columns.Clear();
            if (_searchModel.DisplayResultByHeader)
            {
                gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillHeaderViewModel.Number),
                    DataPropertyName = nameof(SparePartsBillHeaderViewModel.Number),
                    HeaderText = "Number"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillHeaderViewModel.State),
                    DataPropertyName = nameof(SparePartsBillHeaderViewModel.State),
                    HeaderText = "State"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillHeaderViewModel.BillDate),
                    DataPropertyName = nameof(SparePartsBillHeaderViewModel.BillDate),
                    HeaderText = "Date"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillHeaderViewModel.VehicleInternalCode),
                    DataPropertyName = nameof(SparePartsBillHeaderViewModel.VehicleInternalCode),
                    HeaderText = "Vehicle"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillHeaderViewModel.Repairs),
                    DataPropertyName = nameof(SparePartsBillHeaderViewModel.Repairs),
                    HeaderText = "Repairs"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillHeaderViewModel.TotalAmount),
                    DataPropertyName = nameof(SparePartsBillHeaderViewModel.TotalAmount),
                    HeaderText = "Total Amount"
                });
                gridResults.DataSource = _searchModel.Headers;
            }
            else
            {
                gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.Number),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.Number),
                    HeaderText = "Number"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.State),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.State),
                    HeaderText = "State"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.BillDate),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.BillDate),
                    HeaderText = "Date"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.VehicleInternalCode),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.VehicleInternalCode),
                    HeaderText = "Vehicle"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.SparePartCode),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.SparePartCode),
                    HeaderText = "Part Code"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.SparePartName),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.SparePartName),
                    HeaderText = "Part Name"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.UomCode),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.UomCode),
                    HeaderText = "Uom"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.Quantity),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.Quantity),
                    HeaderText = "Quantity"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.UnitPrice),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.UnitPrice),
                    HeaderText = "Unit Price"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartsBillLineViewModel.TotalAmount),
                    DataPropertyName = nameof(SparePartsBillLineViewModel.TotalAmount),
                    HeaderText = "Total"
                });
                gridResults.DataSource = _searchModel.Lines;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
