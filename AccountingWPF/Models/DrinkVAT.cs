using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    class DrinkVAT : VAT
    {
        public override string Name {
            get {
                return "Drink VAT";
            }

            set { }
        }

        public override string Percentage {
            get {
                return "10";
            }

            set { }
        }
    }
}
