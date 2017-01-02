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
		//
		// GET: /receipt/
		public ActionResult Index()
		{
			ReceiptRepository<Receipt> repo = new ReceiptRepository<Receipt>();
			IList<Receipt> receipts = repo.getByUserId(UserManager.CurrentUser.Id);
			receipts = receipts.OrderByDescending(x => x.Date).ToList();

			return View(receipts);
		}

		//
		// GET: /receipt/Create
		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /receipt/Create
		[HttpPost]
		public ActionResult Create(Receipt receipt)
		{
			try
			{
				// TODO: Add insert logic here
				ReceiptRepository<Receipt> repo = new ReceiptRepository<Receipt>();
				receipt.FK_UserId = UserManager.CurrentUser.Id;
				repo.Create(receipt);

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
			ReceiptRepository<Receipt> repo = new ReceiptRepository<Receipt>();
			Receipt receipt = repo.GetById(id);
			return View(receipt);
		}

		//
		// POST: /receipt/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Receipt receipt)
		{
			try
			{
				// TODO: Add update logic here
				ReceiptRepository<Receipt> repo = new ReceiptRepository<Receipt>();
				repo.Update(receipt);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// POST: /receipt/Delete/5
		[HttpPost]
		public ActionResult Delete(int id)
		{
			try
			{
				// TODO: Add delete logic here
				ReceiptRepository<Receipt> repo = new ReceiptRepository<Receipt>();
				repo.Delete(id);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
    }
}
