using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.ExternalAutoRepairShopViewModels;

namespace Reftruckegypt.Servicecenter.Views.ExternalAutoRepairShopViews
{
    public partial class ExternalAutoRepairShopsView : Form
    {
        private ExternalAutoRepairShopSearchViewModel _searchModel;
        public ExternalAutoRepairShopsView(ExternalAutoRepairShopSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        public void ExportToFile()
        {
            try
            {
                if (_searchModel.ExternalAutoRepairShopViewModels.Count > 0)
                {
                    if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                    {
                        _searchModel.ExportToFile(saveFileDialog1.FileName);
                    }
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private void Initialize()
        {
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _searchModel, nameof(_searchModel.Name)));
            // ...
            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add(new Binding(nameof(txtAddress.Text), _searchModel, nameof(_searchModel.Address)));
            // ...
            shopsGrid.AutoGenerateColumns = false;
            shopsGrid.AllowUserToAddRows = false;
            shopsGrid.AllowUserToDeleteRows = false;
            shopsGrid.MultiSelect = false;
            shopsGrid.ReadOnly = true;
            shopsGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            shopsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            shopsGrid.Columns.Clear();
            shopsGrid.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalAutoRepairShopViewModel.IsEnabled),
                    DataPropertyName = nameof(ExternalAutoRepairShopViewModel.IsEnabled),
                    HeaderText = "Enabled",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalAutoRepairShopViewModel.Name),
                    DataPropertyName = nameof(ExternalAutoRepairShopViewModel.Name),
                    ReadOnly = true,
                    HeaderText = "Name"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalAutoRepairShopViewModel.Address),
                    DataPropertyName = nameof(ExternalAutoRepairShopViewModel.Address),
                    HeaderText = "Address",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalAutoRepairShopViewModel.Phone),
                    DataPropertyName = nameof(ExternalAutoRepairShopViewModel.Phone),
                    HeaderText = "Phone",
                    ReadOnly = true
                }
           );
            shopsGrid.DataSource = _searchModel.ExternalAutoRepairShopViewModels;
            shopsGrid.SelectionChanged += (o, e) =>
            {
                if(shopsGrid.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = shopsGrid.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            shopsGrid.DataBindingComplete += (o, e) =>
            {
                if(shopsGrid.Rows.Count > 0)
                {
                   
                    foreach (DataGridViewRow row in shopsGrid.Rows)
                    {
                        if (row.Cells[nameof(ExternalAutoRepairShopViewModel.IsEnabled)].Value.ToString() == "Yes")
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                }
                
            };
            // ...
            btnSearch.Click += (o, e) =>
            {
                _searchModel.Search();
                if(_searchModel.ExternalAutoRepairShopViewModels.Count > 0)
                {
                    shopsGrid.Rows[0].Cells[0].Selected = true;
                    _searchModel.SelectedIndex = 0;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            // ...
            btnDelete.DataBindings.Clear();
            btnDelete.DataBindings.Add(new Binding(nameof(btnDelete.Enabled),_searchModel,nameof(_searchModel.IsDeleteEnabled)));
            btnDelete.Click += (o, e) =>
            {
                _searchModel.Delete();
            };
            // ...
            btnEdit.DataBindings.Clear();
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled)));
            btnEdit.Click += (o, e) =>
            {
                _searchModel.Edit();
            };
            // ...
            btnCreate.Click += (o, e) =>
            {
                _searchModel.Create();
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
    }
}
