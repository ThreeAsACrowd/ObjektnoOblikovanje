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
    public class ChildWindowAddOutgoingInvoiceView
    {
        public event Action<OutgoingInvoice> Closed;
        public ChildWindowAddOutgoingInvoiceView()
        {

        }

        public void Show()
        {
            AddOutgoingInvoiceViewModel vm = new AddOutgoingInvoiceViewModel();
            vm.Closed += ChildWindow_Closed;
            ChildWindowAddManager.Instance.ShowChildWindow(new AddOutgoingInvoiceView() { DataContext = vm });
        }

        void ChildWindow_Closed(OutgoingInvoice invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowAddManager.Instance.CloseChildWindow();
        }
    }
}
