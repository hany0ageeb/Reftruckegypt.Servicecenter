using Reftruckegypt.Servicecenter.ViewModels.VehicleModelViewModels;
using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.VehicleModelViews
{
    public partial class VehicleModelEditView : Form
    {
        private VehicleModelEditViewModel _editModel;
        public VehicleModelEditView(VehicleModelEditViewModel editModel)
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
            txtName.Validating += (o, e) =>
            {
                if (!_editModel.ValidateName(txtName.Text))
                {
                    e.Cancel = true;
                    System.Media.SystemSounds.Hand.Play();
                }
            };
            // ...
            txtDescription.DataBindings.Clear();
            txtDescription.DataBindings.Add(new Binding(nameof(txtDescription.Text), _editModel, nameof(_editModel.Description)) 
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            txtDescription.Validating += (o, e) =>
            {
                if (!_editModel.ValidteDescription(txtDescription.Text))
                {
                    e.Cancel = true;
                    System.Media.SystemSounds.Hand.Play();
                }
            };
            // ...
            cboFuelTypes.DataBindings.Clear();
            cboFuelTypes.DataSource = _editModel.FuelTypes;
            cboFuelTypes.DisplayMember = nameof(FuelType.Name);
            cboFuelTypes.ValueMember = nameof(FuelType.Self);
            cboFuelTypes.DataBindings.Add(new Binding(nameof(cboFuelTypes.SelectedItem), _editModel, nameof(_editModel.FuelType)) 
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged)));
            btnSave.Click += (o, e) =>
            {
                try
                {
                    if (_editModel.SaveOrUpdte())
                    {
                        Close();
                    }
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
                    {
                        Close();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
            FormClosing += (o, e) =>
            {
                if(_editModel.HasChanged && e.CloseReason == CloseReason.UserClosing)
                {
                    try
                    {
                        e.Cancel = !_editModel.Close();
                    }
                    catch(Exception ex)
                    {
                        _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
