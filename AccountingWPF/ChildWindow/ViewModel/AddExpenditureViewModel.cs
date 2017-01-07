﻿using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System.Windows;
using AccountingWPF.BaseLib;
using System.Windows.Threading;
using AccountingWPF.Notification;


namespace AccountingWPF.ChildWindow.ViewModel
{
    public class AddExpenditureViewModel : PropertyChangedNotification
    {
        #region Properties
        public List<Vat> Vats { get; set; }

        public int Id { get; set; }

        public int FK_UserId { get; set; }

        public int FK_VatId
        {
            get
            {
                return GetValue(() => FK_VatId);
            }

            set
            {
                SetValue(() => FK_VatId, value);

            }
        }

        private User _user;
        public User _User
        {
            get { return _user; }
            set
            {
                _user = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
            }
        }


        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string AmountCash
        {
            get
            {
                return GetValue(() => AmountCash);
            }

            set
            {
                SetValue(() => AmountCash, value);
                
            }
        }

       
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string AmountNonCashBenefit
        {
            get
            {
                return GetValue(() => AmountNonCashBenefit);
            }

            set
            {
                SetValue(() => AmountNonCashBenefit, value);

            }
        }


        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string AmountTransferAccount
        {
            get
            {
                return GetValue(() => AmountTransferAccount);
            }

            set
            {
                SetValue(() => AmountTransferAccount, value);

            }
        }
        [Required(ErrorMessage = "Must not be empty.")]
        public string JournalEntryNumber
        {
            get
            {
                return GetValue(() => JournalEntryNumber);
            }

            set
            {
                SetValue(() => JournalEntryNumber, value);

            }
        }


        [Required(ErrorMessage = "Must not be empty.")]
        public string Article22
        {
            get
            {
                return GetValue(() => Article22);
            }

            set
            {
                SetValue(() => Article22, value);

            }
        }


        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string Total
        {
            get
            {
                return GetValue(() => Total);
            }

            set
            {
                SetValue(() => Total, value);

            }
        }

        #endregion

        #region Events

        public event Action<Expenditure> Closed;
        #endregion

        #region Command Properties

        private DelegateCommand okCommand;
        public DelegateCommand OkCommand
        {
            get { return okCommand; }
        }

        private DelegateCommand cancelCommand;
        public DelegateCommand CancelCommand
        {
            get { return cancelCommand; }
        }
        #endregion

        #region Constructor
        public AddExpenditureViewModel()
        {
            okCommand = new DelegateCommand(SaveExpenditure);
            cancelCommand = new DelegateCommand(CancelAddExpenditure);

            Init();

        }
        #endregion

        #region Methods
        public void SaveExpenditure()
        {
            VatRepository vatRepo = new VatRepository();

            IList<Vat> vats = vatRepo.getAll();
            Vat v = vats.FirstOrDefault(i => i.Id == this.FK_VatId);

            if (Closed != null)
            {
                var _Expenditure = new Expenditure()
                {

                    User = UserManager.CurrentUser,
                    Date = this.Date,
                    AmountCash = this.AmountCash,
                    AmountTransferAccount = this.AmountTransferAccount,
                    AmountNonCashBenefit = this.AmountNonCashBenefit,
                    FK_UserId = UserManager.CurrentUser.Id,
                    Vat = v,
                    FK_VAT = this.FK_VatId,
                    JournalEntryNum = this.JournalEntryNumber,
                    Total = this.Total,
                    Article22 = this.Article22

                };

                Closed(_Expenditure);
            }
        }
        public void CancelAddExpenditure()
        {
           Expenditure exp = null;
           if (Closed != null)
            {

                Closed(exp);
            }
        }


        public void Init()
        {
            VatRepository vatRepo = new VatRepository();

            IList<Vat> vats = vatRepo.getAll();
            this.Vats = new List<Vat>(vats);
            this.Date = DateTime.Now;

        }
        #endregion

    }
}
