using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.BindingModels;
using System.Windows;

namespace AccountingWPF.ViewModels
{
	public class LoginViewModel
	{
		public LoginBindingModel LoginBM { get; set; }

		public LoginViewModel()
		{
			LoginBM = new LoginBindingModel();
		}


		public void Login()
		{
			MessageBox.Show("You tried to log in");
		}

	}
}
