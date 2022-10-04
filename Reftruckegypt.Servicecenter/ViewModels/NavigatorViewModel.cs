﻿using Reftruckegypt.Servicecenter.Common;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reftruckegypt.Servicecenter.ViewModels
{
    public class NavigatorViewModel : ViewModelBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationContext _applicationContext;
        private bool _isDisposed = false;
        public NavigatorViewModel(IUnitOfWork unitOfWork, IApplicationContext applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
            var commands = _unitOfWork.UserCommandRepository.Find().ToList();
            UserCommands.Clear();
            foreach(var command in commands)
            {
                switch (command.Name)
                {
                    case "VehicleCategory":
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleCategoriesView();
                        };
                        break;
                    case "VehicleModel":
                        command.Execute = () =>
                        {
                            _applicationContext.DisplayVehicleModelsView();
                        };
                        break;
                }
                UserCommands.Add(command);
            }
        }
        public bool Close()
        {
            var result = _applicationContext.DisplayMessage("Confirm", "Are you sure you want to exits?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                default:
                    return false;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _unitOfWork.Dispose();
                _isDisposed = true;
            }
        }

        public BindingList<Models.UserCommand> UserCommands { get; private set; } = new BindingList<Models.UserCommand>();

    }
    
}
