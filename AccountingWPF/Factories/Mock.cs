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
            FoodVAT foodVat = new FoodVAT();
            DrinkVAT drinkVat = new DrinkVAT();
            List<VAT> vats = new List<VAT>();
            vats.Add(foodVat);
            vats.Add(drinkVat);
            return vats;
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


        private static Expenditure getExpenditure(int i)
        {
            Expenditure expenditure = new Expenditure();
            expenditure.AmountCash = "12";
            expenditure.AmountNonCashBenefit = "10";
            expenditure.Article22 = "" + i;
            expenditure.Date = DateTime.Now;
            expenditure.FK_VAT = getVat().Id;
            expenditure.JournalEntryNum = "1";
            expenditure.Total = "30";
            expenditure.FK_UserId = getUser().Id;
            return expenditure;
        }

        static VAT getVatById(int vatId)
        {
            return new DrinkVAT();
        }

        static VAT getVat()
        {
            return new DrinkVAT();
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
