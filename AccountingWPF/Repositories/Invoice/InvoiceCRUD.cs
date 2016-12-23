using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    interface InvoiceCRUD
    {

        void Create(Invoice invoice);
        void Delete(int id);

        void Update(Invoice invoice);

        Invoice GetById(int id);

    }
}
