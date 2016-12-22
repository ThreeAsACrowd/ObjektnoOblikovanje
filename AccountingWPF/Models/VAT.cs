using AccountingWPF.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{

    public class VAT : PropertyChangedNotification
    {
        public virtual int Id {
            get {
                return GetValue(() => Id);
            }
            set {
                SetValue(() => Id, value);
            }
        }

        public virtual string Name {
            get {
                return GetValue(() => Name);
            }
            set {
                SetValue(() => Name, value);
            }
        }

        public virtual int Percentage {
            get {
                return GetValue(() => Percentage);
            }
            set {
                SetValue(() => Percentage, value);
            }
        }
    }
}
