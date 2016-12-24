using AccountingWPF.Models;
using AccountingWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingWPF.Factories
{
	public class AnnualReportHTMLFactory:AnnualReportFactory
	{
		public AnnualReportHTMLFactory(User user, int year)
		{
			_User = user;
			ReportYear = year;

			expenditureRepository = new ExpenditureRepository<Expenditure>();
			receiptRepository = new ReceiptRepository<Receipt>();

		}

		public override byte[] Create()
		{
			string associatonName = _User.AssociationName;
			string address = _User.Address;
			string oib = _User.OIB;

			expenditures = expenditureRepository.getByUserId(_User.Id).ToList();
			receipts = receiptRepository.getByUserId(_User.Id).ToList();

			decimal sumReceiptsBefore;
			decimal sumExpendituresBefore;
			

			//calculations for previous years
			sumExpendituresBefore = expenditures.Where(x=>x.Date.Year < ReportYear).Select(x => Convert.ToDecimal(x.Total.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			sumReceiptsBefore = expenditures.Where(x => x.Date.Year < ReportYear).Select(x => Convert.ToDecimal(x.Total.Replace(",", "."))).DefaultIfEmpty(0).Sum();

			//calculations for the selected year
			//receipts
			decimal sumReceiptsCash = receipts.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.AmountCash.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumReceiptsNonBenefit = receipts.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.AmountNonCashBenefit.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumReceiptsTransfer = receipts.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.AmountTransferAccount.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumReceiptsVAT = receipts.Where(x => x.Date.Year == ReportYear).Select(x => (x.Vat.Percentage / 100m) * Convert.ToDecimal(x.Total.Replace(",", "."))).DefaultIfEmpty(0).Sum();

			//expenditures
			decimal sumExpendituresCash = expenditures.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.AmountCash.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumExpendituresNonBenefit = expenditures.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.AmountNonCashBenefit.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumExpendituresTransfer = expenditures.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.AmountTransferAccount.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumExpendituresArticle22 = expenditures.Where(x => x.Date.Year == ReportYear).Select(x => Convert.ToDecimal(x.Article22.Replace(",", "."))).DefaultIfEmpty(0).Sum();
			decimal sumExpendituresVAT = expenditures.Where(x => x.Date.Year == ReportYear).Select(x => (x.Vat.Percentage / 100m) * Convert.ToDecimal(x.Total.Replace(",", "."))).DefaultIfEmpty(0).Sum();

			//totals of just the selected year
			decimal sumReceiptsNow = sumReceiptsCash + sumReceiptsNonBenefit + sumReceiptsTransfer - sumReceiptsVAT;
			decimal sumExpendituresNow = sumExpendituresCash + sumExpendituresNonBenefit + sumExpendituresTransfer - sumExpendituresArticle22 - sumExpendituresVAT;

			//total of all the years before and selected one
			decimal sumReceiptsNowBefore = sumReceiptsNow + sumReceiptsBefore - sumExpendituresBefore;

			//THE ULTIMATE SUM GRAND TOTAL
			decimal sumTotal = sumReceiptsNowBefore - sumExpendituresNow;

			//HTML GENERATION
			string fileText = "";
			//font, encoding and title
			fileText += "<html style=\"font-family:Arial\" ><meta charset=\"UTF-8\"><h2 align = \"center\">PREGLED PRIMITAKA I IZDATAKA ZA <br>" + ReportYear.ToString() + ". GODINU</br></h2>\n";

			//basic association data| name, serial num, etc.
			fileText += "<table align = \"center\">\n";
			fileText += "<tr><td align = \"left\"><b>NAZIV UDRUGE:</b></td><td align = \"center\">" + associatonName + "</td></tr><tr><td align = \"left\"><b>ADRESA:</b></td><td align = \"center\">" + address + "</td></tr><tr><td align = \"left\"><b>OIB:</b></td><td align = \"center\">" + oib + "</td></tr>\n";
			fileText += "</table><br></br>\n";

			//receipts data table
			fileText += "<h3 align = \"center\">A) PRIMICI</h3><table align = \"center\">\n";
			fileText += "<tr><td align = \"left\">U GOTOVINI:</td><td align = \"right\">" + sumReceiptsCash.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">NA ŽIRO RAČUN:</td><td align = \"right\">" + sumReceiptsTransfer.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">U NARAVI:</td><td align = \"right\">" + sumReceiptsNonBenefit.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">PDV:</td><td align = \"right\">" + sumReceiptsVAT.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">UKUPNI PRIMICI:</td><td align = \"right\">" + sumReceiptsNow.ToString() + "</td></tr>\n";
			fileText += "</table><br></br>\n";


			//expenditure data table
			fileText += "<h3 align = \"center\">B) IZDACI</h3><table align = \"center\">\n";
			fileText += "<tr><td align = \"left\">U GOTOVINI:</td><td align = \"right\">" + sumExpendituresCash.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">NA ŽIRO RAČUN:</td><td align = \"right\">" + sumExpendituresTransfer.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">U NARAVI:</td><td align = \"right\">" + sumExpendituresNonBenefit.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">PDV:</td><td align = \"right\">" + sumExpendituresVAT.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">ČLANAK 22 ST 1.:</td><td align = \"right\">" + sumExpendituresArticle22.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">UKUPNI IZDACI:</td><td align = \"right\">" + sumExpendituresNow.ToString() + "</td></tr>\n";
			fileText += "</table><br></br>\n";


			//total table
			fileText += "<table align = \"center\">\n";
			fileText += "<tr><td align = \"left\">UKUPNI PRIMICI:</td><td align = \"right\">" + sumReceiptsNowBefore.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\">UKUPNI IZDACI:</td><td align = \"right\">" + sumExpendituresNow.ToString() + "</td></tr>\n";
			fileText += "<tr><td align = \"left\"><b>DOHODAK<b>:</td><td align = \"right\">" + sumTotal.ToString() + "</td></tr>\n";
			fileText += "</table><br></br>\n";

			//date and signature space; html tab close
			fileText += "<text align = \"left\">" + DateTime.Now.ToString("d.M.yyyy.") + "</text><br></br><text align = \"right\">Potpis ovlaštene osobe:</text>";
			fileText += "</html>";

			//mash it all into bytes
			byte[] fileBytes = Encoding.UTF8.GetBytes(fileText);

			return fileBytes;
		}
	}
}
