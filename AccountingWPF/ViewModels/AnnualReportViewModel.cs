using AccountingWPF.BaseLib;
using AccountingWPF.Factories;
using AccountingWPF.Models;
using AccountingWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.ViewModels
{
	public class AnnualReportViewModel
	{
		public IList<int> ActiveYears { get; set; }
		public int SelectedYear { get; set; }

		private MonateryFlowCRUD<Expenditure> expenditureRepository { get; set; }
		private MonateryFlowCRUD<Receipt> receiptRepository { get; set; }

		private AnnualReportFactory reportFactory;

		public AnnualReportViewModel()
		{
			expenditureRepository = new ExpenditureRepository<Expenditure>();
			receiptRepository = new ReceiptRepository<Receipt>();

			ActiveYears = receiptRepository.getAvailableYearsByUserId(UserManager.CurrentUser.Id);

			SelectedYear = ActiveYears.FirstOrDefault();
		}

		public void CreateReport(string filepath)
		{
			reportFactory = new AnnualReportHTMLFactory(UserManager.CurrentUser, SelectedYear);
			using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(System.IO.File.Open(filepath, System.IO.FileMode.OpenOrCreate)))
			{
				writer.Write(reportFactory.Create());
				writer.Flush();
			}

		}
	}
}
