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

namespace AccountingWPF.ViewModels
{
    public class OutgoingInvoiceViewModel : NotificationObject
    {
        public ObservableCollection<OutgoingInvoice> OutgoingInvoices { get; set; }
        public IInvoiceRepository<OutgoingInvoice> OutgoingInvoicesRepo { get; set; }

        public OutgoingInvoice selectedItem { get; set; }

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

        private void ShowChildWindowAdd()
        {
            var childWindow = new ChildWindowAddOutgoingInvoiceView();
            childWindow.Closed += (r =>
            {
                this.OutgoingInvoicesRepo.Create(r);
                this.OutgoingInvoices.Add(r);

            });

            childWindow.Show();

        }

        private void ShowChildWindowUpdate()
        {
            var childWindow = new ChildWindowUpdateOutgoingInvoiceView();

            childWindow.Closed += (r =>
            {
                this.OutgoingInvoicesRepo.Update(r);

                var item = this.OutgoingInvoices.First(i => i.Id == r.Id);
                if (item != null)
                {
                    item.Amount = r.Amount;
                    item.Date = r.Date;
                    item.InvoiceClassNumber = r.InvoiceClassNumber;
                    item.CustomerInfo = r.CustomerInfo;
                }
                CollectionViewSource.GetDefaultView(this.OutgoingInvoices).Refresh();

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

        public ICommand DeleteOutgoingInvoiceCommand
        {
            get;
            private set;
        }


        public OutgoingInvoiceViewModel()
        {
            IList<OutgoingInvoice> OutgoingInvoicesList;

            OutgoingInvoicesRepo = new OutgoingInvoiceRepository<OutgoingInvoice>();
            OutgoingInvoicesList = OutgoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);

            this.OutgoingInvoices = new ObservableCollection<OutgoingInvoice>(OutgoingInvoicesList);

            DeleteOutgoingInvoiceCommand = new Command(this.DeleteOutgoingInvoice, this.CanExecuteDelete);

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


        internal void DeleteOutgoingInvoice()
        {
            if (this.selectedItem != null)
            {

                this.OutgoingInvoicesRepo.Delete(this.selectedItem.Id);
                this.OutgoingInvoices.Remove(this.selectedItem);

            }
            else
            {
                //TODO!
                return;
            }

        }
    }
}
