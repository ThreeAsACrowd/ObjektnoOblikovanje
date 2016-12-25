using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;
using AccountingWPF.Repositories;

namespace AccountingWPF.Factories
{
	public abstract class MonetaryFlowReportFactory
	{
		public virtual int ReportYear { get; set; }
		public virtual int UserId { get; set; }

		public virtual List<MonetaryFlow> monetaryFlow { get; set; }

		public virtual MonetaryFlowRepository<Expenditure> expenditureRepository { get; set; }
		public virtual MonetaryFlowRepository<Receipt> receiptRepository { get; set; }

		public abstract byte[] Create();


	}
}
