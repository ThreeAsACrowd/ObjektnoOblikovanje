using System;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Models
{
    public abstract class Invoice 
    {
        public virtual int Id { get; set; }
        public virtual int FK_UserId { get; set; }
        public virtual User User { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string InvoiceClassNumber { get; set; }

      
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string Amount { get; set; }

        public abstract string getInfo();

    }
}
