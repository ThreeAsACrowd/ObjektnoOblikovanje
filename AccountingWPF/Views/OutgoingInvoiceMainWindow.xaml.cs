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
using System.Windows.Shapes;
using AccountingWPF.ViewModels;
using AccountingWPF.Helpers;

namespace AccountingWPF.Views
{
	/// <summary>
	/// Interaction logic for OutgoingInvoiceMainWindow.xaml
	/// </summary>
	public partial class OutgoingInvoiceMainWindow : Window
	{
        OutgoingInvoiceViewModel outgoingInvoiceVM { get; set; }

        public OutgoingInvoiceMainWindow()
        {
            InitializeComponent();

            childWindowAdd.DataContext = ChildWindowAddManager.Instance;
            childWindowUpdate.DataContext = ChildWindowUpdateManager.Instance;
            outgoingInvoiceVM = new OutgoingInvoiceViewModel();
            this.DataContext = outgoingInvoiceVM;
        }
    }
}
