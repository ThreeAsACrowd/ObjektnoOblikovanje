using AccountingWPF.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{

    public abstract class VAT:PropertyChangedNotification
    {
		public int Id
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

		public string Name
		{
			get
			{
				return GetValue(() => Name);
			}
			set
			{
				SetValue(() => Name, value);
			}
		}

		public string Percentage
		{
			get
			{
				return GetValue(() => Percentage);
			}
			set
			{
				SetValue(() => Percentage, value);
			}
		}

}
