using AccountingWPF.ChildWindow.ViewModel;
using AccountingWPF.ChildWindow.View;
using AccountingWPF.Helpers;
using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.ChildWindow
{
    public class ChildWindowUpdateOutgoingInvoiceView
    {
        public event Action<OutgoingInvoice> Closed;

        public ChildWindowUpdateOutgoingInvoiceView()
        {

        }

        public void Show(OutgoingInvoice selected)
        {
            UpdateOutgoingInvoiceViewModel vm = new UpdateOutgoingInvoiceViewModel(selected);
            vm.Closed += ChildWindow_Closed;
            ChildWindowUpdateManager.Instance.ShowChildWindow(new UpdateOutgoingInvoiceView() { DataContext = vm });
        }

        void ChildWindow_Closed(OutgoingInvoice invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowUpdateManager.Instance.CloseChildWindow();
        }
    }
}
