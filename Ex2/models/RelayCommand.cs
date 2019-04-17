using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ex2.models
{
    class RelayCommand : ICommand
    {
        private Action action;
        public RelayCommand(Action a)
        {
            action = a;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action();
            ((Window)parameter).Close();
        }
    }
}
