using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Factories
{
    public static class Mock
    {
        public static IList<VAT> getAllVATs()
        {
            IList<VAT> vats = new List<VAT>();
            for (int i = 0; i < 5; i++)
            {
                vats.Add(getVat(i, "vat" + i, 10 + i + ""));
            }
            return vats;
        }

        private static VAT getVat(int id, String name, String percentage)
        {
            VAT vat = new VAT();
            vat.Id = id;
            vat.Name = name;
            vat.Percentage = percentage;
            return vat;
        }

        public static IList<Expenditure> getExpendituresByUserId(int userId)
        {
            IList<Expenditure> expenditures = new List<Expenditure>();

            for (int i = 0; i < 10; i++)
            {
                expenditures.Add(getExpenditure(i));
            }

            return expenditures;
        }


        public static IList<Receipt> getReceiptsByUserId(int userId)
        {
            IList<Receipt> receipts = new List<Receipt>();

            for (int i = 0; i < 10; i++)
            {
                receipts.Add(getReceipts(i));
            }

            return receipts;
        }

        private static Receipt getReceipts(int i)
        {
            Receipt receipts = new Receipt();
            receipts.AmountCash = i.ToString();
            receipts.AmountNonCashBenefit = "10";
            receipts.AmountTransferAccount = "121";
            receipts.Date = DateTime.Now;
            receipts.FK_VAT = getVat().Id;
            receipts.JournalEntryNum = "1";
            receipts.Total = "30";
            receipts.Vat = getVat();
            receipts.FK_UserId = getUser().Id;
            return receipts;
        }

        private static Expenditure getExpenditure(int i)
        {
            Expenditure expenditure = new Expenditure();
            expenditure.AmountCash = i.ToString();
            expenditure.AmountNonCashBenefit = "10";
            expenditure.AmountTransferAccount = "321";
            expenditure.Article22 = "" + i;
            expenditure.Date = DateTime.Now;
            expenditure.FK_VAT = getVat().Id;
            expenditure.JournalEntryNum = "1";
            expenditure.Total = "30";
            expenditure.Vat = getVat();
            expenditure.FK_UserId = getUser().Id;
            return expenditure;
        }

        static VAT getVatById(int vatId)
        {
            return getVat();
        }
        static VAT getVat()
        {
            VAT vv = new VAT();
            vv.Name = "Racunalna oprema vat";
            vv.Percentage = "9";
            return vv;
        }


        public static User getUser()
        {
            User user = new User();
            user.Username = "marko";
            user.Password = "pass";
            user.OIB = "123141";
            user.Address = "Unska 3";
            user.Email = "mojemail@email.com";
            user.AssociationName = "udruga";

            return user;
        }

    }
}
