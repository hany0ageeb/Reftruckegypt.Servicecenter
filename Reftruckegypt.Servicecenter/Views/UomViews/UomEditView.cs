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
                if (_editModel.SaveOrUpdate())
                    Close();
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                if (_editModel.Close())
                    Close();
            };
            // ...
            FormClosing += (o, e) =>
            {
                if (_editModel.HasChanged)
                {
                    e.Cancel = !_editModel.Close();
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
            // ...
        }
    }
}
