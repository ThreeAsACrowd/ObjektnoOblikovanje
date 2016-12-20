using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public class OutgoingInvoice : Invoice
    {

        public virtual string CustomerInfo { get; set; }


        public override string getInfo()
        {
            return CustomerInfo;
        }
    }
}
