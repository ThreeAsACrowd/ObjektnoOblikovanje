using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    abstract class Invoice
    {
        int id;
        int userId;
        DateTime dateTime;
        String invoiceClassNumber;
        String amount=0;

        public abstract String getInfo();

    }
}
