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
			ChildWindow = new Home();
			ChildWindow.ShowDialog();
		}

        public void TestLogin()
        {
            //MessageBox.Show("You tried to log in");

            User user = new User();
            user.Username = "marko";
            user.Password = "pass";
            user.OIB = "123141";
            user.Address = "adresa";
            user.Email = "mojemail@email.com";
            user.AssociationName = "udruga";

            UserRepository userRepository = new UserRepository();
            string response = UserRepository.CreateNewUser(user);
            MessageBox.Show(response);
        }

    }
}
