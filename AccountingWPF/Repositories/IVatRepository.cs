using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    public interface IVatRepository
    {

        void Create(VAT vat);
        void Delete(int id);
        void Update(VAT vat);

        VAT GetById(int id);

        IList<VAT> getAll();
    }
}
