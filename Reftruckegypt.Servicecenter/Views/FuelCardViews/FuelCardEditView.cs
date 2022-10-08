using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.FuelCardViewModels;

namespace Reftruckegypt.Servicecenter.Views.FuelCardViews
{
    public partial class FuelCardEditView : Form
    {
        private FuelCardEditViewModel _editModel;
        public FuelCardEditView(FuelCardEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _editModel, nameof(_editModel.Name))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _editModel, nameof(_editModel.Number))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            txtRegistration.DataBindings.Clear();
            txtRegistration.DataBindings.Add(new Binding(nameof(txtRegistration.Text), _editModel, nameof(_editModel.Registration))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _editModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _editModel, nameof(_editModel.Vehicle))
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
