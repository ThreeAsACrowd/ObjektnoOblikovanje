using System;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Models
{
    public abstract class MonetaryFlow
    {
        public virtual int Id { get; set; }
        public virtual int FK_VAT { get; set; }
        public virtual Vat Vat { get; set; }
        public virtual int FK_UserId { get; set; }
        public virtual User User { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string JournalEntryNum { get; set; }

        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string AmountCash { get; set; }
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string AmountTransferAccount { get; set; }
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string AmountNonCashBenefit { get; set; }
        public virtual string Total { get; set; }

    }
}
