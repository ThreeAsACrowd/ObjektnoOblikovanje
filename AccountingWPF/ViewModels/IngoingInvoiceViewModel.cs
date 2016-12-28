using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using AccountingWPF.BaseLib;
using DataRepository.Repositories;
using System.Windows.Input;
using AccountingWPF.Commands;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace AccountingWPF.ViewModels
{
    public class IngoingInvoiceViewModel
    {
        public ObservableCollection<IngoingInvoice> ingoingInvoices { get; set; }
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
            IList<IngoingInvoice> ingoingInvoicesList;

            IngoingInvoicesRepo = new IngoingInvoiceRepository<IngoingInvoice>();
            ingoingInvoicesList = IngoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);

            this.ingoingInvoices = new ObservableCollection<IngoingInvoice>(ingoingInvoicesList);

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
                this.ingoingInvoices.Remove(this.selectedItem);

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
