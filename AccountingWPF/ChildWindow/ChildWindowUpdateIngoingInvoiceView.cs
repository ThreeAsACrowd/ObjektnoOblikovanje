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
    public class ChildWindowUpdateIngoingInvoiceView
    {
        public event Action<IngoingInvoice> Closed;
        
        public ChildWindowUpdateIngoingInvoiceView()
        {

        }

        public void Show(int selected_id)
        {
            UpdateIngoingInvoiceViewModel vm = new UpdateIngoingInvoiceViewModel(selected_id);
            vm.Closed += ChildWindow_Closed;
            ChildWindowAddManager.Instance.ShowChildWindow(new UpdateIngoingInvoiceView() { DataContext = vm });
        }

        void ChildWindow_Closed(IngoingInvoice invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowAddManager.Instance.CloseChildWindow();
        }
    }
}
