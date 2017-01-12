using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountingWPF.ChildWindow.View
{
    /// <summary>
    /// Interaction logic for AddIngoingInvoiceView.xaml
    /// </summary>
    public partial class AddIngoingInvoiceView : UserControl
    {
        public AddIngoingInvoiceView()
        {
            InitializeComponent();
        }

        public static int cnt = 0;

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {

            if (e.Action == ValidationErrorEventAction.Added)
            {
                buttonOk.IsEnabled = false;
                cnt++;

            }
            if (e.Action == ValidationErrorEventAction.Removed)
            {
                cnt--;
                if (cnt == 0)
                {
                    buttonOk.IsEnabled = true;
                }
            }
        } 
    }
}
