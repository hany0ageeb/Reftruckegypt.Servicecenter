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
using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;

namespace Reftruckegypt.Servicecenter.Views.PeriodViews
{
    public partial class PeriodsView : Form
    {
        private PeriodSearchViewModel _searchModel;
        public PeriodsView(PeriodSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
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
            pickDate.ValueChanged += (o, e) =>
            {
                if (pickDate.Checked)
                {
                    _searchModel.Date = pickDate.Value;
                }
                else
                {
                    _searchModel.Date = null;
                }
            };
            // ...
            gridPeriods.AllowUserToAddRows = false;
            gridPeriods.AllowUserToDeleteRows = false;
            gridPeriods.MultiSelect = false;
            gridPeriods.ReadOnly = true;
            gridPeriods.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridPeriods.ReadOnly = true;
            gridPeriods.AutoGenerateColumns = false;
            gridPeriods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridPeriods.Columns.Clear();
            gridPeriods.Columns.AddRange(new DataGridViewTextBoxColumn()
            {
                Name = nameof(Period.Name),
                DataPropertyName = nameof(Period.Name),
                HeaderText = "Name"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(Period.FromDate),
                DataPropertyName = nameof(Period.FromDate),
                HeaderText = "From"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(Period.ToDate),
                DataPropertyName = nameof(Period.ToDate),
                HeaderText = "To"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(Period.State),
                DataPropertyName = nameof(Period.State),
                HeaderText = "State"
            },
            new DataGridViewButtonColumn()
            {
                Name = "Change State",
                Text = "Change State",
                UseColumnTextForButtonValue = true,
                HeaderText = ""
            });
            gridPeriods.Columns[nameof(Period.FromDate)].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
            gridPeriods.Columns[nameof(Period.ToDate)].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
            gridPeriods.DataSource = _searchModel.Periods;
            gridPeriods.SelectionChanged += (o, e) =>
            {
                if (gridPeriods.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridPeriods.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            gridPeriods.CellContentClick += (o, e) =>
             {
                 if (e.ColumnIndex == gridPeriods.Columns["Change State"].Index)
                 {
                     _searchModel.ChangeSelectedPeriodState();
                 }
             };
            // ...
            btnSearch.Click += (o, e)=>
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
                if (_searchModel.Periods.Count > 0)
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
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
