using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.BaseLib;
using AccountingWPF.Repositories;

namespace AccountingWPF.ViewModels
{
    public class IngoingInvoiceViewModel
    {
        public IList<IngoingInvoice> ingoing_invoices { get; set; }
        private IInvoiceRepository<IngoingInvoice> IngoingInvoicesRepo { get; set; }

        public IngoingInvoiceViewModel()
        {
            IngoingInvoicesRepo = new IngoingInvoiceRepository<IngoingInvoice>();
            ingoing_invoices = IngoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);
            //TODO!
        }
    }
}
