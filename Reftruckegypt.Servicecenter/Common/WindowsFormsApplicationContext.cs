using System.Windows.Forms;
using System;
using Reftruckegypt.Servicecenter.ViewModels.VehicleCategoryViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Reftruckegypt.Servicecenter.Views.VehicleCategoryViews;
using Reftruckegypt.Servicecenter.Views;
using System.Collections.Generic;

namespace Reftruckegypt.Servicecenter.Common
{
    public enum MessageBoxButtons
    {
        OK = 0,
        YesNo = 4,
        YesNoCancel = 8,
    }
    public enum MessageBoxIcon
    {
        Error = 16,
        Question = 32
    }
    public enum DialogResult
    {

        None = 0,
        OK = 1,
        Cancel = 2,
        Abort = 3,
        Retry = 4,
        Ignore = 5,
        Yes = 6,
        No = 7
    }
    public class WindowsFormsApplicationContext : IApplicationContext
    {
        private readonly Form _mdiParent = null;
        private readonly Dictionary<Form, IServiceScope> _scopes = new Dictionary<Form, IServiceScope>();
        public WindowsFormsApplicationContext(Form mdiParent)
        {
            _mdiParent = mdiParent;
        }
        public void DisplayVehicleCategoriesView()
        {
            var scope = Program.ServiceProvider.CreateScope();
            VehicleCategoriesView vehicleCategoriesView = scope.ServiceProvider.GetRequiredService<VehicleCategoriesView>();
            _scopes[vehicleCategoriesView] = scope;
            vehicleCategoriesView.MdiParent = _mdiParent;
            vehicleCategoriesView.FormClosed += (o, e) =>
            {
                FormClosed(o as Form);
            };
            vehicleCategoriesView.Show();
        }
        private void FormClosed(Form sender)
        {
            if (sender != null && _scopes.ContainsKey(sender))
            {
                _scopes[sender].Dispose();
                _scopes.Remove(sender);
            }
        }
        public void DisplayVehicleCategoryEditView(VehicleCategoryEditViewModel _editModel)
        {
            VehicleCategoryEditView vehicleCategoryEditView = new VehicleCategoryEditView(_editModel)
            {
                //MdiParent = _mdiParent
            };
            vehicleCategoryEditView.ShowDialog(_mdiParent);
        }
        public DialogResult DisplayMessage(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.DialogResult.None;
            switch (buttons)
            {
                case MessageBoxButtons.YesNo:
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        default:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information);
                            break;
                    }
                    break;
                case MessageBoxButtons.YesNoCancel:
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        default:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.YesNoCancel, System.Windows.Forms.MessageBoxIcon.Information);
                            break;

                    }
                    break;
                default:
                    switch (icon)
                    {
                        case MessageBoxIcon.Question:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Question);
                            break;
                        default:
                            result = MessageBox.Show(message, title, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            break;
                    }
                    break;
            }
            switch (result)
            {
                case System.Windows.Forms.DialogResult.None:
                    return DialogResult.None;
                case System.Windows.Forms.DialogResult.Yes:
                    return DialogResult.Yes;
                case System.Windows.Forms.DialogResult.No:
                    return DialogResult.No;
                case System.Windows.Forms.DialogResult.Cancel:
                    return DialogResult.Cancel;
                default:
                    return DialogResult.None;
            }
        }
    }
}
