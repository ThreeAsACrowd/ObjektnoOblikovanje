using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public class OutgoingInvoice : Invoice
    {

        public virtual string CustomerInfo {
            get {
                return GetValue(() => CustomerInfo);
            }
            set {
                SetValue(() => CustomerInfo, value);
            }
        }


        public override string getInfo()
        {
            return CustomerInfo;
        }
    }
}
