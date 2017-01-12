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
    public class ChildWindowAddExpenditureView
    {
        public event Action<Expenditure> Closed;
        public ChildWindowAddExpenditureView()
        {

        }

        public void Show()
        {
            AddExpenditureViewModel vm = new AddExpenditureViewModel();
            vm.Closed += ChildWindow_Closed;
            ChildWindowAddManager.Instance.ShowChildWindow(new AddExpenditureView() { DataContext = vm });
        }

        void ChildWindow_Closed(Expenditure invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowAddManager.Instance.CloseChildWindow();
        }
    }
}
