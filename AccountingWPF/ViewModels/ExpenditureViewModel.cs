using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Models;
using DataRepository.Repositories;
using AccountingWPF.BaseLib;
using System.Diagnostics;
using System.Windows.Input;
using System.Collections.ObjectModel;
using AccountingWPF.Commands;

namespace AccountingWPF.ViewModels
{
    public class ExpenditureViewModel
    {
        public ObservableCollection<Expenditure> expenditures { get; set; }
        public IList<Vat> vats { get; set; }
        private IMonetaryFlowRepository<Expenditure> expenditureRepo { get; set; }
        private VatRepository vatRepo { get; set; }

        public Expenditure selectedItem { get; set; }

        public ICommand AddNewExpenditureCommand
        {
            get;
            private set;
        }

        public ICommand DeleteExpenditureCommand
        {
            get;
            private set;
        }

        public ICommand UpdateExpenditureCommand
        {
            get;
            private set;
        }

        public ExpenditureViewModel()
        {
            IList<Expenditure> expendituresList;
            expenditureRepo = new ExpenditureRepository<Expenditure>();
			vatRepo = new VatRepository();

            expendituresList = expenditureRepo.getByUserId(UserManager.CurrentUser.Id);
            this.expenditures = new ObservableCollection<Expenditure>(expendituresList);

			vats = vatRepo.getAll();

            AddNewExpenditureCommand = new Command(this.AddNewExpenditure, this.CanExecuteAdd);
            DeleteExpenditureCommand = new Command(this.DeleteExpenditure, this.CanExecuteDelete);
            UpdateExpenditureCommand = new Command(this.UpdateExpenditure, this.CanExecuteUpdate);

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

        internal void AddNewExpenditure()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false, "Add new expenditure.");
        }

        internal void DeleteExpenditure()
        {
            if (this.selectedItem != null)
            {

                this.expenditureRepo.Delete(this.selectedItem.Id);
                this.expenditures.Remove(this.selectedItem);

            }
            else
            {
                //TODO!
                return;
            }

        }

        internal void UpdateExpenditure()
        {
            //TODO IMPLEMENTATION
            Debug.Assert(false, "Update invoice.");
        }
    }
}
