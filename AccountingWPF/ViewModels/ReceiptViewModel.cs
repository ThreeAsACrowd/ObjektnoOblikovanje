using System.Collections.Generic;

using AccountingWPF.BaseLib;
using DataRepository.Models;
using DataRepository.Repositories;
using System.Diagnostics;
using AccountingWPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AccountingWPF.ViewModels
{
    public class ReceiptViewModel
    {
        public IList<Receipt> receipts { get; set; }
        public IList<Vat> vats { get; set; }
        private IMonetaryFlowRepository<Receipt> receiptRepo { get; set; }
        private VatRepository vatRepo { get; set; }

         public Receipt selectedItem { get; set; }

        public ICommand AddNewReceiptCommand
        {
            get;
            private set;
        }

        public ICommand DeleteReceiptCommand
        {
            get;
            private set;
        }

        public ICommand UpdateReceiptCommand
        {
            get;
            private set;
        }

        public ReceiptViewModel()
        {
            IList<Receipt> receiptsList;
            receiptRepo = new ReceiptRepository<Receipt>();
			vatRepo = new VatRepository();

            receiptsList = receiptRepo.getByUserId(UserManager.CurrentUser.Id);
            this.receipts = new ObservableCollection<Receipt>(receiptsList);

			vats = vatRepo.getAll();

            AddNewReceiptCommand = new Command(this.AddNewReceipt, this.CanExecuteAdd);
            DeleteReceiptCommand = new Command(this.DeleteReceipt, this.CanExecuteDelete);
            UpdateReceiptCommand = new Command(this.UpdateReceipt, this.CanExecuteUpdate);

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

        internal void AddNewReceipt()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false, "Add new receipt.");
        }

        internal void DeleteReceipt()
        {
            if (this.selectedItem != null)
            {

                this.receiptRepo.Delete(this.selectedItem.Id);
                this.receipts.Remove(this.selectedItem);

            }
            else
            {
                //TODO!
                return;
            }

        }

        internal void UpdateReceipt()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false, "Update receipt.");
        }

    }
}
