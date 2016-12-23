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


		public List<int> ActiveYears { get; set; }
		public int SelectedYear { get; set; }

        private MonateryFlowCRUD<Expenditure> expenditureRepository { get; set; }
        private MonateryFlowCRUD<Receipt> receiptRepository { get; set; }

        private MonateryFlowReportFactory reportFactory;

		public MonateryFlowReportViewModel()
		{
			//UNCOMMENT WHEN THE REPOS ARE READY
			//ActiveYears = expenditureRepository.getActiveYears();
			//ActiveYears.AddRange(receiptRepository.getActiveYears());
			ActiveYears = new List<int>(){2014, 2015, 2016, 2015};
			ActiveYears = ActiveYears.Distinct().ToList();
			SelectedYear = ActiveYears.FirstOrDefault();
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
