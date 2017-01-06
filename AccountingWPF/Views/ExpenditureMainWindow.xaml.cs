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
	/// Interaction logic for ExpenditureMainWindow.xaml
	/// </summary>
	public partial class ExpenditureMainWindow : Window
	{
        ExpenditureViewModel expenditureVM { get; set; } 

		public ExpenditureMainWindow()
		{
			InitializeComponent();


            childWindowAdd.DataContext = ChildWindowAddManager.Instance;
            childWindowUpdate.DataContext = ChildWindowUpdateManager.Instance;

            expenditureVM = new ExpenditureViewModel();
			this.DataContext = expenditureVM;
			this.dg_cbx_VAT.ItemsSource = expenditureVM.vats;

        }
	}
}
