using Reftruckegypt.Servicecenter.ViewModels.ReceiptLineViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.ReceiptLineViews
{
    public partial class ReceiptLinesView : Form
    {
        private ReceiptLineSearchViewModel _searchModel;
        public ReceiptLinesView(ReceiptLineSearchViewModel searchViewModel)
        {
            _searchModel = searchViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            cboRequests.DataSource = _searchModel.PurchaseRequests;
            cboRequests.DisplayMember = nameof(Models.PurchaseRequest.Number);
            cboRequests.ValueMember = nameof(Models.PurchaseRequest.Self);
            cboRequests.DataBindings.Add(new Binding(nameof(cboRequests.SelectedItem), _searchModel, nameof(_searchModel.PurchaseRequest))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _searchModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            // ....
            pickfromDate.ValueChanged += (o, e) =>
            {
                if (pickfromDate.Checked)
                {
                    _searchModel.FromDate = new DateTime(
                        pickfromDate.Value.Year, pickfromDate.Value.Month, pickfromDate.Value.Day,0,0,0);
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
                    _searchModel.ToDate = new DateTime(picktodate.Value.Year, picktodate.Value.Month, picktodate.Value.Day,23,59,59);
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            gridLines.AllowUserToAddRows = false;
            gridLines.AllowUserToDeleteRows = false;
            gridLines.AutoGenerateColumns = false;
            gridLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridLines.ReadOnly = true;
            gridLines.MultiSelect = false;
            gridLines.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridLines.SelectionChanged += (o, e) =>
            {
                if(gridLines.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex = gridLines.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            gridLines.Columns.Clear();
            gridLines.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = nameof(ReceiptLineDTO.ReceiptDate),
                DataPropertyName = nameof(ReceiptLineDTO.ReceiptDate),
                HeaderText = "Receipt Date",
                ReadOnly = true
            });
            gridLines.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = nameof(ReceiptLineDTO.SparePartCode),
                DataPropertyName = nameof(ReceiptLineDTO.SparePartCode),
                HeaderText = "Part Code",
                ReadOnly = true
            });
            gridLines.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = nameof(ReceiptLineDTO.SparePartName),
                DataPropertyName = nameof(ReceiptLineDTO.SparePartName),
                HeaderText = "Part Name",
                ReadOnly = true
            });
            gridLines.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = nameof(ReceiptLineDTO.UomCode),
                DataPropertyName = nameof(ReceiptLineDTO.UomCode),
                HeaderText = "Uom",
                ReadOnly = true
            });
            gridLines.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = nameof(ReceiptLineDTO.ReceivedQuantity),
                DataPropertyName = nameof(ReceiptLineDTO.ReceivedQuantity),
                HeaderText = "Received Quantity",
                ReadOnly = true
            });
            gridLines.DataSource = _searchModel.ReceiptLines;
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
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ....
            saveFileDialog1.Filter = "Excel Files (*.xlsx) | *.xlsx";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.RestoreDirectory = true;
        }

        public void  ExportToFile()
        {
            try
            {
                if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                     _searchModel.ExportToExcel(saveFileDialog1.FileName);
                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
