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
using DataRepository.Models;
using AccountingWPF.ViewModels;

namespace AccountingWPF.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public LoginViewModel LoginVM { get; set; }

        public Login()
        {
            InitializeComponent();

            LoginVM = new LoginViewModel();
            this.DataContext = LoginVM.LoginBM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //.Hide();
            bool isLoginValid=LoginVM.Login();
            //LoginVM.TestLogin

			//ovo treba ići u VM
            if (isLoginValid)
            {
                this.Hide();
                LoginVM.OpenHome();
                this.Show();
            }
           

        }
    }
}
