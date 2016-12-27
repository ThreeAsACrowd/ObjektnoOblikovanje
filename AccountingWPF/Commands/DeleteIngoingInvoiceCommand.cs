using AccountingWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingWPF.Commands
{
    internal class DeleteIngoingInvoiceCommand: ICommand
    {
        private IngoingInvoiceViewModel ingoingInvoiceVM {get; set;}

        public DeleteIngoingInvoiceCommand(IngoingInvoiceViewModel ingoingInvoiceVM)
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
            return ingoingInvoiceVM.CanExecuteDelete;
        }



        public void Execute(object parameter)
        {
            ingoingInvoiceVM.DeleteIngoingInvoice();
        }
    }
}
