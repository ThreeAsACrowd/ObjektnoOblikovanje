using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Repositories;
using AccountingWPF.Factories;
using AccountingWPF.Models;
using AccountingWPF.BaseLib;


namespace AccountingWPF.ViewModels
{
    public class MonetaryFlowReportViewModel
    {
        public IList<int> ActiveYears { get; set; }
        public int SelectedYear { get; set; }

        private MonetaryFlowRepository<Expenditure> expenditureRepository { get; set; }
        private MonetaryFlowRepository<Receipt> receiptRepository { get; set; }

        private MonetaryFlowReportFactory reportFactory;

        public MonetaryFlowReportViewModel()
        {

            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            ActiveYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);

			SelectedYear = ActiveYears.FirstOrDefault();
        }

        public void CreateReport(string filepath)
        {
            reportFactory = new MonetaryFlowHTMLFactory(UserManager.CurrentUser.Id, SelectedYear);
            using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
            {
                writer.Write(reportFactory.Create());
				writer.Flush();
            }

        }



    }
}
