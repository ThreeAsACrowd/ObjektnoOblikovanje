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
    public class ExpenditureViewModel : NotificationObject
    {
        #region Properties

        public ObservableCollection<Expenditure> expenditures { get; set; }

        public IList<Vat> vats { get; set; }
        private IMonetaryFlowRepository<Expenditure> expenditureRepo { get; set; }
        private VatRepository vatRepo { get; set; }

        public Expenditure selectedItem { get; set; }

        public ICommand DeleteExpenditureCommand
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
            var childWindow = new ChildWindowAddExpenditureView();
            childWindow.Closed += (r =>
            {
                this.expenditureRepo.Create(r);
                this.expenditures.Add(r);

            });

            childWindow.Show();

        }

        private void ShowChildWindowUpdate()
        {
            var childWindow = new ChildWindowUpdateExpenditureView();


            childWindow.Closed += (r =>
            {
                this.expenditureRepo.Update(r);

                var item = this.expenditures.First(i => i.Id == r.Id);
                if (item != null)
                {
                    item.AmountCash = r.AmountCash;
                    item.AmountNonCashBenefit = r.AmountNonCashBenefit;
                    item.AmountTransferAccount = r.AmountTransferAccount;
                    item.Date = r.Date;
                    item.FK_VAT = r.FK_VAT;
                    item.Vat = r.Vat;
                    item.JournalEntryNum = r.JournalEntryNum;
                    item.Article22 = r.Article22;
                }

                CollectionViewSource.GetDefaultView(this.expenditures).Refresh();

            });

            childWindow.Show(this.selectedItem);


        }


        public ExpenditureViewModel()
        {
            IList<Expenditure> expendituresList;
            this.expenditureRepo = new ExpenditureRepository<Expenditure>(SessionManager.SessionFactory);
            vatRepo = new VatRepository();

            expendituresList = expenditureRepo.getByUserId(UserManager.CurrentUser.Id);
            this.expenditures = new ObservableCollection<Expenditure>(expendituresList);

            vats = vatRepo.getAll();


            DeleteExpenditureCommand = new Command(this.DeleteExpenditure, this.CanExecuteDelete);
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


        internal void DeleteExpenditure()
        {
            if (this.selectedItem != null)
            {

                this.expenditureRepo.Delete(this.selectedItem.Id);
                this.expenditures.Remove(this.selectedItem);

            }
        }
    }
}
