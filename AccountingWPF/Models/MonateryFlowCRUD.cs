using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    interface MonetaryFlowCRUD
    {
        void Create(MonateryFlow monetaryFlow);
        void Delete(int id);

        void Update(MonateryFlow monetaryFlow);

        MonateryFlow GetById(int id);
    }
}
