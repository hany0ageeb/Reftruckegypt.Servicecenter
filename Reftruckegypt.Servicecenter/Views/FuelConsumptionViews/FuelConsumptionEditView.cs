using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.ViewModels.FuelConsumptionViewModels;

namespace Reftruckegypt.Servicecenter.Views.FuelConsumptionViews
{
    public partial class FuelConsumptionEditView : Form
    {
        private FuelConsumptionEditViewModel _editModel;
        public FuelConsumptionEditView(FuelConsumptionEditViewModel editModel)
        {
            _editModel = editModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // .. 
            pickconsumptionDate.DataBindings.Clear();
            pickconsumptionDate.DataBindings.Add(new Binding(nameof(pickconsumptionDate.Value),_editModel,nameof(_editModel.ConsumptionDate))
            {

            });
            // ...
            gridConsumptions.AllowUserToAddRows = true;
            gridConsumptions.AllowUserToDeleteRows = true;
            gridConsumptions.AutoGenerateColumns = false;
            gridConsumptions.MultiSelect = false;
            gridConsumptions.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridConsumptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridConsumptions.ReadOnly = false;

            gridConsumptions.Columns.Clear();
            gridConsumptions.Columns.AddRange(
                new DataGridViewComboBoxColumn()
                {
                    Name = nameof(FuelConsumptionLineEditViewModel.Vehicle),
                    DataPropertyName = nameof(FuelConsumptionLineEditViewModel.Vehicle),
                    DataSource = _editModel.Vehicles,
                    DisplayMember = nameof(Models.Vehicle.InternalCode),
                    ValueMember = nameof(Models.Vehicle.Self),
                    HeaderText = "Vehicle"
                },
                new DataGridViewComboBoxColumn()
                {
                    Name = nameof(FuelConsumptionLineEditViewModel.FuelCard),
                    DataPropertyName = nameof(FuelConsumptionLineEditViewModel.FuelCard),
                    DataSource = _editModel.FuelCards,
                    DisplayMember = nameof(Models.FuelCard.Number),
                    ValueMember = nameof(Models.FuelCard.Self),
                    HeaderText = "Fuel Card"
                },
                new DataGridViewComboBoxColumn()
                {
                    Name = nameof(FuelConsumptionLineEditViewModel.FuelType),
                    DataPropertyName = nameof(FuelConsumptionLineEditViewModel.FuelType),
                    DataSource = _editModel.FuelTypes,
                    DisplayMember = nameof(Models.FuelType.Name),
                    ValueMember = nameof(Models.FuelType.Self),
                    HeaderText = "Fuel Card"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionLineEditViewModel.TotalConsumedQuantityInLiteres),
                    DataPropertyName = nameof(FuelConsumptionLineEditViewModel.TotalConsumedQuantityInLiteres),
                    HeaderText = "Consumed Quantity(LT)"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionLineEditViewModel.TotalAmountInEGP),
                    DataPropertyName = nameof(FuelConsumptionLineEditViewModel.TotalAmountInEGP),
                    HeaderText = "Amount (EGP)"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(FuelConsumptionLineEditViewModel.Notes),
                    DataPropertyName = nameof(FuelConsumptionLineEditViewModel.Notes),
                    HeaderText = "Notes"
                }
            );
            gridConsumptions.DataSource = _editModel.Lines;
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
                    Close();
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                if (_editModel.Close())
                    Close();
            };
            // ...
            errorProvider1.DataSource = _editModel;
            // ...
        }
    }
}
