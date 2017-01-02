using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingWeb.BindingModels
{
	public class ReportBindingModel
	{
		public List<int> ActiveYears { get; set; }
		public int SelectedYear { get; set; }
	}
}