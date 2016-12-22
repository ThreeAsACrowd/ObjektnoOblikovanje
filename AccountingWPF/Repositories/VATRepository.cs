using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    class VATRepository
    {


        public static IList<VAT> getAllVATs()
        {
            return Factories.Mock.getAllVATs();
        }

    }
}
