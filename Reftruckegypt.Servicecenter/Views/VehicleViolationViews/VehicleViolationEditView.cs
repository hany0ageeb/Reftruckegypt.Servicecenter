﻿using Reftruckegypt.Servicecenter.ViewModels.VehicleViolationViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.VehicleViolationViews
{
    public partial class VehicleViolationEditView : Form
    {
        private VehicleViolationEditViewModel _editModel;
        public VehicleViolationEditView(VehicleViolationEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ....
            pickViolationDate.DataBindings.Clear();
            pickViolationDate.DataBindings.Add(new Binding(nameof(pickViolationDate.Value),_editModel, nameof(_editModel.ViolationDate))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridViolations.AllowUserToAddRows = true;
            gridViolations.AllowUserToDeleteRows = true;
            gridViolations.AutoGenerateColumns = false;
            gridViolations.ReadOnly = false;
            gridViolations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridViolations.Columns.Clear();
            gridViolations.Columns.AddRange(
                new DataGridViewComboBoxColumn()
                {
                    Name = nameof(VehicleViolationLineEditViewModel.Vehicle),
                    DataPropertyName = nameof(VehicleViolationLineEditViewModel.Vehicle),
                    DataSource = _editModel.Vehicles,
                    DisplayMember = nameof(Models.Vehicle.InternalCode),
                    ValueMember = nameof(Models.Vehicle.Self),
                    ValueType = typeof(Models.Vehicle),
                    HeaderText = "Vehicle"
                },
                new DataGridViewComboBoxColumn()
                {
                    Name = nameof(VehicleViolationLineEditViewModel.ViolationType),
                    DataPropertyName = nameof(VehicleViolationLineEditViewModel.ViolationType),
                    DataSource = _editModel.ViolationTypes,
                    DisplayMember = nameof(Models.ViolationType.Name),
                    ValueMember = nameof(Models.ViolationType.Self),
                    ValueType = typeof(Models.ViolationType),
                    HeaderText = "Violation Type"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationLineEditViewModel.Count),
                    DataPropertyName = nameof(VehicleViolationLineEditViewModel.Count),
                    HeaderText = "Violation Count"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(VehicleViolationLineEditViewModel.Notes),
                    DataPropertyName = nameof(VehicleViolationLineEditViewModel.Notes),
                    HeaderText = "Notes"
                }
            );
            gridViolations.DataSource = _editModel.Lines;
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
