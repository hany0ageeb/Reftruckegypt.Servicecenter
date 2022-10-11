using Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.ImportMappingViews
{
    public partial class DriverMappingView : Form
    {
        private readonly List<string> _headers = new List<string>();
        private readonly string _filePath;
        public DriverMappingView(IEnumerable<string> headers, string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            if(headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }
            if(headers.Count() < 1)
                throw new ArgumentException(nameof(headers));
            _headers.AddRange(headers);
            InitializeComponent();
            Initialize();
        }
        public Mapper Mapper { get; private set; } = null;
        private void Initialize()
        {
            cboDriverName.DataSource = new List<string>(_headers);
            cboDriverName.SelectedIndex = 0;

            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboLicenseEndDate.DataSource = temp;
            cboLicenseEndDate.SelectedIndex = -1;
   
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboLicenseNumber.DataSource = temp;
            cboLicenseNumber.SelectedIndex = -1;

            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboTrafficDeparment.SelectedIndex = -1;
            cboTrafficDeparment.DataSource = temp;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Mapper = new Mapper(_filePath);
            Mapper.HasHeader = true;
            Mapper.SkipBlankRows = true;
            Mapper
                .Map<Models.Driver>(cboDriverName.SelectedItem.ToString(), nameof(Models.Driver.Name));
            if (cboLicenseEndDate.SelectedIndex > 0)
                Mapper.Map<Models.Driver>(cboLicenseEndDate.SelectedItem.ToString(), nameof(Models.Driver.LicenseEndDate));
            if (cboLicenseNumber.SelectedIndex > 0)
                Mapper.Map<Models.Driver>(cboLicenseNumber.SelectedItem.ToString(), nameof(Models.Driver.LicenseNumber));
            if (cboTrafficDeparment.SelectedIndex > 0)
                Mapper.Map<Models.Driver>(cboTrafficDeparment.SelectedItem.ToString(), nameof(Models.Driver.TrafficDepartmentName));
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Mapper = null;
            DialogResult = DialogResult.Cancel;
        }
    }
}
