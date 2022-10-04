﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reftruckegypt.Servicecenter.Models;
using Reftruckegypt.Servicecenter.ViewModels.ExternalRepairBillViewModels;

namespace Reftruckegypt.Servicecenter.Views.ExternalRepairBillViews
{
    public partial class ExternalRepairBillsView : Form
    {
        private ExternalRepairBillSearchViewModel _searchModel;
        public ExternalRepairBillsView(ExternalRepairBillSearchViewModel searchModel)
        {
            _searchModel = searchModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtbillNumberFrom.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberFrom.Text))
                    return;
                if(!long.TryParse(txtbillNumberFrom.Text, out long valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillNumberFrom, "Invalid Bill Number!");
                }
            };
            txtbillNumberFrom.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberFrom.Text))
                    _searchModel.NumberFrom = null;
                else
                    _searchModel.NumberFrom = long.Parse(txtbillNumberFrom.Text);
                errorProvider1.SetError(txtbillNumberFrom, "");
            };
            // ...
            txtbillNumberTo.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberTo.Text))
                    return;
                if (!long.TryParse(txtbillNumberTo.Text, out long valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillNumberTo, "Invalid Bill Number!");
                }
            };
            txtbillNumberTo.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillNumberTo.Text))
                    _searchModel.NumberTo = null;
                else
                    _searchModel.NumberTo = long.Parse(txtbillNumberTo.Text);
                errorProvider1.SetError(txtbillNumberTo, "");
            };
            // ...
            txtbillAmountFrom.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountFrom.Text))
                    return;
                if (!decimal.TryParse(txtbillAmountFrom.Text, out decimal valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillAmountFrom, "Invalid Amount!");
                }
            };
            txtbillAmountFrom.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountFrom.Text))
                    _searchModel.FromAmount = null;
                else
                    _searchModel.FromAmount = decimal.Parse(txtbillAmountFrom.Text);
                errorProvider1.SetError(txtbillAmountFrom, "");
            };
            // ...
            txtbillAmountTo.Validating += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountTo.Text))
                    return;
                if (!decimal.TryParse(txtbillAmountTo.Text, out decimal valLong))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbillAmountTo, "Invalid Amount!");
                }
            };
            txtbillAmountTo.Validated += (o, e) =>
            {
                if (string.IsNullOrEmpty(txtbillAmountTo.Text))
                    _searchModel.ToAmount = null;
                else
                    _searchModel.ToAmount = decimal.Parse(txtbillAmountTo.Text);
                errorProvider1.SetError(txtbillAmountTo, "");
            };
            // ...
            pickbillDateFrom.ValueChanged += (o, e) =>
            {
                if (pickbillDateFrom.Checked)
                {
                    _searchModel.FromDate = pickbillDateFrom.Value;
                }
                else
                {
                    _searchModel.FromDate = null;
                }
            };
            // ...
            pickbillDateTo.ValueChanged += (o, e) =>
            {
                if (pickbillDateTo.Checked)
                {
                    _searchModel.ToDate = pickbillDateTo.Value;
                }
                else
                {
                    _searchModel.ToDate = null;
                }
            };
            // ...
            cboshops.DataBindings.Clear();
            cboshops.DataSource = _searchModel.ExternalAutoRepairShops;
            cboshops.DisplayMember = nameof(ExternalAutoRepairShop.Name);
            cboshops.ValueMember = nameof(ExternalAutoRepairShop.Self);
            cboshops.DataBindings.Add(new Binding(nameof(cboshops.SelectedItem),_searchModel, nameof(_searchModel.ExternalAutoRepairShop))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            cbovehicles.DataBindings.Clear();
            cbovehicles.DataSource = _searchModel.Vehicles;
            cbovehicles.DisplayMember = nameof(Vehicle.InternalCode);
            cbovehicles.ValueMember = nameof(Vehicle.Self);
            cbovehicles.DataBindings.Add(new Binding(nameof(cbovehicles.SelectedItem), _searchModel, nameof(_searchModel.Vehicle))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            // ...
            gridbills.AutoGenerateColumns = false;
            gridbills.AllowUserToAddRows = false;
            gridbills.AllowUserToDeleteRows = false;
            gridbills.ReadOnly = true;
            gridbills.MultiSelect = false;
            gridbills.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridbills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            gridbills.Columns.Clear();
            gridbills.Columns.AddRange(
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.Number),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.Number),
                    HeaderText = "Number",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.BillDate),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.BillDate),
                    HeaderText = "Date",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.SupplierBillNumber),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.SupplierBillNumber),
                    HeaderText = "Supplier Bill Num",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.ExternalAutoRepairShopName),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.ExternalAutoRepairShopName),
                    HeaderText = "Ext Repair Shop",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.VehicleInternalCode),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.VehicleInternalCode),
                    HeaderText = "Vehicle",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.Repairs),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.Repairs),
                    HeaderText = "Repairs",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.TotalAmount),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.TotalAmount),
                    HeaderText = "Amount(EGP)",
                    ReadOnly = true
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = nameof(ExternalRepairBillVieModel.State),
                    DataPropertyName = nameof(ExternalRepairBillVieModel.State),
                    HeaderText = "State",
                    ReadOnly = true
                });
            gridbills.DataSource = _searchModel.ExternalRepairBillVieModels;
            // ...
            btnSearch.Click += (o, e) =>
            {
                _searchModel.Search();
            };
            // ...
            btnCreate.Click += (o, e) =>
            {
                _searchModel.Create();
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
