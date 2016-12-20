using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public abstract class MonateryFlow
    {
        public virtual int Id { get; protected set; }

        public virtual int FK_VAT { get; set; }

        public virtual int FK_UserId { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string JournalEntryNum { get; set; }

        public virtual string AmountCash { get; set; }

        public virtual string AmountTransferAccount { get; set; }

        public virtual string AmountNonCashBenefit { get; set; }

        public virtual string Total { get; set; }
    }
}
