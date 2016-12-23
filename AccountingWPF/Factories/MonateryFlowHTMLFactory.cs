using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Repositories;
using AccountingWPF.BaseLib;
using AccountingWPF.Models;

namespace AccountingWPF.Factories
{
    public class MonateryFlowHTMLFactory : MonateryFlowReportFactory
    {
        public MonateryFlowHTMLFactory(int userId, int year)
        {
            ReportYear = year;
            UserId = userId;

            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            monateryFlow = new List<MonateryFlow>();
        }

        public override string Create()
        {
            monateryFlow.AddRange(expenditureRepository.getUserMonateryFlowByYear(UserManager.CurrentUser.Id, ReportYear));
            monateryFlow.AddRange(receiptRepository.getUserMonateryFlowByYear(UserManager.CurrentUser.Id, ReportYear));

            monateryFlow = monateryFlow.OrderByDescending(x => x.Date).ToList();

            string fileText = "<html><table border=\"1\">";
            fileText += "<tr><th rowspan = \"2\">Redni broj</th><th rowspan = \"2\">Broj temeljnice</th><th rowspan = \"2\">Datum</th><th colspan = \"5\" rowspan = \"1\">Primici</th><th colspan = \"6\" rowspan = \"1\">Izdaci</th></tr>";
            fileText += "<tr><th>U gotovini</th><th>U naravi</th><th>Na žiro-račun</th><th>PDV</th><th>Ukupno</th><th>U gotovini</th><th>U naravi</th><th>Na žiro-račun</th><th>Članak 22</th><th>PDV</th><th>Ukupno</th></tr>";

            int itemNumber = 0;

            foreach (MonateryFlow item in monateryFlow)
            {
                fileText += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td>", (++itemNumber).ToString(), item.JournalEntryNum, item.Date.ToShortDateString());

                if (item is Receipt)
                {
                    fileText += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>", item.AmountCash, item.AmountNonCashBenefit, item.AmountTransferAccount, item.Vat.Percentage.ToString(), item.Total);
                }

                if (item is Expenditure)
                {
                    fileText += string.Format("<td></td><td></td><td></td><td></td><td></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", item.AmountCash, item.AmountNonCashBenefit, item.AmountTransferAccount, ((Expenditure)item).Article22, item.Vat.Percentage.ToString(), item.Total);
                }
            }

            fileText += "</table></html>";


            return fileText;
        }
    }
}
