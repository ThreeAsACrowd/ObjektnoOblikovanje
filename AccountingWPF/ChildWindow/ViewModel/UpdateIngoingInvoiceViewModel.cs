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
using System.Windows.Data;

namespace AccountingWPF.ChildWindow.ViewModel
{
    public class UpdateIngoingInvoiceViewModel : NotificationObject
    {
        #region Events

        public event Action<IngoingInvoice> Closed;
        #endregion

        #region Command Properties

        private DelegateCommand okCommand;
        public DelegateCommand OkCommand
        {
            get { return okCommand; }
        }

        #endregion

        public UpdateIngoingInvoiceViewModel(IngoingInvoice selected)
        {
            this.Id = selected.Id;
            this._User = selected.User;
            this.FK_UserId = selected.FK_UserId;
            this.Date = selected.Date;
            this.SupplierInfo = selected.SupplierInfo;
            this.Amount = selected.Amount;
            this.InvoiceClassNumber = selected.InvoiceClassNumber;
            okCommand = new DelegateCommand(SaveIngoingInvoice);
                        
        }

        public int Id { get; set; }

        public int FK_UserId { get; set; }

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

        private string supplierInfo;

        public string SupplierInfo
        {
            get { return supplierInfo; }
            set
            {
                supplierInfo = value;
                RaisePropertyChanged("SupplierInfo");
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

        public void SaveIngoingInvoice()
        {

            if (Closed != null)
            {
                var _ingoingInvoice = new IngoingInvoice()
                {
                    Id = this.Id,
                    User = UserManager.CurrentUser,
                    Date = this.Date,
                    InvoiceClassNumber = this.InvoiceClassNumber,
                    Amount = this.Amount,
                    SupplierInfo = this.SupplierInfo,
                    FK_UserId = UserManager.CurrentUser.Id

                };


                Closed(_ingoingInvoice);
                
            }
        }

    }
}
