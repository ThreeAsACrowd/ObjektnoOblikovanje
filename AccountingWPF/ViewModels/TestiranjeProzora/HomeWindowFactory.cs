using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingWPF.Views;

namespace AccountingWPF.ViewModels
{
    public class HomeWindowFactory : IWindowFactory
    {

        public void CreateNewWindow()
        {
            Window ChildWindow = new Home();
            ChildWindow.ShowDialog();
        }
    }
}
