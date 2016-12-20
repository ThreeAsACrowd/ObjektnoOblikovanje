using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    class IngoingInvoice : Invoice
    {
        String supplierInfo;

        public override string getInfo()
        {
            return supplierInfo;
        }
    }
}
