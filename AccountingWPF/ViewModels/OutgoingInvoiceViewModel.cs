using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using AccountingWPF.BaseLib;
using DataRepository.Repositories;

namespace AccountingWPF.ViewModels
{
    public class OutgoingInvoiceViewModel
    {
        public IList<OutgoingInvoice> outgoing_invoices { get; set; }
        private IInvoiceRepository<OutgoingInvoice> OutgoingInvoicesRepo { get; set; }

        public OutgoingInvoiceViewModel()
        {
            OutgoingInvoicesRepo = new OutgoingInvoiceRepository<OutgoingInvoice>();
            outgoing_invoices = OutgoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);
        }
    }
}
