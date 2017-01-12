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
    public class ChildWindowAddReceiptView
    {
         public event Action<Receipt> Closed;
        public ChildWindowAddReceiptView()
        {

        }

        public void Show()
        {
            AddReceiptViewModel vm = new AddReceiptViewModel();
            vm.Closed += ChildWindow_Closed;
            ChildWindowAddManager.Instance.ShowChildWindow(new AddReceiptView() { DataContext = vm });
        }

        void ChildWindow_Closed(Receipt invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowAddManager.Instance.CloseChildWindow();
        }
    }
}
