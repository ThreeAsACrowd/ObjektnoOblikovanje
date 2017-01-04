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
    public class IngoingInvoiceViewModel: NotificationObject
    {
        public ObservableCollection<IngoingInvoice> ingoingInvoices { get; set; }
        public IInvoiceRepository<IngoingInvoice> IngoingInvoicesRepo { get; set; }

        public IngoingInvoice selectedItem { get; set; }

        private DelegateCommand showChildWindowCommand;
        public DelegateCommand ShowChildWindowCommand
        {
            get { return showChildWindowCommand; }
        } 

        public ICommand AddNewIngoingInvoiceCommand
        {
            get;
            private set;
        }

        private void ShowChildWindow()
        {
            var childWindow = new ChildWindowView();
            childWindow.Closed += (r =>
            {
                this.IngoingInvoicesRepo.Create(r);

            });

            IList<IngoingInvoice> ingoingInvoicesList;


            ingoingInvoicesList = this.IngoingInvoicesRepo.getByUserId(UserManager.CurrentUser.Id);

            this.ingoingInvoices = new ObservableCollection<IngoingInvoice>(ingoingInvoicesList);
                
            childWindow.Show();

            
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

            DeleteIngoingInvoiceCommand = new Command(this.DeleteIngoingInvoice, this.CanExecuteDelete);
            UpdateIngoingInvoiceCommand = new Command(this.UpdateIngoingInvoice, this.CanExecuteUpdate);

            showChildWindowCommand = new DelegateCommand(ShowChildWindow);
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

        public int Id { get; set; }

        public int FK_UserId { get; set; }

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged("User");
            }
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged("Date");
            }
        }

        private string invoiceClassNumber;

        public string InvoiceClassNumber
        {
            get { return invoiceClassNumber; }
            set
            {
                invoiceClassNumber = value;
                RaisePropertyChanged("InvoiceClassNumber");
            }
        }


        private string amount;
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                RaisePropertyChanged("Amount");
            }
        }


    }
}
