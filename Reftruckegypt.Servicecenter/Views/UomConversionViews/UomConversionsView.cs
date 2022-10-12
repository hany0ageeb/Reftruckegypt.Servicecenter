using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.UomConversionViewModels;

namespace Reftruckegypt.Servicecenter.Views.UomConversionViews
{
    public partial class UomConversionsView : Form
    {
        private UomConversionSearchViewModel _searchModel;
        public UomConversionsView(UomConversionSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            cboParts.DataBindings.Clear();
            cboParts.DataBindings.Add(new Binding(nameof(cboParts.SelectedItem), _searchModel, nameof(_searchModel.SparePart))
            {

            });
            cboParts.DataSource = _searchModel.SpareParts;
            cboParts.DisplayMember = nameof(Models.SparePart.Code);
            cboParts.ValueMember = nameof(Models.SparePart.Self);
            // ...
            cbofromUoms.DataBindings.Clear();
            cbofromUoms.DataSource = _searchModel.Uoms;
            cbofromUoms.DisplayMember = nameof(Models.Uom.Code);
            cbofromUoms.ValueMember = nameof(Models.Uom.Self);
            cbofromUoms.DataBindings.Add(new Binding(nameof(cbofromUoms.SelectedItem), _searchModel, nameof(_searchModel.FromUom))
            {

            });
            // ...
            cbotoUoms.DataSource = _searchModel.Uoms;
            cbotoUoms.DataBindings.Clear();
            cbotoUoms.DisplayMember = nameof(Models.Uom.Code);
            cbotoUoms.ValueMember = nameof(Models.Uom.Self);
            cbotoUoms.DataBindings.Add(new Binding(nameof(cbotoUoms.SelectedItem), _searchModel, nameof(_searchModel.ToUom))
            {

            });
            // ...
            gridConversions.AllowUserToAddRows = false;
            gridConversions.AllowUserToDeleteRows = false;
            gridConversions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridConversions.ReadOnly = true;
            gridConversions.AutoGenerateColumns = false;
            gridConversions.Columns.Clear();
            gridConversions.Columns.AddRange(new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionViewModel.SparePartCode),
                DataPropertyName = nameof(UomConversionViewModel.SparePartCode),
                HeaderText = "Spare Part"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionViewModel.FromUomCode),
                DataPropertyName = nameof(UomConversionViewModel.FromUomCode),
                HeaderText = "From UOM"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionViewModel.ToUomCode),
                DataPropertyName = nameof(UomConversionViewModel.ToUomCode),
                HeaderText = "To UOM"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionViewModel.ConversionRate),
                DataPropertyName = nameof(UomConversionViewModel.ConversionRate),
                HeaderText = "Conversion Rate"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(UomConversionViewModel.Notes),
                DataPropertyName = nameof(UomConversionViewModel.Notes),
                HeaderText = "Notes"
            });
            gridConversions.SelectionChanged += (o, e) =>
            {
                if(gridConversions.SelectedCells.Count > 0)
                {
                    _searchModel.SelectedIndex =  gridConversions.SelectedCells[0].RowIndex;
                }
                else
                {
                    _searchModel.SelectedIndex = -1;
                }
            };
            gridConversions.DataSource = _searchModel.UomConversions;
            // ...
            btnSearch.Click += (o, e) =>
            {
                try
                {
                    _searchModel.Search();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            btnCreate.Click += (o, e) =>
            {
                try
                {
                    _searchModel.Create();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
