using AccountingWPF.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
    public abstract class MonateryFlow : PropertyChangedNotification
    {

        public virtual int Id {
            get {
                return GetValue(() => Id);
            }
            set {
                SetValue(() => Id, value);
            }
        }

        public virtual int FK_VAT {
            get {
                return GetValue(() => FK_VAT);
            }
            set {
                SetValue(() => FK_VAT, value);
            }
        }

        public virtual Vat Vat {
            get {
                return GetValue(() => Vat);
            }
            set {
                SetValue(() => Vat, value);
            }
        }

        public virtual int FK_UserId {
            get {
                return GetValue(() => FK_UserId);
            }
            set {
                SetValue(() => FK_UserId, value);
            }
        }

        public virtual User User {
            get {
                return GetValue(() => User);
            }
            set {
                SetValue(() => User, value);
            }
        }

        public virtual DateTime Date {
            get {
                return GetValue(() => Date);
            }
            set {
                SetValue(() => Date, value);
            }
        }

        public virtual string JournalEntryNum {
            get {
                return GetValue(() => JournalEntryNum);
            }
            set {
                SetValue(() => JournalEntryNum, value);
            }
        }

        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string AmountCash {
            get {
                return GetValue(() => AmountCash);
            }
            set {
                SetValue(() => AmountCash, value);
            }
        }

        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string AmountTransferAccount {
            get {
                return GetValue(() => AmountTransferAccount);
            }
            set {
                SetValue(() => AmountTransferAccount, value);
            }
        }

        [RegularExpression(@"[0-9]{1,8}\,[0-9]{1,2}", ErrorMessage = "Value must be a decimal number")]
        public virtual string AmountNonCashBenefit {
            get {
                return GetValue(() => AmountNonCashBenefit);
            }
            set {
                SetValue(() => AmountNonCashBenefit, value);
            }
        }

        public virtual string Total {
            get {
                return GetValue(() => Total);
            }
            set {
                SetValue(() => Total, value);
            }
        }
    }
}
