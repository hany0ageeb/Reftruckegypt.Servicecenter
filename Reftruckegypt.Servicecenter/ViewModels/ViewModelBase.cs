using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(ViewModelBase viewModel, string propertyName = "")
        {
            PropertyChanged?.Invoke(viewModel, new PropertyChangedEventArgs(propertyName));
        }
    }
}
