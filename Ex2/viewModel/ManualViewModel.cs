using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2.viewModel
{
    public class ManualViewModel : BaseNotify
    {
        private models.ManualModel manualModel;
        public string aileronString = "set controls/flight/aileron ";
        public string elevatorString = "set controls/flight/elevator ";
        public string throttleString = "set controls/engines/engine/throttle ";
        public string rudderString = "set controls/flight/rudder ";
        public double throttleProperty;
        public double rudderProperty;
        public double aileronProperty;
        public double elevatorProperty;
        public ManualViewModel()
        {
            this.manualModel = new models.ManualModel();
        }

        public double Rudder
        {
            get
            {
                return rudderProperty;
            }
            set
            {
                this.rudderProperty = value;
                manualModel.sentToClient(rudderString + rudderProperty.ToString());
            }
        }

        public double Throttle
        {
            get
            {
                return throttleProperty;
            }
            set
            {

                this.throttleProperty = value;
                manualModel.sentToClient(throttleString + throttleProperty.ToString());
            }
        }

        public double Aileron
        {
            get
            {
                return aileronProperty;
            }
            set
            {
                this.aileronProperty = value;
                manualModel.sentToClient(aileronString + aileronProperty.ToString());
                NotifyPropertyChanged("Aileron");
            }
        }

        public double Elevator
        {
            get
            {
                return elevatorProperty;
            }
            set
            {
                this.elevatorProperty = value;
                manualModel.sentToClient(elevatorString + elevatorProperty.ToString());
                Console.WriteLine(Elevator);
                NotifyPropertyChanged("Elevator");
            }
        }
    }
}
 