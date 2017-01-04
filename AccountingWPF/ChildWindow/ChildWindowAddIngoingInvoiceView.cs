using AccountingWPF.ChildWindow.View;
using AccountingWPF.ChildWindow.ViewModel;
using AccountingWPF.Helpers;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.ChildWindow
{
    public class ChildWindowAddIngoingInvoiceView
    {
        public event Action<IngoingInvoice> Closed;
        public ChildWindowAddIngoingInvoiceView()
        {

        }

        public void Show()
        {
            AddIngoingInvoiceViewModel vm = new AddIngoingInvoiceViewModel();
            vm.Closed += ChildWindow_Closed;
            ChildWindowAddManager.Instance.ShowChildWindow(new AddIngoingInvoiceView() { DataContext = vm });
        }

        void ChildWindow_Closed(IngoingInvoice invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowAddManager.Instance.CloseChildWindow();
        }
    }
}
