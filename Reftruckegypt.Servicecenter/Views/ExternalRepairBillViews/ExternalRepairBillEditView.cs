using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.ExternalRepairBillViews
{
    public partial class ExternalRepairBillEditView : Form
    {
        private ExternalRepairBillEditViewModel _editModel;
        public ExternalRepairBillEditView(ExternalRepairBillEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtAmounts.DataBindings.Clear();
            txtAmounts.DataBindings.Add(new Binding(nameof(txtAmounts.Text), _editModel, nameof(_editModel.TotalAmountInEGP))
            {

            });
            // ...
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _editModel, nameof(_editModel.Number))
            {

            });
            // ...
            txtRepairs.DataBindings.Clear();
            txtRepairs.DataBindings.Add(new Binding(nameof(txtRepairs.Text),_editModel,nameof(_editModel.Repairs))
            {

            });
            // ...
            txtSupplierBillNumber.DataBindings.Clear();
            txtSupplierBillNumber.DataBindings.Add(new Binding(nameof(txtSupplierBillNumber.Text),_editModel,nameof(_editModel.SupplierBillNumber))
            {

            });
            // ...
            pickBillDate.DataBindings.Clear();
            pickBillDate.DataBindings.Add(new Binding(nameof(pickBillDate.Value), _editModel, nameof(_editModel.BillDate))
            {

            });
            // ...
            cboShops.DataBindings.Clear();
            cboShops.DataSource = _editModel.ExternalAutoRepairShops;
            cboShops.DisplayMember = nameof(ExternalAutoRepairShop.Name);
            cboShops.ValueMember = nameof(ExternalAutoRepairShop.Self);
            cboShops.DataBindings.Add(new Binding(nameof(cboShops.SelectedItem), _editModel, nameof(_editModel.ExternalAutoRepairShop))
            {

            });
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _editModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _editModel, nameof(_editModel.Vehicle))
            {

            });
            // ....
            errorProvider1.DataSource = _editModel;
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
                    if (_editModel.SaveOrUpdate())
                    {
                        System.Media.SystemSounds.Beep.Play();
                        txtAmounts.ReadOnly = true;
                        txtFilePath.ReadOnly = true;
                        cboShops.Enabled = false;
                        cboVehicles.Enabled = false;
                        txtRepairs.ReadOnly = true;
                        txtSupplierBillNumber.Enabled = true;
                    }
                    else
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // ...
        }
    }
}
