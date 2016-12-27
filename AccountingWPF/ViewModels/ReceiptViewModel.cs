using System.Collections.Generic;

using AccountingWPF.BaseLib;
using DataRepository.Models;
using DataRepository.Repositories;

namespace AccountingWPF.ViewModels
{
    public class ReceiptViewModel
    {
        public IList<Receipt> receipts { get; set; }
        public IList<Vat> vats { get; set; }
        private IMonetaryFlowRepository<Receipt> receiptRepo { get; set; }
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
