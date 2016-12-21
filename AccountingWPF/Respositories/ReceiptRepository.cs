using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Respositories
{
    public class ReceiptRepository
    {

        public static Receipt GetReceiptById(int id)
        {
            return new Receipt();
        }

        public static void Update(Receipt expenditure)
        {
            Console.WriteLine("Update receipt");
        }

        public static void Delete(int id)
        {
            Console.WriteLine("Delete receipt");

        }

        public static void Create(Receipt receipt)
        {
            Console.WriteLine("Create receipt");
        }

    }
}
