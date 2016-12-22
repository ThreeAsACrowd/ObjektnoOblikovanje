using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Factories;
using AccountingWPF.Models;

namespace AccountingWPF.Respositories
{
    class IngoingInvoiceRepository : InvoiceCRUD
    {
        public void Create(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public IList<IngoingInvoice> getByUserId(int userId)
        {

            return Mock.getIngoingInvoicesByUserId(userId);
        }
    }
}
