using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AccountingWPF.Notification;



namespace AccountingWPF.BindingModels
{
	public class LoginBindingModel:PropertyChangedNotification
	{

		[Required(ErrorMessage="Username must not be empty")]
		public string Username 
		{
			get
			{
				return GetValue(() => Username);
			}

			set
			{
				SetValue(() => Username, value);
			}
		}


		[Required(ErrorMessage="Password must not be empty")]
		public string Password
		{
			get
			{
				return GetValue(() => Password);
			}
			set
			{
				SetValue(() => Password, value);
			}
		}


	}

}
