using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.DriverViewModels;

namespace Reftruckegypt.Servicecenter.Views.DriverViews
{
    public partial class DriverEditView : Form
    {
        private DriverEditViewModel _editModel;
        public DriverEditView(DriverEditViewModel driverEditViewModel)
        {
            _editModel = driverEditViewModel;
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
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _editModel, nameof(_editModel.Name))
            {

            });
            // ...
            txtLicenseNumber.DataBindings.Clear();
            txtLicenseNumber.DataBindings.Add(new Binding(nameof(txtLicenseNumber.Text), _editModel, nameof(_editModel.LicenseNumber))
            {

            });
            // ...
            txtTrafficDepartment.DataBindings.Clear();
            txtTrafficDepartment.DataBindings.Add(new Binding(nameof(txtTrafficDepartment.Text), _editModel, nameof(_editModel.TrafficDepartmentName))
            {

            });
            // ...
            pickenddate.DataBindings.Clear();
            pickenddate.DataBindings.Add(new Binding(nameof(pickenddate.Value), _editModel, nameof(_editModel.LicenseEndDate))
            {

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
            // ...
            FormClosing += (o, e) =>
            {
                e.Cancel = !_editModel.Close();
            };
            // ...
            errorProvider1.DataSource = _editModel;
            
        }
    }
}
