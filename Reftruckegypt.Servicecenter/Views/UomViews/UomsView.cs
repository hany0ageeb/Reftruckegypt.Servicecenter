using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.UomViewModels;

namespace Reftruckegypt.Servicecenter.Views.UomViews
{
    public partial class UomsView : Form
    {
        private readonly UomSearchViewModel _searchModel;
        public UomsView(UomSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtCodeOrName.DataBindings.Clear();
            txtCodeOrName.DataBindings.Add(new Binding(nameof(txtCodeOrName.Text), _searchModel, nameof(_searchModel.Name))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridUoms.AllowUserToAddRows = false;
            gridUoms.AllowUserToDeleteRows = false;
            gridUoms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridUoms.AutoGenerateColumns = false;
            gridUoms.ReadOnly = true;
            gridUoms.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridUoms.MultiSelect = false;
            gridUoms.Columns.Clear();
            gridUoms.Columns.AddRange(
                new DataGridViewCheckBoxColumn()
                {
                    Name = nameof(Models.Uom.IsEnabled),
                    DataPropertyName = nameof(Models.Uom.IsEnabled),
                    HeaderText = "Enabled",
                    ReadOnly = true
                    
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(Models.Uom.Code),
                    DataPropertyName = nameof(Models.Uom.Code),
                    HeaderText = "Code",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(Models.Uom.Name),
                    DataPropertyName = nameof(Models.Uom.Name),
                    HeaderText = "Name",
                    ReadOnly = true
                });
            gridUoms.DataSource = _searchModel.Uoms;
            gridUoms.SelectionChanged += (o, e) =>
            {
                if(gridUoms.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridUoms.SelectedCells[0].RowIndex;
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
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled),_searchModel,nameof(_searchModel.IsEditEnabled)) 
            { 
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) =>
            {
                _searchModel.Edit();
            };
            // ...
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
