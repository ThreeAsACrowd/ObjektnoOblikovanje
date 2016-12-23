using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.Repositories;
using AccountingWPF.Repositories.InvoiceRepository;

namespace AccountingWPF.Factories
{
    public static class Mock
    {
        public static IList<VAT> getAllVATs()
        {
            IList<VAT> vats = new List<VAT>();
            for (int i = 0; i < 5; i++)
            {
                vats.Add(getVat("vat" + i, 10 + i));
            }
            return vats;
        }

        private static VAT getVat(String name, int percentage)
        {
            VAT vat = new VAT();
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

        public static IList<IngoingInvoice> getIngoingInvoicesByUserId(int id)
        {
            IList<IngoingInvoice> ingoingInvoices = new List<IngoingInvoice>();

            for (int i = 0; i < 10; i++)
            {
                ingoingInvoices.Add(getIngoingInvoice(i));
            }

            return ingoingInvoices;
        }

        private static IngoingInvoice getIngoingInvoice(int i)
        {
            IngoingInvoice ingoingInvoice = new IngoingInvoice();
            ingoingInvoice.InvoiceClassNumber = "12";
            ingoingInvoice.Amount = "" + i;
            ingoingInvoice.Date = DateTime.Now;
            ingoingInvoice.SupplierInfo = "supplier";
            ingoingInvoice.FK_UserId = getUserFromDb().Id;
            return ingoingInvoice;
        }

        public static IList<OutgoingInvoice> getOutgoingInvoicesByUserId(int id)
        {
            IList<OutgoingInvoice> outgoingInvoices = new List<OutgoingInvoice>();

            for (int i = 0; i < 10; i++)
            {
                outgoingInvoices.Add(getOutgoingInvoice(i));
            }

            return outgoingInvoices;
        }

        private static OutgoingInvoice getOutgoingInvoice(int i)
        {
            OutgoingInvoice outgoingInvoice = new OutgoingInvoice();
            outgoingInvoice.InvoiceClassNumber = "12";
            outgoingInvoice.Amount = "" + i;
            outgoingInvoice.Date = DateTime.Now;
            outgoingInvoice.CustomerInfo = "customer";
            outgoingInvoice.FK_UserId = getUserFromDb().Id;
            return outgoingInvoice;
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
            VATRepository vatRepo = new VATRepository();
            IList<VAT> vats = vatRepo.getAll();

            User u = getUserFromDb();

            Receipt receipts = new Receipt();
            receipts.AmountCash = i.ToString();
            receipts.AmountNonCashBenefit = "10";
            receipts.AmountTransferAccount = "121";
            receipts.Date = DateTime.Now;
            receipts.FK_VAT = vats[0].Id;
            receipts.JournalEntryNum = "1";
            receipts.Total = "30";
            receipts.Vat = vats[0];
            receipts.FK_UserId = u.Id;
            receipts.User = u;
            return receipts;
        }

        private static Expenditure getExpenditure(int i)
        {
            VATRepository vatRepo = new VATRepository();
            IList<VAT> vats = vatRepo.getAll();
            User u = getUserFromDb();

            Expenditure expenditure = new Expenditure();
            expenditure.AmountCash = i.ToString();
            expenditure.AmountNonCashBenefit = "10";
            expenditure.AmountTransferAccount = "321";
            expenditure.Article22 = "" + i;
            expenditure.Date = DateTime.Now;
            expenditure.FK_VAT = vats[1].Id;
            expenditure.JournalEntryNum = "1";
            expenditure.Total = "30";
            expenditure.Vat = vats[1];
            expenditure.FK_UserId = u.Id;
            expenditure.User = u;
            return expenditure;
        }

        public static User getUserFromDb()
        {
            IUserRepository userRepo = new UserRepository();
            return userRepo.GetById(1);
        }



    }
}
