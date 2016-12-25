using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.Repositories;
using AccountingWPF.BaseLib;

namespace AccountingWPF.ViewModels
{
    public class ExpenditureViewModel
    {
        public IList<Expenditure> expenditures { get; set; }
        public IList<Vat> vats { get; set; }
        private MonetaryFlowRepository<Expenditure> expenditureRepo { get; set; }
        private VatRepository vatRepo { get; set; }

        public ExpenditureViewModel()
        {
            expenditureRepo = new ExpenditureRepository<Expenditure>();
			vatRepo = new VatRepository();

            expenditures = expenditureRepo.getByUserId(UserManager.CurrentUser.Id);
			vats = vatRepo.getAll();

        }

    }
}
