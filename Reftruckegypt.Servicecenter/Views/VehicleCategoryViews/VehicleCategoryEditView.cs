using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleCategoryViews
{
    public partial class VehicleCategoryEditView : Form
    {
        private VehicleCategoryEditViewModel _editModel;
        public VehicleCategoryEditView(VehicleCategoryEditViewModel editViewModel)
        {
            _editModel = editViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text),_editModel,nameof(_editModel.Name))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
                
            });
            txtName.Validating += (o, e) =>
            {
                if (!string.IsNullOrEmpty(_editModel.IsNameValid(txtName.Text)))
                {
                    e.Cancel = true;
                    System.Media.SystemSounds.Hand.Play();
                }
            };
            // ...
            txtDescription.DataBindings.Clear();
            txtDescription.DataBindings.Add(new Binding(nameof(txtDescription.Text), _editModel, nameof(_editModel.Description))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnValidation
            });
            txtDescription.Validating += (o, e) =>
            {
                if (!string.IsNullOrEmpty(_editModel.IsDescriptionValid(txtDescription.Text)))
                {
                    e.Cancel = true;
                    System.Media.SystemSounds.Hand.Play();
                }
            };
            // ...
            chkChassisNumberRequired.DataBindings.Clear();
            chkChassisNumberRequired.DataBindings.Add(new Binding(nameof(chkChassisNumberRequired.Checked),_editModel,nameof(_editModel.IsChassisNumberRequired))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            chkFuelCardRequired.DataBindings.Clear();
            chkFuelCardRequired.DataBindings.Add(new Binding(nameof(chkFuelCardRequired.Checked), _editModel,nameof(_editModel.IsFuelCardRequired))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled),_editModel,nameof(_editModel.IsSaveEnabled)));
            btnSave.Click += (o, e) =>
            {
                var modelState = _editModel.SaveOrUpdate();
                if (!modelState.HasErrors)
                {
                    Close();
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {

            };
            // ...
            errorProvider1.DataSource = _editModel;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_editModel.Close())
            {
                Close();
            }
        }

        private void VehicleCategoryEditView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = !_editModel.Close();
            }
        }
    }
}
