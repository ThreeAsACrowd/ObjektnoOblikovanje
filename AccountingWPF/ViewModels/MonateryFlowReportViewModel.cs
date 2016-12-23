using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Repositories;
using AccountingWPF.Factories;

namespace AccountingWPF.ViewModels
{
	public class MonateryFlowReportViewModel
	{

		public List<int> ActiveYears { get; set; }

		private ExpenditureRepository expenditureRepository { get; set; }
		private ReceiptRepository receiptRepository { get; set; }

		private MonateryFlowReportFactory reportFactory;

		public MonateryFlowReportViewModel()
		{
			//UNCOMMENT WHEN THE REPOS ARE READY
			//ActiveYears = expenditureRepository.getActiveYears();
			//ActiveYears.AddRange(receiptRepository.getActiveYears());
			ActiveYears = new List<int>(){2014, 2015, 2016, 2015};
			ActiveYears = ActiveYears.Distinct().ToList();
		}

		public void getReport()
		{
			string	fileText = "<html><table border=\"1\">";
			fileText += "<tr><th rowspan = \"2\">Redni broj</th><th rowspan = \"2\">Broj temeljnice</th><th rowspan = \"2\">Datum</th><th colspan = \"5\" rowspan = \"1\">Primici</th><th colspan = \"6\" rowspan = \"1\">Izdaci</th></tr>";
			fileText += "<tr><th>U gotovini</th><th>U naravi</th><th>Na žiro-račun</th><th>PDV</th><th>Ukupno</th><th>U gotovini</th><th>U naravi</th><th>Na žiro-račun</th><th>Članak 22</th><th>PDV</th><th>Ukupno</th></tr>";
		}



	}
}
