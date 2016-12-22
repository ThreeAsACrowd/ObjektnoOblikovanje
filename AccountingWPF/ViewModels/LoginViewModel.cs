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

        public bool Login()
        {
            string username = LoginBM.Username;
            string password = LoginBM.Password;

            if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username must not be empty");
            }
            else if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password must not be empty");
            }
            else
            {
                UserRepository.CreateNewUser(UserRepository.getMockUser());

                UserCredentials userCredentials = new UserCredentials(username, password);
                //mock login
                User user = UserRepository.GetUserByCredentials(userCredentials);
                if (user != null)
                {
                    UserManager.LogIn(user);
                    return true;
                }
                else
                {
                    MessageBox.Show("Di ceees");
                }

            }
            return false;

        }

        public void OpenHome()
        {
            ChildWindow = new Home();
            ChildWindow.ShowDialog();

            LoginBM.Username = "";
            LoginBM.Password = "";
        }

        public void TestLogin()
        {
            //MessageBox.Show("You tried to log in");
            //UserRepository userRepository = new UserRepository();
            //MessageBox.Show();
        }

    }
}
