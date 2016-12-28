using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingWPF.Commands
{
    public class Command : ICommand
    {

        private Action action;
        private bool isEnabled;

        public Command(Action action, bool isEnabled)
        {
            this.action = action;
            this.isEnabled = isEnabled;

        }

        public event EventHandler CanExecuteChanged {
            add {
                CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return isEnabled;
        }



        public void Execute(object parameter)
        {
            action();
        }
    }
}
