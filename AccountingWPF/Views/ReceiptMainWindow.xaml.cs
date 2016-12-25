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
            this.DataContext = receiptsVM;
            this.dg_cbx_VAT.ItemsSource = receiptsVM.vats;
            DeinitializeDataGrid();
			
		}

        private void DeinitializeDataGrid() 
        {
            this.Delete_receipt_button.IsEnabled = false;
            this.Save_receipt_button.IsEnabled = false;
            this.dataGridReceipts.IsEnabled = false;
        }
        private void InitializeDataGrid()
        {
            this.dataGridReceipts.IsEnabled = true;
            this.Delete_receipt_button.IsEnabled = true;
            this.Save_receipt_button.IsEnabled = true;
        }

        private void Add_new_receipt_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("Add");
        }

        private void Delete_receipt_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Delete");
        }

        private void Edit_receipt_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("Edit");
        }

        private void Save_receipt_Button_Click(object sender, RoutedEventArgs e)
        {
            DeinitializeDataGrid();
            MessageBox.Show("Save");
        }
	}
}
