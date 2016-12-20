using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public class IngoingInvoice : Invoice
    {
        public virtual string SupplierInfo { get; set; }

        public override string getInfo()
        {
            return SupplierInfo;
        }
    }
}
