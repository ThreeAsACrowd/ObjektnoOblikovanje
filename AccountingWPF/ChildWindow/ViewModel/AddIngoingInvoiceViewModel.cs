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
using AccountingWPF.Notification;


namespace AccountingWPF.ChildWindow.ViewModel
{
    public class AddIngoingInvoiceViewModel : PropertyChangedNotification
    {
        #region Properties
        public int Id { get; set; }

        public int FK_UserId { get; set; }

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

        [Required(ErrorMessage = "Must not be empty.")]
        public string InvoiceClassNumber
        {
            get
            {
                return GetValue(() => InvoiceClassNumber);
            }

            set
            {
                SetValue(() => InvoiceClassNumber, value);

            }
        }

        [Required(ErrorMessage = "Must not be empty.")]
        public string SupplierInfo
        {
            get
            {
                return GetValue(() => SupplierInfo);
            }

            set
            {
                SetValue(() => SupplierInfo, value);

            }
        }



        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public string Amount
        {
            get
            {
                return GetValue(() => Amount);
            }

            set
            {
                SetValue(() => Amount, value);

            }
        }
        #endregion

        #region Events

        public event Action<IngoingInvoice> Closed;
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

        public AddIngoingInvoiceViewModel()
        {
            okCommand = new DelegateCommand(SaveIngoingInvoice);
            cancelCommand = new DelegateCommand(CancelAddExpenditure);
            Init();

        }
        #endregion

        public void CancelAddExpenditure()
        {
            IngoingInvoice inv = null;
            if (Closed != null)
            {

                Closed(inv);
            }
        }
       

        public void SaveIngoingInvoice() 
        {
            
            if (Closed != null)
            {
                var _ingoingInvoice = new IngoingInvoice()
                {
                    
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

        public void Init() 
        {
            this.Date = DateTime.Now;
        }

    }
}
