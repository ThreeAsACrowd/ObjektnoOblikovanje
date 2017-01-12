using AccountingWeb.BindingModels;
using AccountingWeb.Security;
using DataRepository.Models;
using DataRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingWeb.Controllers
{
    public class ReceiptController : Controller
    {
		private IMonetaryFlowRepository<Receipt> receiptRepository = new ReceiptRepository<Receipt>(AccountingWeb.Database.SessionManager.SessionFactory);
		private IVatRepository vatRepository = new VatRepository(AccountingWeb.Database.SessionManager.SessionFactory);

		//
		// GET: /receipt/
		public ActionResult Index()
		{
			IList<Receipt> receipts = receiptRepository.getByUserId(UserManager.CurrentUser.Id);
			receipts = receipts.OrderByDescending(x => x.Date).ToList();

			return View(receipts);
		}

		//
		// GET: /receipt/Create
		public ActionResult Create()
		{
			Receipt receipt = new Receipt();
			receipt.Date = DateTime.Now;

			List<Vat> vats = vatRepository.getAll().ToList();

			ReceiptBindingModel receiptBM = new ReceiptBindingModel(receipt, vats);
            
			return View(receiptBM);
		}

		//
		// POST: /receipt/Create
		[HttpPost]
		public ActionResult Create(ReceiptBindingModel receiptBM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					receiptBM.Receipt.FK_UserId = UserManager.CurrentUser.Id;
					receiptBM.Receipt.User = UserManager.CurrentUser;
					receiptBM.Receipt.Vat = vatRepository.GetById(receiptBM.Receipt.FK_VAT);
					receiptRepository.Create(receiptBM.Receipt);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /receipt/Edit/5
		public ActionResult Edit(int id)
		{
			Receipt receipt = receiptRepository.GetById(id);

			List<Vat> vats = vatRepository.getAll().ToList();

			ReceiptBindingModel receiptBM = new ReceiptBindingModel(receipt, vats);
			return View(receiptBM);
		}

		//
		// POST: /receipt/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, ReceiptBindingModel receiptBM)
		{
			try
			{
				IEnumerable<ModelError> errors = ModelState.Values.SelectMany(x => x.Errors);
				if (ModelState.IsValid)
				{
					receiptBM.Receipt.Vat = vatRepository.GetById(receiptBM.Receipt.FK_VAT);
					receiptBM.Receipt.FK_UserId = UserManager.CurrentUser.Id;
					receiptBM.Receipt.User = UserManager.CurrentUser;
					receiptRepository.Update(receiptBM.Receipt);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// POST: /receipt/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				receiptRepository.Delete(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
    }
}
