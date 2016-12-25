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
	/// Interaction logic for OutgoingInvoiceMainWindow.xaml
	/// </summary>
	public partial class OutgoingInvoiceMainWindow : Window
	{
        OutgoingInvoiceViewModel outgoingInvoiceVM { get; set; }

		public OutgoingInvoiceMainWindow()
		{
			InitializeComponent();
            outgoingInvoiceVM = new OutgoingInvoiceViewModel();
            this.DataContext = outgoingInvoiceVM;
            DeinitializeDataGrid();

        }

        private void DeinitializeDataGrid()
        {
            this.Delete_outgoing_invoice_button.IsEnabled = false;
            this.Save_outgoing_invoice_button.IsEnabled = false;
            this.dataGridOutgoingInvoices.IsEnabled = false;
        }
        private void InitializeDataGrid()
        {
            this.dataGridOutgoingInvoices.IsEnabled = true;
            this.Delete_outgoing_invoice_button.IsEnabled = true;
            this.Save_outgoing_invoice_button.IsEnabled = true;
        }

        private void Add_new_outgoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("Add");
        }

        private void Delete_outgoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("delete");
        }

        private void Edit_outgoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeDataGrid();
            MessageBox.Show("edit");
        }

        private void Save_outgoing_invoice_Button_Click(object sender, RoutedEventArgs e)
        {
            DeinitializeDataGrid();
            MessageBox.Show("save");
        }
    }
}
