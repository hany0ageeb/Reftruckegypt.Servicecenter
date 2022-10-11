﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.SparePartsBillViewModels;

namespace Reftruckegypt.Servicecenter.Views.SparePartsBillViews
{
    public partial class SparePartsBillEditView : Form
    {
        private SparePartsBillEditViewModel _editModel;
        public SparePartsBillEditView(SparePartsBillEditViewModel editViewModel)
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
            // ....
            txtRepairs.DataBindings.Clear();
            txtRepairs.DataBindings.Add(new Binding(nameof(txtRepairs.Text), _editModel, nameof(_editModel.Repairs))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ....
            pickbillDate.DataBindings.Clear();
            pickbillDate.DataBindings.Add(new Binding(nameof(pickbillDate.Value), _editModel, nameof(_editModel.BillDate))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cbovehicles.DataBindings.Clear();
            cbovehicles.DataSource = _editModel.Vehicles;
            cbovehicles.DisplayMember = nameof(Models.Vehicle.InternalCode);
            cbovehicles.ValueMember = nameof(Models.Vehicle.Self);
            cbovehicles.DataBindings.Add(new Binding(nameof(cbovehicles.SelectedItem), _editModel, nameof(_editModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridLines.AllowUserToAddRows = true;
            gridLines.AllowUserToDeleteRows = true;
            gridLines.MultiSelect = false;
            gridLines.ReadOnly = false;
            gridLines.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridLines.AutoGenerateColumns = false;
            //gridLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridLines.Columns.Clear();
            gridLines.Columns.AddRange(new DataGridViewComboBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.SparePart),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.SparePart),
                HeaderText = "Spare Part",
                DataSource = _editModel.SpareParts,
                DisplayMember = nameof(Models.SparePart.Code),
                ValueMember = nameof(Models.SparePart.Self),
                ValueType = typeof(Models.SparePart),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewComboBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.Uom),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.Uom),
                HeaderText = "Unit Of Measure",
                DataSource = _editModel.Uoms,
                DisplayMember = nameof(Models.Uom.Code),
                ValueMember = nameof(Models.Uom.Self),
                ValueType = typeof(Models.Uom),
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.Quantity),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.Quantity),
                HeaderText = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            },
            new DataGridViewTextBoxColumn()
            {
                Name = nameof(SparePartsBillLineEditViewModel.Notes),
                DataPropertyName = nameof(SparePartsBillLineEditViewModel.Notes),
                HeaderText = "Notes",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            gridLines.DataSource = _editModel.Lines;
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _editModel, nameof(_editModel.HasChanged))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnSave.Click += (o, e) =>
            {
                if (_editModel.SaveOrUpdate())
                {
                    txtRepairs.ReadOnly = true;
                    pickbillDate.Enabled = false;
                    cbovehicles.Enabled = false;
                    btnSave.Enabled = false;
                    gridLines.ReadOnly = true;
                    System.Media.SystemSounds.Beep.Play();
                }
                else
                {
                    System.Media.SystemSounds.Hand.Play();
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                 if (_editModel.Close())
                 {
                    Close();
                 }
                 else
                 {
                    System.Media.SystemSounds.Hand.Play();
                 }
            };
            // ...
            FormClosing += (o, e) =>
            {
                e.Cancel = !_editModel.Close();
                if (e.Cancel)
                    System.Media.SystemSounds.Hand.Play();
            };
            // ...
            errorProvider1.DataSource = _editModel;
        }
    }
}