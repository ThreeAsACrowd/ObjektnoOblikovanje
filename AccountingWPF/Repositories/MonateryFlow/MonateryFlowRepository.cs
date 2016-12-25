using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    public interface MonateryFlowRepository<MonateryFlow>
    {
        void Create(MonateryFlow monetaryFlow);
        void Delete(int id);

        void Update(MonateryFlow monetaryFlow);

        MonateryFlow GetById(int id);

        IList<MonateryFlow> getByUserId(int userId);

        IList<MonateryFlow> getUserMonateryFlowByYear(int userId,int year);

        IList<int> getAvailableYearsByUserId(int userId);
    }
}
