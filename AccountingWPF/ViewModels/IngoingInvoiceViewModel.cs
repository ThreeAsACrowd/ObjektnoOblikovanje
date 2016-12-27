using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.BaseLib;
using AccountingWPF.Repositories;
using System.Windows.Input;
using AccountingWPF.Commands;
using System.Diagnostics;

namespace AccountingWPF.ViewModels
{
    public class IngoingInvoiceViewModel
    {
        public IList<IngoingInvoice> ingoing_invoices { get; set; }
        public IInvoiceRepository<IngoingInvoice> IngoingInvoicesRepo { get; set; }

        public IngoingInvoice selectedItem { get; set; }

        public ICommand AddNewIngoingInvoiceCommand
        {
            get;
            private set;
        }

        public ICommand DeleteIngoingInvoiceCommand
        {
            get;
            private set;
        }

        public ICommand UpdateIngoingInvoiceCommand
        {
            get;
            private set;
        }

        public IngoingInvoiceViewModel()
        {
            IngoingInvoicesRepo = new IngoingInvoiceRepository<IngoingInvoice>();
            ingoing_invoices = IngoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);
            AddNewIngoingInvoiceCommand = new AddNewIngoingInvoiceCommand(this);
            DeleteIngoingInvoiceCommand = new DeleteIngoingInvoiceCommand(this);
            UpdateIngoingInvoiceCommand = new UpdateIngoingInvoiceCommand(this);
        }

        public bool CanExecuteAdd
        {
            get 
            {
                return true;
            }
        }

        public bool CanExecuteDelete { 
            get 
            { 
                return true; 
            }
        }

        public bool CanExecuteUpdate
        {
            get
            {
                return true;
            }
        }

        internal void AddNewInvoice()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false,"Add new invoice.");
        }

        internal void DeleteIngoingInvoice()
        {
            if (this.selectedItem != null)
            {
                this.IngoingInvoicesRepo.Delete(this.selectedItem.Id);
            }
            else
            {
                //TODO!
                return;
            }          
            
        }

        internal void UpdateIngoingInvoice()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false, "Update invoice.");
        }


    }
}
