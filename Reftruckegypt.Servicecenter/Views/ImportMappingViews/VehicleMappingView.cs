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
    public partial class VehicleMappingView : Form
    {
        private readonly List<string> _headers = new List<string>();
        private readonly string _fileName;
        public VehicleMappingView(List<string> headers, string fileName)
        {
            _headers.AddRange(headers);
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            cboInternalCode.DataSource = new List<string>(_headers);
            // ...
            cboCategory.DataSource = new List<string>(_headers);
            // ...
            cboModel.DataSource = new List<string>(_headers);
            // ...
            cboModelYear.DataSource = new List<string>(_headers);
            // ...
            cboFuelType.DataSource = new List<string>(_headers);
            // ...
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboDriver.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboCardName.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboCardNumber.DataSource = temp;
            // ....
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboChasiss.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboPlateNumber.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboMotorNumber.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboStartDate.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboEndDate.DataSource = temp;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboVehicleCode.DataSource = temp;
            // ...
        }
    }
}
