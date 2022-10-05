using Reftruckegypt.Servicecenter.ViewModels.PeriodViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.PeriodViews
{
    public partial class PeriodEditView : Form
    {
        private PeriodEditViewModel _periodEditModel;
        public PeriodEditView(PeriodEditViewModel periodEditViewModel)
        {
            _periodEditModel = periodEditViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            // ...
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add(new Binding(nameof(txtName.Text), _periodEditModel, nameof(_periodEditModel.Name))
            {

            });
            // ...
            pickfromDate.DataBindings.Clear();
            pickfromDate.DataBindings.Add(new Binding(nameof(pickfromDate.Value), _periodEditModel, nameof(_periodEditModel.FromDate))
            {

            });
            // ...
            picktoDate.DataBindings.Clear();
            picktoDate.DataBindings.Add(new Binding(nameof(picktoDate.Value), _periodEditModel, nameof(_periodEditModel.ToDate))
            {

            });
            // ...
            cboStates.DataBindings.Clear();
            cboStates.DataSource = _periodEditModel.PeriodStates;
            cboStates.DataBindings.Add(new Binding(nameof(cboStates.SelectedItem), _periodEditModel, nameof(_periodEditModel.State))
            {

            });
            // ...
            btnSave.DataBindings.Clear();
            btnSave.DataBindings.Add(new Binding(nameof(btnSave.Enabled), _periodEditModel, nameof(_periodEditModel.HasChanged))
            {
                DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged
            });
            btnSave.Click += (o, e) =>
            {
                if (_periodEditModel.SaveOrUpdate())
                {
                    Close();
                }
            };
            // ...
            btnClose.Click += (o, e) =>
            {
                if (_periodEditModel.Close())
                {
                    this.Close();
                }
            };
            // ...
            FormClosing += (o, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.MdiFormClosing)
                {
                    e.Cancel = !_periodEditModel.Close();
                }
            };
            // ...
            errorProvider1.DataSource = _periodEditModel;
        }
    }
}
