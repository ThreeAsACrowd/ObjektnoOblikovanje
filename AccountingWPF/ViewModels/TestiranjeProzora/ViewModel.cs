using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountingWPF.ViewModels
{
    public class ViewModel
    {
        private readonly IWindowFactory windowFactory;
        private ICommand openNewWindowICommand;

        public ViewModel(IWindowFactory windowFactory)
        {
            this.windowFactory = windowFactory;
            openNewWindowICommand = null;
        }

        public void DoOpenNewWindow()
        {
            windowFactory.CreateNewWindow();
        }

        public ICommand OpenNewWindow { get { return openNewWindowICommand; } }
    }

   

}
