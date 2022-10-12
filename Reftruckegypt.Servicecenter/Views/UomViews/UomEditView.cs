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
    public partial class UomEditView : Form
    {
        private UomEditViewModel _editModel;
        public UomEditView(UomEditViewModel editModel)
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
            txtCode.DataBindings.Clear();
            txtCode.DataBindings.Add(new Binding(nameof(txtCode.Text), _editModel, nameof(_editModel.Code)) 
            { 
            });
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _editModel, nameof(_editModel.Name))
            {
            });
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled),_editModel, nameof(_editModel.HasChanged)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            btnSave.Click += (o, e) =>
            {
                try
                {
                    if (_editModel.SaveOrUpdate())
                        Close();
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    if (_editModel.HasChanged)
                    {
                        e.Cancel = !_editModel.Close();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
            // ...
        }
    }
}
