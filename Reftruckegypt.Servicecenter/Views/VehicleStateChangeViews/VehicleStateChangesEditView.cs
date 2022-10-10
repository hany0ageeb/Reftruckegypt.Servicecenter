using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.VehicleStateChangeViewModels;

namespace Reftruckegypt.Servicecenter.Views.VehicleStateChangeViews
{
    public partial class VehicleStateChangesEditView : Form
    {
        private VehicleStateChangesEditModel _editModel;
        public VehicleStateChangesEditView(VehicleStateChangesEditModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        public void Initialize()
        {
            // ....
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnSave.Click += (o, e) =>
            {
                if (_editModel.SaveOrUpdate())
                    Close();
            };
            // ....
            btnClose.Click += (o, e) =>
            {
                if (_editModel.Close())
                    Close();
            };
            // ....
            FormClosing += (o, e) =>
            {
                if(e.CloseReason == CloseReason.UserClosing && _editModel.HasChanged)
                {
                    e.Cancel = !_editModel.Close();
                }
            };
            // ...
            gridLines.AllowUserToAddRows = true;
            gridLines.AllowUserToDeleteRows = true;
            gridLines.AutoGenerateColumns = false;
            gridLines.MultiSelect = false;
            gridLines.ReadOnly = false;
            gridLines.Columns.Clear();
            gridLines.Columns.AddRange(new DataGridViewComboBoxColumn()
            {
                DataSource = _editModel.Vehicles,
                DisplayMember = nameof(Models.Vehicle.InternalCode),
                ValueMember = nameof(Models.Vehicle.Self),
                ValueType = typeof(Models.Vehicle),
                DataPropertyName = nameof(VehicleStateChangeEditModel.Vehicle),
                Name = nameof(VehicleStateChangeEditModel.Vehicle),
                HeaderText = "Vehicle"
            },
            new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(VehicleStateChangeEditModel.FromDate),
                Name = nameof(VehicleStateChangeEditModel.FromDate),
                HeaderText = "From Date"
            },
            new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(VehicleStateChangeEditModel.ToDate),
                Name = nameof(VehicleStateChangeEditModel.ToDate),
                HeaderText = "To Date"
            },
            new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(VehicleStateChangeEditModel.Notes),
                Name = nameof(VehicleStateChangeEditModel.Notes),
                HeaderText = "Reason"
            });
            gridLines.DataSource = _editModel.Lines;


        }
    }
}
