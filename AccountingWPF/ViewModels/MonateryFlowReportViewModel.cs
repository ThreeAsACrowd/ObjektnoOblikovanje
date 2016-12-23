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

        private MonateryFlowCRUD<Expenditure> expenditureRepository { get; set; }
        private MonateryFlowCRUD<Receipt> receiptRepository { get; set; }

        private MonateryFlowReportFactory reportFactory;

        public MonateryFlowReportViewModel()
        {

            expenditureRepository = new ExpenditureRepository<Expenditure>();
            receiptRepository = new ReceiptRepository<Receipt>();

            ActiveYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);
        }

        public void CreateReport(string filepath)
        {
            reportFactory = new MonateryFlowHTMLFactory(UserManager.CurrentUser.Id, SelectedYear);
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filepath))
            {
                writer.Write(reportFactory.Create());
            }

        }



    }
}
