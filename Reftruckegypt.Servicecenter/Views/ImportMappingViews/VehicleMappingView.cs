using Npoi.Mapper;
using Reftruckegypt.Servicecenter.ViewModels.VehicleViewModels;
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
        public Mapper Mapper { get; private set; } = null;
        private void Initialize()
        {
            cboInternalCode.DataSource = new List<string>(_headers);
            if(_headers.Count > 0)
                cboInternalCode.SelectedIndex = 0;
            // ...
            cboCategory.DataSource = new List<string>(_headers);
            if (_headers.Count > 1)
                cboCategory.SelectedIndex = 1;
            // ...
            cboModel.DataSource = new List<string>(_headers);
            if (_headers.Count > 2)
                cboModel.SelectedIndex = 2;
            // ...
            cboModelYear.DataSource = new List<string>(_headers);
            if (_headers.Count > 3)
                cboModelYear.SelectedIndex = 3;
            // ...
            cboFuelType.DataSource = new List<string>(_headers);
            if (_headers.Count > 4)
                cboFuelType.SelectedIndex = 4;
            // ...
            List<string> temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboDriver.DataSource = temp;
            cboDriver.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboCardName.DataSource = temp;
            cboCardName.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboCardNumber.DataSource = temp;
            cboCardNumber.SelectedIndex = -1;
            // ....
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboRegistration.DataSource = temp;
            cboRegistration.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboChasiss.DataSource = temp;
            cboChasiss.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboPlateNumber.DataSource = temp;
            cboPlateNumber.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboMotorNumber.DataSource = temp;
            cboMotorNumber.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboStartDate.DataSource = temp;
            cboStartDate.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboEndDate.DataSource = temp;
            cboEndDate.SelectedIndex = -1;
            // ...
            temp = new List<string>(_headers);
            temp.Insert(0, "");
            cboVehicleCode.DataSource = temp;
            cboVehicleCode.SelectedIndex = -1;
            // ...
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            Mapper = new Mapper(_fileName);
            Mapper
                .Map<VehicleViewModel>(cboCategory.SelectedItem.ToString(), nameof(VehicleViewModel.VehicleCategoryName))
                .Map<VehicleViewModel>(cboModel.SelectedItem.ToString(), nameof(VehicleViewModel.ModelName))
                .Map<VehicleViewModel>(cboModelYear.SelectedItem.ToString(), nameof(VehicleViewModel.ModelYear))
                .Map<VehicleViewModel>(cboFuelType.SelectedItem.ToString(), nameof(VehicleViewModel.FuelTypeName))
                .Map<VehicleViewModel>(cboInternalCode.SelectedItem.ToString(), nameof(VehicleViewModel.InternalCode));
            if (cboCardName.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboCardName.SelectedItem.ToString(), nameof(VehicleViewModel.FuelCardName));
            if (cboCardNumber.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboCardNumber.SelectedItem.ToString(), nameof(VehicleViewModel.FuelCardNumber));
            if (cboChasiss.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboChasiss.SelectedItem.ToString(), nameof(VehicleViewModel.ChassisNumber));
            if (cboDriver.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboDriver.SelectedItem.ToString(), nameof(VehicleViewModel.DriverName));
            if (cboEndDate.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboEndDate.SelectedItem.ToString(), nameof(VehicleViewModel.EndDate));
            if (cboStartDate.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboStartDate.SelectedItem.ToString(), nameof(VehicleViewModel.StartDate));
            if (cboRegistration.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboRegistration.SelectedItem.ToString(), nameof(VehicleViewModel.Registration));
            if (cboMotorNumber.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboMotorNumber.SelectedItem.ToString(), nameof(VehicleViewModel.MotorNumber));
            if (cboPlateNumber.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboPlateNumber.SelectedItem.ToString(), nameof(VehicleViewModel.PlateNumber));
            if (cboVehicleCode.SelectedIndex > 0)
                Mapper.Map<VehicleViewModel>(cboVehicleCode.SelectedItem.ToString(), nameof(VehicleViewModel.VehicleCode));
            Mapper.SkipBlankRows = true;
            Mapper.HasHeader = true;
            Mapper.FirstRowIndex = 0;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Mapper = null;
            DialogResult = DialogResult.Cancel;
            
        }
    }
}
