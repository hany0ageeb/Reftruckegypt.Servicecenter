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
    public partial class ReceiptLinesEditView : Form
    {
        private ReceiptEditViewModel _editModel;
        public ReceiptLinesEditView(ReceiptEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            pickReceiptDate.DataBindings.Clear();
            pickReceiptDate.DataBindings.Add(new Binding(nameof(pickReceiptDate.Value), _editModel, nameof(_editModel.ReceiptDate))
            {

            });
            // ...
            gridLines.AllowUserToAddRows = false;
            gridLines.AllowUserToDeleteRows = false;
            gridLines.ReadOnly = false;
            gridLines.MultiSelect = false;
            gridLines.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridLines.AutoGenerateColumns = false;
            gridLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridLines.Columns.Clear();
            gridLines.Columns.AddRange(
                new DataGridViewCheckBoxColumn()
                {
                    DataPropertyName = nameof(ReceiptLineEditViewModel.IsSelected),
                    Name = nameof(ReceiptLineEditViewModel.IsSelected),
                    ReadOnly = false,
                    HeaderText = "|"
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = nameof(ReceiptLineEditViewModel.ReceivedQuantity),
                    Name = nameof(ReceiptLineEditViewModel.ReceivedQuantity),
                    ReadOnly = false,
                    HeaderText = "Quantity"
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = nameof(ReceiptLineEditViewModel.SparePartUomCode),
                    Name = nameof(ReceiptLineEditViewModel.SparePartUomCode),
                    ReadOnly = true,
                    HeaderText = "Uom"
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = nameof(ReceiptLineEditViewModel.SparePartCode),
                    Name = nameof(ReceiptLineEditViewModel.SparePartCode),
                    ReadOnly = true,
                    HeaderText = "Code"
                },
                new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = nameof(ReceiptLineEditViewModel.SparePartName),
                    Name = nameof(ReceiptLineEditViewModel.SparePartName),
                    ReadOnly = true,
                    HeaderText = "Name"
                }
                );
            gridLines.DataSource = _editModel.Lines;
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged)) 
            { 
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnSave.Click += (o, e) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (_editModel.SaveOrUpdate())
                    {
                        Close();
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
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                try
                {
                    if (_editModel.Close())
                        Close();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            FormClosing += (o, e) =>
            {
                if (_editModel.HasChanged && e.CloseReason == CloseReason.UserClosing)
                    e.Cancel = !_editModel.Close();
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
