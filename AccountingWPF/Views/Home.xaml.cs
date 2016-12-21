using AccountingWPF.ViewModels;
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
<<<<<<< HEAD
using AccountingWPF.BaseLib;

namespace AccountingWPF.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public HomeViewModel HomeVM { get; set; }

        public Home()
        {
            InitializeComponent();
            HomeVM = new HomeViewModel();
        }

        private void mi_receipts_Click(object sender, RoutedEventArgs e)
        {
            HomeVM.showReceiptMainWindow();
        }

        private void mi_expenditures_Click(object sender, RoutedEventArgs e)
        {
            HomeVM.showExpenditureMainWindow();
        }

        private void mi_outgoingInvoices_Click(object sender, RoutedEventArgs e)
        {
            HomeVM.showOutgoingInvoiceMainWindow();
        }

        private void mi_ingoingInvoices_Click(object sender, RoutedEventArgs e)
        {
            HomeVM.showIngoingInvoiceMainWindow();
        }

        private void mi_monetaryFlowReport_Click(object sender, RoutedEventArgs e)
        {
            HomeVM.generateMonetaryFlowReport();
        }

        private void mi_yearlyReport_Click(object sender, RoutedEventArgs e)
        {
            HomeVM.generateYearlyReport();
        }

        private void mi_userAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mi_logout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.LogOut();
            this.Close();
        }
    }
=======

namespace AccountingWPF.Views
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : Window
	{
		public HomeViewModel HomeVM { get; set; }

		public Home()
		{
			InitializeComponent();
			HomeVM = new HomeViewModel();
		}

		private void mi_receipts_Click(object sender, RoutedEventArgs e)
		{
			HomeVM.showReceiptMainWindow();
		}

		private void mi_expenditures_Click(object sender, RoutedEventArgs e)
		{
			HomeVM.showExpenditureMainWindow();
		}

		private void mi_outgoingInvoices_Click(object sender, RoutedEventArgs e)
		{
			HomeVM.showOutgoingInvoiceMainWindow();
		}

		private void mi_ingoingInvoices_Click(object sender, RoutedEventArgs e)
		{
			HomeVM.showIngoingInvoiceMainWindow();
		}

		private void mi_monetaryFlowReport_Click(object sender, RoutedEventArgs e)
		{
			HomeVM.generateMonetaryFlowReport();
		}

		private void mi_yearlyReport_Click(object sender, RoutedEventArgs e)
		{
			HomeVM.generateYearlyReport();
		}

		private void mi_userAccount_Click(object sender, RoutedEventArgs e)
		{

		}

		private void mi_logout_Click(object sender, RoutedEventArgs e)
		{

		}
	}
>>>>>>> b711e53a2be0593f9aa0a5735b81c4ab295b9728
}
