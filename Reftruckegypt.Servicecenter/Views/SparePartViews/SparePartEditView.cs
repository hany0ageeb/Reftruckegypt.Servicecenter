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
    public partial class SparePartEditView : Form
    {
        private SparePartEditViewModel _editModel;
        public SparePartEditView(SparePartEditViewModel editViewModel)
        {
            _editModel = editViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            chkEnabled.DataBindings.Clear();
            chkEnabled.DataBindings.Add(new Binding(nameof(chkEnabled.Checked), _editModel, nameof(_editModel.IsEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtCode.DataBindings.Clear();
            txtCode.DataBindings.Add(new Binding(nameof(txtCode.Text), _editModel, nameof(_editModel.Code))
            {

            });
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _editModel, nameof(_editModel.Name))
            {

            });
            // ...
            cboUoms.DataBindings.Clear();
            cboUoms.DataSource = _editModel.Uoms;
            cboUoms.DisplayMember = nameof(Models.Uom.Code);
            cboUoms.ValueMember = nameof(Models.Uom.Self);
            cboUoms.DataBindings.Add(new Binding(nameof(cboUoms.SelectedItem), _editModel, nameof(_editModel.PrimaryUom))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            cboUoms.DataBindings.Add(new Binding(nameof(cboUoms.Enabled), _editModel, nameof(_editModel.IsUomEnabled))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnSave.Click += (o, e) =>
            {
                if (_editModel.SaveOrUpdate())
                    Close();
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                if (_editModel.Close())
                    Close();
            };
            // ....
            FormClosing += (o, e) =>
            {
                if(_editModel.HasChanged)
                    e.Cancel = !_editModel.Close();
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
