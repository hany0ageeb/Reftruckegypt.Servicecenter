using Microsoft.Extensions.DependencyInjection;
using Reftruckegypt.Servicecenter.Views.Abstractions;
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
    public partial class MainView : MainViewBase
    {
        private NavigatorView _navigatorView;
        public override bool IsExportEnabled 
        {
            get => exportToolStripMenuItem.Enabled;
            set
            {
                exportToolStripMenuItem.Enabled = value;
            }
        }
        public override void SetExportDisplayName(string displayName = "Export")
        {
            exportToolStripMenuItem.Text = displayName;
        }
        public override void AddExportAction(EventHandler action)
        {
            
            exportToolStripMenuItem.Click += action;
        }
        public override void RemoveExportAction(EventHandler action)
        {
            
            exportToolStripMenuItem.Click -= action;
        }
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
