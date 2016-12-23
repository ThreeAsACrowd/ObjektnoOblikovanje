using AccountingWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingWPF.ViewModels
{
	public class HomeViewModel
	{
		public Window ChildWindow { get; set; }

		public HomeViewModel()
		{

		}

		public void showReceiptMainWindow()
		{
			ChildWindow = new ReceiptMainWindow();
			ChildWindow.ShowDialog();
		}

		public void showExpenditureMainWindow()
		{
			ChildWindow = new ExpenditureMainWindow();
			ChildWindow.ShowDialog();
		}

		public void showIngoingInvoiceMainWindow()
		{
			ChildWindow = new IngoingInvoiceMainWindow();
			ChildWindow.ShowDialog();
		}

		public void showOutgoingInvoiceMainWindow()
		{
			ChildWindow = new OutgoingInvoiceMainWindow();
			ChildWindow.ShowDialog();
		}

		public void generateYearlyReport()
		{
            ChildWindow = new AnnualReportWindow();
            ChildWindow.ShowDialog();
		}

		public void generateMonetaryFlowReport()
		{
            ChildWindow = new MonetaryFlowReportWindow();
            ChildWindow.ShowDialog();
		}

        internal void showUserAccountMainWindow()
        {
            ChildWindow = new UserAccountWindow();
            ChildWindow.ShowDialog();
        }
    }
}
