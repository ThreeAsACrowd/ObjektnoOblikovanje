using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Repositories;
using DataRepository.Factories;
using DataRepository.Models;
using AccountingWPF.BaseLib;
using AccountingWPF.Factories;

namespace AccountingWPF.ViewModels
{
    public class MonetaryFlowReportViewModel
    {
        public IList<int> ActiveYears { get; set; }
        public int SelectedYear { get; set; }

        private IMonetaryFlowRepository<Expenditure> expenditureRepository { get; set; }
        private IMonetaryFlowRepository<Receipt> receiptRepository { get; set; }

        private AbstractReport htmlReport;

        public MonetaryFlowReportViewModel()
        {

            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            ActiveYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);

			SelectedYear = ActiveYears.FirstOrDefault();

            htmlReport = new HtmlReport();
        }

        public void CreateReportByYear(string filepath)
        {
            List<MonetaryFlow> monetaryFlow = new List<MonetaryFlow>();
            monetaryFlow.AddRange(expenditureRepository.getUserMonetaryFlowByYear(UserManager.CurrentUser.Id, SelectedYear));
            monetaryFlow.AddRange(receiptRepository.getUserMonetaryFlowByYear(UserManager.CurrentUser.Id, SelectedYear));

            using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
            {
                writer.Write(htmlReport.CreateReportByYear(UserManager.CurrentUser, monetaryFlow));
				writer.Flush();
            }

        }



    }
}
