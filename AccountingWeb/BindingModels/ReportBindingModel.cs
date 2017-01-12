using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountingWeb.BindingModels
{
	public class ReportBindingModel
	{
		public List<int> ActiveYears { get; set; }

		[Display(Name="Select a report year")]
		public int SelectedYear { get; set; }

		public ReportBindingModel()
		{
			ActiveYears = new List<int>();
		}
	}
}