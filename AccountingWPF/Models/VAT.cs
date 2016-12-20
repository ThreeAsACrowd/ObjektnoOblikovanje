using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    abstract class VAT
    {
		public int Id { get; private set; }
		public string Name { get; set; }
		public string Percentage { get; set; }

    }
}
