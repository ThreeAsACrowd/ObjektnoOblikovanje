using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public abstract class Invoice
    {
        public virtual int Id { get; protected set; }

        public virtual int FK_UserId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string InvoiceClassNumber { get; set; }

        public virtual string Amount { get; set; }

        public abstract string getInfo();

    }
}
