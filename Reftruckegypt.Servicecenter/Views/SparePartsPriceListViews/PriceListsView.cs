using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsPriceListViewModels;

namespace Reftruckegypt.Servicecenter.Views.SparePartsPriceListViews
{
    public partial class PriceListsView : Form
    {
        private SparePartsPriceListSearchViewModel _searchModel;
        public PriceListsView(SparePartsPriceListSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            pickfromdate.ValueChanged += (o, e) =>
            {
                 if (pickfromdate.Checked)
                 {
                    _searchModel.FromDate = new DateTime(pickfromdate.Value.Year, pickfromdate.Value.Month, pickfromdate.Value.Day,0,0,0);
                 }
                 else
                 {
                     _searchModel.FromDate = null;
                 }
            };
            // ...
            picktodate.ValueChanged += (o, e) =>
            {
                 if (picktodate.Checked)
                 {
                    _searchModel.ToDate = new DateTime(picktodate.Value.Year, picktodate.Value.Month, picktodate.Value.Day, 23, 59, 59);
                }
                 else
                 {
                     _searchModel.ToDate = null;
                 }
            };
            // ...
            rdheaders.DataBindings.Clear();
            rdheaders.DataBindings.Add(new Binding(nameof(rdheaders.Checked), _searchModel, nameof(_searchModel.HeaderResult))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            rdlines.DataBindings.Clear();
            rdlines.DataBindings.Add(new Binding(nameof(rdlines.Checked), _searchModel, nameof(_searchModel.LineResult))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            btnSearch.Click += (o, e) =>
            {
                 _searchModel.Search();
                InitializeGrid();
            };
            // ...
            gridResults.AllowUserToAddRows = false;
            gridResults.AllowUserToDeleteRows = false;
            gridResults.AutoGenerateColumns = false;
            gridResults.ReadOnly = true;
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
            InitializeGrid();
            // ...
            cboParts.DataBindings.Clear();
            cboParts.DataSource = _searchModel.SpareParts;
            cboParts.DisplayMember = nameof(Models.SparePart.Code);
            cboParts.ValueMember = nameof(Models.SparePart.Self);
            cboParts.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboParts.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboParts.DataBindings.Add(new Binding(nameof(cboParts.SelectedItem), _searchModel, nameof(_searchModel.SparePart))
            {
            });
            // ....
            btnCreate.Click += (o, e) => _searchModel.Create();
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            btnEdit.Click += (o, e) => _searchModel.Edit();
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled), _searchModel, nameof(_searchModel.IsDeleteEnabled)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            btnDelete.Click += (o, e) => _searchModel.Delete();
            // ...
            btnSearch.Click += (o, e) =>
            {
                  _searchModel.Search();
                  InitializeGrid();
            };
        }
        private void InitializeGrid()
        {
            gridResults.Columns.Clear();
            if (_searchModel.HeaderResult)
            {
                gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Number",
                    DataPropertyName = nameof(SparePartsPriceListHeaderViewModel.Number),
                    Name = nameof(SparePartsPriceListHeaderViewModel.Number)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Name",
                    DataPropertyName = nameof(SparePartsPriceListHeaderViewModel.Name),
                    Name = nameof(SparePartsPriceListHeaderViewModel.Name)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "From Date",
                    DataPropertyName = nameof(SparePartsPriceListHeaderViewModel.FromDate),
                    Name = nameof(SparePartsPriceListHeaderViewModel.FromDate)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "To Date",
                    DataPropertyName = nameof(SparePartsPriceListHeaderViewModel.ToDate),
                    Name = nameof(SparePartsPriceListHeaderViewModel.ToDate)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "State",
                    DataPropertyName = nameof(SparePartsPriceListHeaderViewModel.State),
                    Name = nameof(SparePartsPriceListHeaderViewModel.State)
                });
                gridResults.DataSource = _searchModel.Headers;
            }
            else if (_searchModel.LineResult)
            {
                gridResults.Columns.AddRange(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Number",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.Number),
                    Name = nameof(SparePartsPriceListLineViewModel.Number)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Name",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.Name),
                    Name = nameof(SparePartsPriceListLineViewModel.Name)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "From Date",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.FromDate),
                    Name = nameof(SparePartsPriceListLineViewModel.FromDate)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "To Date",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.ToDate),
                    Name = nameof(SparePartsPriceListLineViewModel.ToDate)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Code",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.SparePartCode),
                    Name = nameof(SparePartsPriceListLineViewModel.SparePartCode)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Name",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.SparePartName),
                    Name = nameof(SparePartsPriceListLineViewModel.SparePartName)
                }, 
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Uom",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.UomCode),
                    Name = nameof(SparePartsPriceListLineViewModel.UomCode)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Unit Price",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.UnitPrice),
                    Name = nameof(SparePartsPriceListLineViewModel.UnitPrice)
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "State",
                    DataPropertyName = nameof(SparePartsPriceListLineViewModel.State),
                    Name = nameof(SparePartsPriceListLineViewModel.State)
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
