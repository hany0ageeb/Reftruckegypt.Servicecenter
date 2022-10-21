using Reftruckegypt.Servicecenter.ViewModels.InternalMemoViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.InternalMemoViews
{
    public partial class InternalMemoEditView : Form
    {
        private InternalMemoEditViewModel _editModel;
        public InternalMemoEditView(InternalMemoEditViewModel editViewModel)
        {
            _editModel = editViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            txtNumber.DataBindings.Clear();
            txtNumber.DataBindings.Add(new Binding(nameof(txtNumber.Text), _editModel, nameof(_editModel.Number))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtSubject.DataBindings.Clear();
            txtSubject.DataBindings.Add(new Binding(nameof(txtSubject.Text), _editModel, nameof(_editModel.Header))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            txtContents.DataBindings.Clear();
            txtContents.DataBindings.Add(new Binding(nameof(txtContents.Text), _editModel, nameof(_editModel.Content))
            {

            });
            // ...
            pickMemoDate.DataBindings.Clear();
            pickMemoDate.DataBindings.Add(new Binding(nameof(pickMemoDate.Value), _editModel, nameof(_editModel.MemoDate))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cboVehicles.DataBindings.Clear();
            cboVehicles.DataSource = _editModel.Vehicles;
            cboVehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cboVehicles.ValueMember = nameof(Models.Vehicle.Self);
            cboVehicles.DataBindings.Add(new Binding(nameof(cboVehicles.SelectedItem), _editModel, nameof(_editModel.Vehicle)) { });
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged)) { DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged });
            btnSave.Click += (o, e) =>
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    if (_editModel.SaveOrUpdate())
                    {
                        pickMemoDate.Enabled = false;
                        cboVehicles.Enabled = false;
                        txtContents.ReadOnly = true;
                        txtSubject.ReadOnly = true;

                    }
                    else
                    {
                        System.Media.SystemSounds.Hand.Play();
                    }
                }
                catch(Exception ex)
                {
                    _ = MessageBox.Show(this, "Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            };
            // ...
            btnCancel.Click += (o, e) =>
            {
                if (_editModel.Close())
                {
                    Close();
                }
            };
            // ...
            FormClosing += (o, e) =>
            {
                if(_editModel.HasChanged && e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = !_editModel.Close();
                }
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}
