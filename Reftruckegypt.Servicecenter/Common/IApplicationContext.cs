using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.Common
{
    public interface IApplicationContext
    {
        DialogResult DisplayMessage(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon);
        void DisplayVehicleCategoryEditView(ViewModels.VehicleCategoryViewModels.VehicleCategoryEditViewModel _editModel);

        void DisplayVehicleCategoriesView();
    }
   
}
