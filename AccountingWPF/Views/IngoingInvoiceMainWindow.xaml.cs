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

using DataRepository.Models;

namespace AccountingWPF.Views
{
	/// <summary>
	/// Interaction logic for IngoingInvoiceMainWindow.xaml
	/// </summary>
	public partial class IngoingInvoiceMainWindow : Window
	{
        IngoingInvoiceViewModel ingoingInvoiceVM { get; set; }

		public IngoingInvoiceMainWindow()
		{
			InitializeComponent();

            ingoingInvoiceVM = new IngoingInvoiceViewModel();
            this.DataContext = ingoingInvoiceVM;

        }
	}
}
