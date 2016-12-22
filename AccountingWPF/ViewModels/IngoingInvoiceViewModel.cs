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
        private IngoingInvoiceRepository IngoingInvoicesRepo { get; set; }

        public IngoingInvoiceViewModel()
        {
            IngoingInvoicesRepo = new IngoingInvoiceRepository();
            //ingoing_invoices = IngoingInvoicesRepo.getByUserId();
            //TODO!
        }
    }
}
