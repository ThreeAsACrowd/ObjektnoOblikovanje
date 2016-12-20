using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Models
{
	public abstract class MonateryFlow
	{
		public int Id { get; private set; }

		public int FK_VAT { get; set; }

		public int FK_UserId { get; set; }

		public DateTime Date { get; set; }

		public string JournalEntryNum { get; set; }

		public string AmountCash { get; set; }

		public string AmountTransferAccount { get; set; }

		public string AmountNonCashBenefit { get; set; }

		public string Total { get; set; }
	}
}
