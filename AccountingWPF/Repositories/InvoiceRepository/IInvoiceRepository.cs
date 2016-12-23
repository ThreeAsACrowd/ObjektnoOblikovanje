using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF;
using AccountingWPF.Models;
using AccountingWPF.Repositories.InvoiceRepository;

namespace AccountingWPF.Repositories
{
    public interface IInvoiceRepository<Invoice>
    {

        void Create(Invoice invoice);
        void Delete(int id);

        void Update(Invoice invoice);

        Invoice GetById(int id);

        IList<Invoice> getByUserId(int userId);

    }
}
