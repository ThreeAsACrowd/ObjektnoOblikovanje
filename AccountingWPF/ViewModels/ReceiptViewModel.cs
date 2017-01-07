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
using Microsoft.Practices.Prism.Commands;
using AccountingWPF.ChildWindow.View;
using Microsoft.Practices.Prism.ViewModel;
using AccountingWPF.ChildWindow;
using System.ComponentModel.DataAnnotations;
using DataRepository.nHibernateDb;

namespace AccountingWPF.ViewModels
{
    public class ReceiptViewModel : NotificationObject
    {
        #region Properties

        public ObservableCollection<Receipt> receipts { get; set; }

        public IList<Vat> vats { get; set; }
        private IMonetaryFlowRepository<Receipt> receiptRepo { get; set; }
        private VatRepository vatRepo { get; set; }

        public Receipt selectedItem { get; set; }

        public ICommand DeleteReceiptCommand
        {
            get;
            private set;
        }

        private DelegateCommand showChildWindowAddCommand;
        public DelegateCommand ShowChildWindowAddCommand
        {
            get { return showChildWindowAddCommand; }
        }

        private DelegateCommand showChildWindowUpdateCommand;
        public DelegateCommand ShowChildWindowUpdateCommand
        {
            get { return showChildWindowUpdateCommand; }
        }

        #endregion


        private void ShowChildWindowAdd()
        {
            var childWindow = new ChildWindowAddReceiptView();
            childWindow.Closed += (r =>
            {
                if (r != null)
                {
                    this.receiptRepo.Create(r);
                    this.receipts.Add(r);
                }

            });

            childWindow.Show();

        }

        private void ShowChildWindowUpdate()
        {
            var childWindow = new ChildWindowUpdateReceiptView();


            childWindow.Closed += (r =>
            {
                if (r != null)
                {
                    this.receiptRepo.Update(r);

                    var item = this.receipts.First(i => i.Id == r.Id);
                    if (item != null)
                    {
                        item.AmountCash = r.AmountCash;
                        item.AmountNonCashBenefit = r.AmountNonCashBenefit;
                        item.AmountTransferAccount = r.AmountTransferAccount;
                        item.Date = r.Date;
                        item.FK_VAT = r.FK_VAT;
                        item.Vat = r.Vat;
                        item.Total = r.Total;
                        item.JournalEntryNum = r.JournalEntryNum;
                    }

                    CollectionViewSource.GetDefaultView(this.receipts).Refresh();
                }

            });

            if (this.selectedItem != null)
            {
                childWindow.Show(this.selectedItem);
            }
            else
            {
                MessageBox.Show("Please select item for edit.");
            }

        }


        public ReceiptViewModel()
        {
            IList<Receipt> receiptsList;
            this.receiptRepo = new ReceiptRepository<Receipt>(SessionManager.SessionFactory);
            vatRepo = new VatRepository();

            receiptsList = receiptRepo.getByUserId(UserManager.CurrentUser.Id);
            this.receipts = new ObservableCollection<Receipt>(receiptsList);

            vats = vatRepo.getAll();


            DeleteReceiptCommand = new Command(this.DeleteReceipt, this.CanExecuteDelete);
            showChildWindowAddCommand = new DelegateCommand(ShowChildWindowAdd);
            showChildWindowUpdateCommand = new DelegateCommand(ShowChildWindowUpdate);


        }
        public bool CanExecuteDelete
        {
            get
            {
                return true;
            }
        }


        internal void DeleteReceipt()
        {
            if (this.selectedItem != null)
            {

                this.receiptRepo.Delete(this.selectedItem.Id);
                this.receipts.Remove(this.selectedItem);

            }
        }
    }
}
