using AccountingWPF.BaseLib;
using DataRepository.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AccountingWPF.ChildWindow.ViewModel
{
    public class UpdateReceiptViewModel : NotificationObject
    {
        #region Properties

        private Receipt receipt_c;
        public Receipt Receipt_c
        {
            get { return receipt_c; }
            set
            {
                receipt_c = value;
            }
        }

        public List<Vat> Vats { get; set; }

        public int Id { get; set; }

        public int FK_UserId { get; set; }

        private int fK_VATId;
        public int FK_VatId
        {
            get { return fK_VATId; }

            set
            {
                fK_VATId = value;
                RaisePropertyChanged("FK_VatId");
            }

        }

        private User _user;
        public User _User
        {
            get { return _user; }
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
        }

        private Vat _vat;
        public Vat _Vat
        {
            get { return _vat; }
            set
            {
                _vat = value;
                RaisePropertyChanged("Vat");
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

        private string amountCash;
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string AmountCash
        {
            get { return amountCash; }
            set
            {
                amountCash = value;
                RaisePropertyChanged("AmountCash");
            }
        }

        private string amountNonCashBenefit;
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string AmountNonCashBenefit
        {
            get { return amountNonCashBenefit; }
            set
            {
                amountNonCashBenefit = value;
                RaisePropertyChanged("AmountNonCashBenefit");
            }
        }

        private string amountTransferAccount;
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string AmountTransferAccount
        {
            get { return amountTransferAccount; }
            set
            {
                amountTransferAccount = value;
                RaisePropertyChanged("AmountTransferAccount");
            }
        }
        private string journalEntryNumber;
        public string JournalEntryNumber
        {
            get { return journalEntryNumber; }
            set
            {
                journalEntryNumber = value;
                RaisePropertyChanged("JournalEntryNumber");
            }
        }


        private string total;
        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string Total
        {
            get { return total; }
            set
            {
                total = value;
                RaisePropertyChanged("Total");
            }
        }

        #endregion

        #region Events

        public event Action<Receipt> Closed;
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

        public UpdateReceiptViewModel(Receipt selected)
        {
            this.Receipt_c = selected;

            this.Id = selected.Id;
            this._User = selected.User;
            this._Vat = selected.Vat;
            this.FK_UserId = selected.FK_UserId;
            this.Date = selected.Date;
            this.AmountCash = selected.AmountCash;
            this.AmountTransferAccount = selected.AmountTransferAccount;
            this.AmountNonCashBenefit = selected.AmountNonCashBenefit;
            
            this.FK_VatId = selected.FK_VAT;
            this.JournalEntryNumber = selected.JournalEntryNum;
            this.Total = selected.Total;
            okCommand = new DelegateCommand(SaveReceipt);
            cancelCommand = new DelegateCommand(CancelUpdateReceipt);

            Init();

        }


        public void SaveReceipt()
        {
            VatRepository vatRepo = new VatRepository();

            IList<Vat> vats = vatRepo.getAll();
            Vat v = vats.FirstOrDefault(i => i.Id == this.FK_VatId);

            if (Closed != null)
            {
                var _Receipt = new Receipt()
                {
                    Id = this.Id,
                    User = UserManager.CurrentUser,
                    Date = this.Date,
                    AmountCash = this.AmountCash,
                    AmountTransferAccount = this.AmountTransferAccount,
                    AmountNonCashBenefit = this.AmountNonCashBenefit,
                    FK_UserId = UserManager.CurrentUser.Id,
                    Vat = v,
                    FK_VAT = this.FK_VatId,
                    JournalEntryNum = this.JournalEntryNumber,
                    Total = this.Total

                };

                Closed(_Receipt);
            }
        }

        public void CancelUpdateReceipt()
        {
            if (Closed != null)
            {
                Closed(Receipt_c);
            }
        }

        public void Init()
        {
            VatRepository vatRepo = new VatRepository();

            IList<Vat> vats = vatRepo.getAll();
            this.Vats = new List<Vat>(vats);

        }
    }
}
