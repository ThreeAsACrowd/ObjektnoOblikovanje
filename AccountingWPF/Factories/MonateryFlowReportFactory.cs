using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.Repositories;

namespace AccountingWPF.Factories
{
	public abstract class MonateryFlowReportFactory
	{
		public virtual int ReportYear { get; set; }
		public virtual int UserId { get; set; }

		public virtual List<MonateryFlow> monateryFlow { get; set; }

		public virtual MonateryFlowRepository<Expenditure> expenditureRepository { get; set; }
		public virtual MonateryFlowRepository<Receipt> receiptRepository { get; set; }

		public abstract byte[] Create();


	}
}
