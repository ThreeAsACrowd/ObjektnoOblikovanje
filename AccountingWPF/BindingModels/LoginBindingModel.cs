using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AccountingWPF.BindingModels
{
	public class LoginBindingModel:INotifyPropertyChanged
	{
		private string username;
		[Required]
		public string Username 
		{
			get
			{
				return username;
			}

			set
			{
				username = value;
				OnPropertyChanged("Username");
			}
		}

		private string password;
		[Required]
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
				OnPropertyChanged("Password");
			}
		}


		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}

}
