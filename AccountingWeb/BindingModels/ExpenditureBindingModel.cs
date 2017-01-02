using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingWeb.BindingModels
{
	public class ExpenditureBindingModel
	{
		public Expenditure Expenditure { get; set; }
		public List<Vat> VATs { get; set; }
	}
}