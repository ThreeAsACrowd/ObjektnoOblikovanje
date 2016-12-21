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
<<<<<<< HEAD
using AccountingWPF.BaseLib;
=======
>>>>>>> b711e53a2be0593f9aa0a5735b81c4ab295b9728

namespace AccountingWPF.ViewModels
{
    public class LoginViewModel
    {
        public LoginBindingModel LoginBM { get; set; }

<<<<<<< HEAD
        public Window ChildWindow { get; set; }
=======
		public Window ChildWindow { get; set; }
>>>>>>> b711e53a2be0593f9aa0a5735b81c4ab295b9728

        public LoginViewModel()
        {
            LoginBM = new LoginBindingModel();
        }

<<<<<<< HEAD
        public void Login()
=======
		public void Login()
		{
			ChildWindow = new Home();
			ChildWindow.ShowDialog();
		}

        public void TestLogin()
>>>>>>> b711e53a2be0593f9aa0a5735b81c4ab295b9728
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
