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
            var childWindow = new ChildWindowAddIngoingInvoiceView();
            childWindow.Closed += (r =>
            {
                this.IngoingInvoicesRepo.Create(r);
                this.ingoingInvoices.Add(r);

            });
                          
            childWindow.Show();
            
        }

        private void ShowChildWindowUpdate()
        {
            var childWindow = new ChildWindowUpdateIngoingInvoiceView();

            childWindow.Closed += (r =>
            {
                this.IngoingInvoicesRepo.Update(r);
                
                var item = this.ingoingInvoices.First(i => i.Id == r.Id);
                if (item != null)
                {
                    item.Amount = r.Amount;
                    item.Date = r.Date;
                    item.InvoiceClassNumber = r.InvoiceClassNumber;
                    item.SupplierInfo = r.SupplierInfo;
                }
                CollectionViewSource.GetDefaultView(this.ingoingInvoices).Refresh();
               
            });

            childWindow.Show(this.selectedItem);
            
            
        } 

        public ICommand DeleteIngoingInvoiceCommand
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

            showChildWindowAddCommand = new DelegateCommand(ShowChildWindowAdd);
            showChildWindowUpdateCommand = new DelegateCommand(ShowChildWindowUpdate);
        }


        public bool CanExecuteDelete { 
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
                return;
            }                      
        }
    }
}
