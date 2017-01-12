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
    public class ChildWindowUpdateExpenditureView
    {
        public event Action<Expenditure> Closed;

        public ChildWindowUpdateExpenditureView()
        {

        }

        public void Show(Expenditure selected)
        {
            UpdateExpenditureViewModel vm = new UpdateExpenditureViewModel(selected);
            vm.Closed += ChildWindow_Closed;
            ChildWindowUpdateManager.Instance.ShowChildWindow(new UpdateExpenditureView() { DataContext = vm });
        }

        void ChildWindow_Closed(Expenditure invoice)
        {
            if (Closed != null)
                Closed(invoice);
            ChildWindowUpdateManager.Instance.CloseChildWindow();
        }
    }
}
