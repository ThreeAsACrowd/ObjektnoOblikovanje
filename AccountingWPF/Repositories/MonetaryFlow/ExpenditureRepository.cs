using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Factories;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    class ExpenditureRepository : MonetaryFlowCRUD
    {

        public void Create(MonateryFlow monetaryFlow)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public MonateryFlow GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MonateryFlow monetaryFlow)
        {
            throw new NotImplementedException();
        }

        public IList<Expenditure> getByUserId(int userId)
        {
            return Mock.getExpendituresByUserId(userId);
        }
    }
}
