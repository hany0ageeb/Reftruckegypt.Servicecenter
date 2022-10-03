using Microsoft.Extensions.DependencyInjection;
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
    public partial class MainView : Form
    {
        private NavigatorView _navigatorView;
        public MainView()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            Load += (o, e) =>
            {
                _navigatorView = Program.ServiceProvider.GetRequiredService<NavigatorView>();
                _navigatorView.MdiParent = this;
                _navigatorView.Show();
            };
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _navigatorView.Close();
        }
    }
}
