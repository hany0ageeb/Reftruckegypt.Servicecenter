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
                        btnSave.Enabled = false;
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
            _editModel.PropertyChanged += (o, e) =>
             {
                 if (e.PropertyName == nameof(_editModel.BillImageFilePath))
                 {
                     try
                     {
                         if (!string.IsNullOrEmpty(_editModel.BillImageFilePath) && System.IO.File.Exists(_editModel.BillImageFilePath))
                         {
                             pictureBox1.Image = Image.FromFile(_editModel.BillImageFilePath);
                             pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                             errorProvider1.SetError(pictureBox1, "");
                         }
                         else
                         {
                             if (!string.IsNullOrEmpty(_editModel.BillImageFilePath))
                             {
                                 errorProvider1.SetError(pictureBox1, "Invalid Image File");
                             }
                         }
                         
                     }
                     catch(Exception ex)
                     {
                         errorProvider1.SetError(pictureBox1, ex.Message);
                     }
                  }
             };
            // ..
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|(*.jpeg)|*.jpeg";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            // ...
            if(!string.IsNullOrEmpty(_editModel.BillImageFilePath) && System.IO.File.Exists(_editModel.BillImageFilePath) && (_editModel.BillImageFilePath.EndsWith(".jpg") || _editModel.BillImageFilePath.EndsWith(".jpeg")))
            {
                pictureBox1.Image = Image.FromFile(_editModel.BillImageFilePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                errorProvider1.SetError(pictureBox1, "");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                _editModel.BillImageFilePath = openFileDialog1.FileName;
            }
        }
    }
}
