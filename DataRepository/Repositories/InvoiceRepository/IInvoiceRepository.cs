using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository;
using DataRepository.Models;
using DataRepository.Repositories.InvoiceRepository;

namespace DataRepository.Repositories
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
