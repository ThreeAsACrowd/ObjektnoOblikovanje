using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.Repositories
{
    public interface IVatRepository
    {

        void Create(Vat vat);
        void Delete(int id);
        void Update(Vat vat);

        Vat GetById(int id);

        IList<Vat> getAll();
    }
}
