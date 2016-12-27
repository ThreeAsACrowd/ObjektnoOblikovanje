using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;

namespace DataRepository.Repositories
{
    public interface IMonetaryFlowRepository<MonetaryFlow>
    {
        void Create(MonetaryFlow monetaryFlow);
        void Delete(int id);

        void Update(MonetaryFlow monetaryFlow);

        MonetaryFlow GetById(int id);

        IList<MonetaryFlow> getByUserId(int userId);

        IList<MonetaryFlow> getUserMonetaryFlowByYear(int userId,int year);

        IList<int> getAvailableYearsByUserId(int userId);
    }
}
