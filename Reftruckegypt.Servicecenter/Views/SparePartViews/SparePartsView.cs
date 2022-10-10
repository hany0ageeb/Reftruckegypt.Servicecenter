using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.SparePartViewModels;

namespace Reftruckegypt.Servicecenter.Views.SparePartViews
{
    public partial class SparePartsView : Form
    {
        private SparePartSearchViewModel _searchModel;
        public SparePartsView(SparePartSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtCodeOrName.DataBindings.Clear();
            txtCodeOrName.DataBindings.Add(new Binding(nameof(txtCodeOrName.Text), _searchModel, nameof(_searchModel.CodeOrName))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridParts.AllowUserToAddRows = false;
            gridParts.AllowUserToDeleteRows = false;
            gridParts.ReadOnly = true;
            gridParts.AutoGenerateColumns = false;
            gridParts.MultiSelect = false;
            gridParts.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridParts.Columns.Clear();
            gridParts.Columns.AddRange(
                new DataGridViewCheckBoxColumn()
                {
                    Name = nameof(SparePartViewModel.IsEnabled),
                    DataPropertyName = nameof(SparePartViewModel.IsEnabled),
                    HeaderText = "Enabled"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartViewModel.Code),
                    DataPropertyName = nameof(SparePartViewModel.Code),
                    HeaderText = "Code"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartViewModel.Name),
                    DataPropertyName = nameof(SparePartViewModel.Name),
                    HeaderText = "Name"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(SparePartViewModel.UomCode),
                    DataPropertyName = nameof(SparePartViewModel.UomCode),
                    HeaderText = "Uom"
                });
            gridParts.DataSource = _searchModel.SpareParts;
            gridParts.SelectionChanged += (o, e) =>
            {
                if (gridParts.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridParts.SelectedCells[0].RowIndex;
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
            btnEdit.DataBindings.Add(new Binding(nameof(btnEdit.Enabled), _searchModel, nameof(_searchModel.IsEditEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnEdit.Click += (o, e) =>
            {
                _searchModel.Edit();
            };
            // ...
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
    }
}
