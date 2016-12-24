using AccountingWPF.Models;
using AccountingWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Factories
{
	public abstract class AnnualReportFactory
	{
		public virtual int ReportYear { get; set; }
		public virtual User _User { get; set; }

		public virtual List<Expenditure> expenditures { get; set; }
		public virtual List<Receipt> receipts { get; set; }

		public virtual MonateryFlowCRUD<Expenditure> expenditureRepository { get; set; }
		public virtual MonateryFlowCRUD<Receipt> receiptRepository { get; set; }

		public abstract byte[] Create();
	}
}
