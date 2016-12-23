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
    /// Interaction logic for IncomesExpensesReport.xaml
    /// </summary>
    public partial class MonateryFlowReportWindow : Window
    {
		public MonateryFlowReportViewModel monateryFlowReportVM;

        public MonateryFlowReportWindow()
        {
            InitializeComponent();
			monateryFlowReportVM = new MonateryFlowReportViewModel();
			this.DataContext = monateryFlowReportVM;
        }
    }
}
