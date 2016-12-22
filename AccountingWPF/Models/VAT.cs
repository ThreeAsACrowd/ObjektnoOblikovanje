using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public abstract class VAT
    {
        public int Id { get; private set; }
        public abstract string Name { get; set; }
        public abstract string Percentage { get; set; }

    }
}
