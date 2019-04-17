using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ex2.viewModel
{
     class Setting_viewModel :BaseNotify
    {
        private ICommand okCommand;
        private ICommand cancelCommand;

        private models.ISettingsModel model;
        public Setting_viewModel(models.ISettingsModel model)
        {
            this.model = model;
        }
        public string ServerIP
        {
            get { return model.FlightServerIP; }
            set { model.FlightServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }
        public int ServerPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }
        public int CommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("CommandPort");
            }
        }

        public ICommand okCommandP
        {
            get
            {
                if(okCommand == null)
                {
                    okCommand = new  models.RelayCommand (() => {
                        model.SaveSettings();
                    }
                    );
                }
 
                return okCommand;
            }
        }
        public ICommand cancelCommandP
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new models.RelayCommand(() => {
                        model.ReloadSettings();
                    }
                    );
                }
                return cancelCommand;
            }
        }
    }
}
