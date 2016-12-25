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
    public class ReceiptViewModel
    {
        public IList<Receipt> receipts { get; set; }
        public IList<Vat> vats { get; set; }
        private MonateryFlowRepository<Receipt> receiptRepo { get; set; }
        private VatRepository vatRepo { get; set; }

        public ReceiptViewModel()
        {
            receiptRepo = new ReceiptRepository<Receipt>();
            vatRepo = new VatRepository();

            receipts = receiptRepo.getByUserId(UserManager.CurrentUser.Id);
            vats = vatRepo.getAll();
        }

    }
}
