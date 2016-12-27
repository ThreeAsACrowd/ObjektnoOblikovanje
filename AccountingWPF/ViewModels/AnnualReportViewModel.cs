using AccountingWPF.BaseLib;
using AccountingWPF.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Repositories;
using DataRepository.Models;
using DataRepository.Factories;

namespace AccountingWPF.ViewModels
{
    public class AnnualReportViewModel
    {
        public IList<int> ActiveYears { get; set; }
        public int SelectedYear { get; set; }

        private IMonetaryFlowRepository<Expenditure> expenditureRepository { get; set; }
        private IMonetaryFlowRepository<Receipt> receiptRepository { get; set; }

        private AbstractReport htmlReport;

        public AnnualReportViewModel()
        {
            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            ActiveYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);

            SelectedYear = ActiveYears.FirstOrDefault();

            htmlReport = new HtmlReport();
        }

        public void CreateReport(string filepath)
        {
            using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
            {
                writer.Write(htmlReport.Create(UserManager.CurrentUser, SelectedYear, expenditureRepository.getByUserId(UserManager.CurrentUser.Id), receiptRepository.getByUserId(UserManager.CurrentUser.Id)));
                writer.Flush();
            }

        }
    }
}
