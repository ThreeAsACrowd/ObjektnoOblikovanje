using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.Repositories;

namespace AccountingWPF.Factories
{
	public class MonateryFlowReportFactory
	{
		public int ReportYear { get; set; }
		public int UserId { get; set; }

		private List<MonateryFlow> monateryFlow { get; set; }

		public MonateryFlowReportFactory(int userId, int reportYear)
		{
			ReportYear = reportYear;
			UserId = userId;


		}

		public string generateInHTML()
		{
			return null;
		}


	}
}
