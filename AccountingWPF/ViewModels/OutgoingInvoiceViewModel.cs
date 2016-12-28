using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using AccountingWPF.BaseLib;
using DataRepository.Repositories;
using System.Diagnostics;
using System.Windows.Input;
using System.Collections.ObjectModel;
using AccountingWPF.Commands;

namespace AccountingWPF.ViewModels
{
    public class OutgoingInvoiceViewModel
    {
        public ObservableCollection<OutgoingInvoice> outgoingInvoices { get; set; }
        private IInvoiceRepository<OutgoingInvoice> OutgoingInvoicesRepo { get; set; }

        public OutgoingInvoice selectedItem { get; set; }

        public ICommand AddNewOutgoingInvoiceCommand
        {
            get;
            private set;
        }

        public ICommand DeleteOutgoingInvoiceCommand
        {
            get;
            private set;
        }

        public ICommand UpdateOutgoingInvoiceCommand
        {
            get;
            private set;
        }


        public OutgoingInvoiceViewModel()
        {
            IList<OutgoingInvoice> outgoingInvoicesList;
            OutgoingInvoicesRepo = new OutgoingInvoiceRepository<OutgoingInvoice>();
            outgoingInvoicesList = OutgoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);

            this.outgoingInvoices = new ObservableCollection<OutgoingInvoice>(outgoingInvoicesList);

            //AddNewOutgoingInvoiceCommand = new AddNewOutgoingInvoiceCommand(this);
            //DeleteOutgoingInvoiceCommand = new DeleteOutgoingInvoiceCommand(this);
            //UpdateOutgoingInvoiceCommand = new UpdateOutgoingInvoiceCommand(this);
        }



        public bool CanExecuteAdd
        {
            get
            {
                return true;
            }
        }

        public bool CanExecuteDelete
        {
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
            Debug.Assert(false, "Add new invoice.");
        }

        internal void DeleteOutgoingInvoice()
        {
            if (this.selectedItem != null)
            {

                this.OutgoingInvoicesRepo.Delete(this.selectedItem.Id);
                this.outgoingInvoices.Remove(this.selectedItem);

            }
            else
            {
                //TODO!
                return;
            }

        }

        internal void UpdateOutgoingInvoice()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false, "Update invoice.");
        }

    }
}
