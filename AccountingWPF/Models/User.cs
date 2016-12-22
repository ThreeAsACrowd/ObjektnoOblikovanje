using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Notification;

namespace AccountingWPF.Models
{
    public class User:PropertyChangedNotification
    {
        public User()
        {

        }

		public virtual int Id
		{
			get
			{
				return GetValue(() => Id);
			}
			set
			{
				SetValue(() => Id, value);
			}
		}

        //[Required(ErrorMessage = "Username is mandatory")]
		public virtual string Username
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

        //  [Required(ErrorMessage = "Password is mandatory")]
		public virtual string Password
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

		public virtual string Email
		{
			get
			{
				return GetValue(() => Email);
			}
			set
			{
				SetValue(() => Email, value);
			}
		}

		public virtual string Address
		{
			get
			{
				return GetValue(() => Address);
			}
			set
			{
				SetValue(() => Address, value);
			}
		}

		public virtual string AssociationName
		{
			get
			{
				return GetValue(() => AssociationName);
			}
			set
			{
				SetValue(() => AssociationName, value);
			}
		}

		public virtual string OIB
		{
			get
			{
				return GetValue(() => OIB);
			}
			set
			{
				SetValue(() => OIB, value);
			}
		}


    }
}
