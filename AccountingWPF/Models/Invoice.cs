using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public abstract class Invoice
    {
		public int Id { get; private set; }

        public int FK_UserId { get; set; }

        public DateTime Date { get; set; }

		public string InvoiceClassNumber { get; set; }

		public string Amount { get; set; }

        public abstract string getInfo();

    }
}
