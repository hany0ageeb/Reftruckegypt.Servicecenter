using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reftruckegypt.Servicecenter.Views.Abstractions
{
    public abstract class MainViewBase : Form
    {
        public abstract bool IsExportEnabled { get; set; }
        public abstract void SetExportDisplayName(string displayName = "Export");
        public abstract void AddExportAction(EventHandler action);
        public abstract void RemoveExportAction(EventHandler action);
       
    }
}
