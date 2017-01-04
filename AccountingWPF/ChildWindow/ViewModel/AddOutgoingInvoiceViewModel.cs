using DataRepository.Models;
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

namespace AccountingWPF.ChildWindow.ViewModel
{
    public class AddOutgoingInvoiceViewModel : NotificationObject
    {

        #region Events

        public event Action<OutgoingInvoice> Closed;
        #endregion

        #region Command Properties

        private DelegateCommand okCommand;
        public DelegateCommand OkCommand
        {
            get { return okCommand; }
        }

        #endregion

        public AddOutgoingInvoiceViewModel()
        {
            okCommand = new DelegateCommand(SaveOutgoingInvoice);

            Init();

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

        private string customerInfo;

        public string CustomerInfo
        {
            get { return customerInfo; }
            set
            {
                customerInfo = value;
                RaisePropertyChanged("CustomerInfo");
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

        public void SaveOutgoingInvoice()
        {

            if (Closed != null)
            {
                var _OutgoingInvoice = new OutgoingInvoice()
                {

                    User = UserManager.CurrentUser,
                    Date = this.Date,
                    InvoiceClassNumber = this.InvoiceClassNumber,
                    Amount = this.Amount,
                    CustomerInfo = this.CustomerInfo,
                    FK_UserId = UserManager.CurrentUser.Id

                };


                Closed(_OutgoingInvoice);
            }
        }

        public void Init()
        {
            //MessageBox.Show("Hello");
        }

    }
}
