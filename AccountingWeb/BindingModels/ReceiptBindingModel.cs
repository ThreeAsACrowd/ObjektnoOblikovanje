using DataRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountingWeb.BindingModels
{
	public class ReceiptBindingModel
	{
		[Required]
		public Receipt Receipt { get; set; }

		public List<Vat> VATs { get; set; }

		public ReceiptBindingModel(Receipt receipt, List<Vat> vats)
		{
			Receipt = receipt;
			VATs = vats;
		}

		public ReceiptBindingModel()
		{

		}
	}
}