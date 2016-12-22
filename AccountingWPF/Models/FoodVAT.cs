using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    class FoodVAT : VAT
    {
        public override string Name {
            get {
                return "Food VAT";
            }

            set { }
        }

        public override string Percentage {
            get {
                return "20";
            }

            set { }
        }
    }
}
