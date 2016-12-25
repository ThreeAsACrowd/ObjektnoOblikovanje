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

using AccountingWPF.Models;

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
            DeinitializeDataGrid();

        }

        private void DeinitializeDataGrid()
        {
            this.Delete_ingoing_invoice_button.IsEnabled = false;
            this.Save_ingoing_invoice_button.IsEnabled = false;
            this.dataGridIngoingInvoices.IsEnabled = false;
        }
        private void InitializeDataGrid()
        {
            this.dataGridIngoingInvoices.IsEnabled = true;
            this.Delete_ingoing_invoice_button.IsEnabled = true;
            this.Save_ingoing_invoice_button.IsEnabled = true;
        }

        private void Add_new_ingoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("Add");
        }

        private void Delete_ingoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("delete");
        }

        private void Edit_ingoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("edit");
        }

        private void Save_ingoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            DeinitializeDataGrid();
            MessageBox.Show("save");
        }
	}
}
