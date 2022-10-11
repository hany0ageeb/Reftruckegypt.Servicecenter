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
    public partial class ImportErrorsView : Form
    {
        public ImportErrorsView(string errorMessage)
        {
            InitializeComponent();
            txtErrors.Text = errorMessage;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
