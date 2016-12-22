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

namespace AccountingWPF.Views
{
	/// <summary>
	/// Interaction logic for ReceiptMainWindow.xaml
	/// </summary>
	public partial class ReceiptMainWindow : Window
	{
        ReceiptViewModel receiptsVM { get; set; } 

		public ReceiptMainWindow()
		{
			InitializeComponent();

            receiptsVM = new ReceiptViewModel();
            this.dataGridReceipts.ItemsSource = receiptsVM.receipts;
		}

	}
}
