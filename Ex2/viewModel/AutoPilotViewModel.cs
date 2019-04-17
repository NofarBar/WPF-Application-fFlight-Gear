using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Ex2.viewModel
{
    public class AutoPilotViewModel :BaseNotify
    {
        private AutoPilotModel apModel;
        private string script;
        private ICommand okCommand;
        private ICommand cancelCommand;
        public AutoPilotViewModel()
        {
            apModel = new AutoPilotModel();
            
        }
        public string scriptProperty
        {
            set
            {
                script = value;
                if ((script == null) || (script == ""))
                {
                    brush = new SolidColorBrush(Colors.White);
                }
                else
                {
                    brush = new SolidColorBrush(Colors.LightPink);
                }
                Console.WriteLine(script);
            }
            get
            {
                return script;
            }
        }
        public Brush brush
        {
            set
            {
                apModel.color = value;
                NotifyPropertyChanged("brush");
            }
            get
            {
                return apModel.color;
            }
        }
        public ICommand okCommandP
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new CommandHandler(() =>
                    {
                        if((script!=null) && (script != ""))
                        {
                            string[] setCommands = script.Split('\n');
                            apModel.sendCommand(setCommands);
                        }     
                    }
                    );
                    okCommand.Execute(this);
                }
                script = "";
                return okCommand;
            }
        }

        public ICommand cancelCommandP
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new CommandHandler(() =>
                    {
                        scriptProperty = "";
                        NotifyPropertyChanged("scriptProperty");
                    }
                    );
                }
                return cancelCommand;
            }
        }

    }
}
