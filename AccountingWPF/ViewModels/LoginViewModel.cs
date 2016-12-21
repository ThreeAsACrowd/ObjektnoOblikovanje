using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.BindingModels;
using System.Windows;
using AccountingWPF.Models;
using AccountingWPF.Respositories;
using AccountingWPF.Views;
using AccountingWPF.BaseLib;

namespace AccountingWPF.ViewModels
{
    public class LoginViewModel
    {
        public LoginBindingModel LoginBM { get; set; }

        public Window ChildWindow { get; set; }

        public LoginViewModel()
        {
            LoginBM = new LoginBindingModel();
        }

        public void Login()
        {
            //mock login
            UserManager.LogIn(UserRepository.getMockUser());
            ChildWindow = new Home();
            ChildWindow.ShowDialog();
        }

        public void TestLogin()
        {
            //MessageBox.Show("You tried to log in");
            UserRepository userRepository = new UserRepository();
            string response = UserRepository.CreateNewUser(UserRepository.getMockUser());
            MessageBox.Show(response);
        }

    }
}
