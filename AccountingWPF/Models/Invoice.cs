using AccountingWPF.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public abstract class Invoice : PropertyChangedNotification
    {
        public virtual int Id {
            get {
                return GetValue(() => Id);
            }
            set {
                SetValue(() => Id, value);
            }
        }

        public virtual int FK_UserId {
            get {
                return GetValue(() => FK_UserId);
            }
            set {
                SetValue(() => FK_UserId, value);
            }
        }

        public virtual DateTime Date {
            get {
                return GetValue(() => Date);
            }
            set {
                SetValue(() => Date, value);
            }
        }

        public virtual string InvoiceClassNumber {
            get {
                return GetValue(() => InvoiceClassNumber);
            }
            set {
                SetValue(() => InvoiceClassNumber, value);
            }
        }

		[RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string Amount {
            get {
                return GetValue(() => Amount);
            }
            set {
                SetValue(() => Amount, value);
            }
        }

        public abstract string getInfo();

    }
}
