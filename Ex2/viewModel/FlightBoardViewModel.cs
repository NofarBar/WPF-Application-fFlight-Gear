using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ex2.viewModel
{
    public class FlightBoardViewModel : BaseNotify
    {
        private ICommand connectB;
        private ICommand settingB;
        private ICommand disConnectB;
        private models.FlightBoardModel flightModle;
        public FlightBoardViewModel()
        {
            this.flightModle = new models.FlightBoardModel();

        }
        public ICommand ConnectP
        {
            get
            {
                if (connectB == null)
                {
                    connectB = new CommandHandler(() =>
                    {
                        Thread connectThread = new Thread(new ThreadStart(() =>
                        {
                            flightModle.connect();
                        }));
                        connectThread.Start();
                    });
                }
                Thread UpdatePoint = new Thread(new ThreadStart(() =>
                {
                    while (!flightModle.serverP.isConnection())
                    {

                    }
                    while (flightModle.serverP.isConnection())
                    {
                        if (flightModle.NotifyP)
                        {
                            NotifyPropertyChanged("Lon");
                            NotifyPropertyChanged("Lat");
                        }
                    }

                }));
                UpdatePoint.Start();
                return connectB;
            }
        }

        public double Lon
        {
            get { return flightModle.longitude; }
        }

        public double Lat
        {
            get { return flightModle.latitude; }
        }
        public ICommand SettingP
        {
            get
            {
                if (settingB == null)
                {
                    settingB = new CommandHandler(() =>
                    {
                        SettingView setting = new SettingView();
                        var host = new Window();
                        host.Content = setting;
                        host.Show();
                    });
                }
                return settingB;
            }
        }
        public ICommand DisConnectP
        {
            get
            {
                if (disConnectB == null)
                {
                    disConnectB = new models.RelayCommand(() =>
                    {
                        flightModle.serverP.disconnect();
                        flightModle.clientP.disconnect();
                    });
                }
                return disConnectB;
            }
        }
    }
}
