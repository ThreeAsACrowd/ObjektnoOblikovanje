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
    public class ChildWindowUpdateReceiptView
    {
        public event Action<Receipt> Closed;

        public ChildWindowUpdateReceiptView()
        {

        }

        public void Show(Receipt selected)
        {
            UpdateReceiptViewModel vm = new UpdateReceiptViewModel(selected);
            vm.Closed += ChildWindow_Closed;
            ChildWindowUpdateManager.Instance.ShowChildWindow(new UpdateReceiptView() { DataContext = vm });
        }

        void ChildWindow_Closed(Receipt invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowUpdateManager.Instance.CloseChildWindow();
        }
    }
}
