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
    public partial class ExternalAutoRepairShopEditView : Form
    {
        private ExternalAutoRepairShopEditViewModel _editModel;
        public ExternalAutoRepairShopEditView(ExternalAutoRepairShopEditViewModel editModel)
        {
            _editModel = editModel;
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
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text),_editModel,nameof(_editModel.Name)));
            // ...
            txtAddress.DataBindings.Clear();
            txtAddress.DataBindings.Add(new Binding(nameof(txtAddress.Text),_editModel,nameof(_editModel.Address)));
            // ...
            txtPhone.DataBindings.Clear();
            txtPhone.DataBindings.Add(new Binding(nameof(txtPhone.Text),_editModel,nameof(_editModel.Phone)));
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled),_editModel,nameof(_editModel.HasChanged)));
            btnSave.Click += (o, e) =>
            {
                try
                {
                    if (_editModel.SaveOrUpdate())
                    {
                        Close();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                try
                {
                    if (_editModel.Close())
                    {
                        Close();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
            // ...
            FormClosing += (o, e) =>
            {
                if(e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = !_editModel.Close();
                }
            };
        }
    }
}
