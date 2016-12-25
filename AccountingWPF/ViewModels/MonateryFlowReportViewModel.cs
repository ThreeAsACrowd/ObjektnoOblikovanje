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
    public class MonateryFlowReportViewModel
    {
        public IList<int> ActiveYears { get; set; }
        public int SelectedYear { get; set; }

        private MonateryFlowRepository<Expenditure> expenditureRepository { get; set; }
        private MonateryFlowRepository<Receipt> receiptRepository { get; set; }

        private MonateryFlowReportFactory reportFactory;

        public MonateryFlowReportViewModel()
        {

            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            ActiveYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);

			SelectedYear = ActiveYears.FirstOrDefault();
        }

        public void CreateReport(string filepath)
        {
            reportFactory = new MonateryFlowHTMLFactory(UserManager.CurrentUser.Id, SelectedYear);
            using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
            {
                writer.Write(reportFactory.Create());
				writer.Flush();
            }

        }



    }
}
