using AccountingWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingWPF.Commands
{
    internal class UpdateIngoingInvoiceCommand: ICommand
    {
        private IngoingInvoiceViewModel ingoingInvoiceVM {get; set;}

        public UpdateIngoingInvoiceCommand(IngoingInvoiceViewModel ingoingInvoiceVM)
        {
            this.ingoingInvoiceVM = ingoingInvoiceVM;

        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return ingoingInvoiceVM.CanExecuteUpdate;
        }



        public void Execute(object parameter)
        {
            ingoingInvoiceVM.UpdateIngoingInvoice();
        }

    }
}
