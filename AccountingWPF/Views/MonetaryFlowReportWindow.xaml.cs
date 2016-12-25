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
using Microsoft.Win32;

namespace AccountingWPF.Views
{
    /// <summary>
    /// Interaction logic for IncomesExpensesReport.xaml
    /// </summary>
    public partial class MonetaryFlowReportWindow : Window
    {
		public MonetaryFlowReportViewModel monetaryFlowReportVM;
		private SaveFileDialog saveFileDialog;

        public MonetaryFlowReportWindow()
        {
            InitializeComponent();

			monetaryFlowReportVM = new MonetaryFlowReportViewModel();
			this.DataContext = monetaryFlowReportVM;
			
			saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".html";
			saveFileDialog.Filter = "HyperText Markup File (*.html)|*.html";

        }

		private void btn_create_Click(object sender, RoutedEventArgs e)
		{
			bool? dialogResult = saveFileDialog.ShowDialog();
			if (dialogResult.HasValue && dialogResult.Value == true)
			{
				monetaryFlowReportVM.CreateReportByYear(saveFileDialog.FileName);

				lbl_status.Content = "Report created at: " + saveFileDialog.FileName.ToString();
			}
			else
			{
				lbl_status.Content = "Report creation aborted!";
			}

		}
    }
}
