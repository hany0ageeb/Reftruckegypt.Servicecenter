using Reftruckegypt.Servicecenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views
{
    public partial class NavigatorView : Form
    {
        private readonly ViewModels.NavigatorViewModel _navigatorViewModel;
        public NavigatorView(ViewModels.NavigatorViewModel navigatorViewModel)
        {
            _navigatorViewModel = navigatorViewModel;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            lstUserCommands.DataSource = _navigatorViewModel.UserCommands;
            lstUserCommands.DisplayMember = nameof(UserCommand.DisplayName);
            lstUserCommands.ValueMember = nameof(UserCommand.Self);
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            UserCommand userCommand = lstUserCommands.SelectedItem as UserCommand;
            if(userCommand != null)
            {
                userCommand.Execute();
            }
        }

        private void NavigatorView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_navigatorViewModel.Close();
        }

        private void NavigatorView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _navigatorViewModel.Dispose();
            Application.Exit();
        }
    }
}
