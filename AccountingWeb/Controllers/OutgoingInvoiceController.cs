using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository.Models;
using DataRepository.Repositories;
using AccountingWeb.Security;
using AccountingWeb.Database;

namespace AccountingWeb.Controllers
{
    public class OutgoingInvoiceController : Controller
    {
		private IInvoiceRepository<OutgoingInvoice> outgoingInvoiceRepository = new OutgoingInvoiceRepository<OutgoingInvoice>(SessionManager.SessionFactory);

		//
		// GET: /OutgoingInvoice/
		public ActionResult Index()
		{
			IList<OutgoingInvoice> outgoingInvoices = outgoingInvoiceRepository.getByUserId(UserManager.CurrentUser.Id);
			outgoingInvoices = outgoingInvoices.OrderByDescending(x => x.Date).ToList();
			return View(outgoingInvoices);
		}

		//
		// GET: /OutgoingInvoice/Create
		public ActionResult Create()
		{
			OutgoingInvoice outgoingInvoice = new OutgoingInvoice();
			outgoingInvoice.Date = DateTime.Now;

			return View(outgoingInvoice);
		}

		//
		// POST: /OutgoingInvoice/Create
		[HttpPost]
		public ActionResult Create(OutgoingInvoice outgoingInvoice)
		{
			try
			{
				if (ModelState.IsValid)
				{
					outgoingInvoice.FK_UserId = UserManager.CurrentUser.Id;
					outgoingInvoice.User = UserManager.CurrentUser;
					outgoingInvoiceRepository.Create(outgoingInvoice);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /OutgoingInvoice/Edit/5
		public ActionResult Edit(int id)
		{
			OutgoingInvoice outgoingInvoice = outgoingInvoiceRepository.GetById(id);

			return View(outgoingInvoice);
		}

		//
		// POST: /OutgoingInvoice/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, OutgoingInvoice outgoingInvoice)
		{
			try
			{
				if (ModelState.IsValid)
				{
					outgoingInvoice.FK_UserId = UserManager.CurrentUser.Id;
					outgoingInvoice.User = UserManager.CurrentUser;
					outgoingInvoiceRepository.Update(outgoingInvoice);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		//
		// POST: /OutgoingInvoice/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				outgoingInvoiceRepository.Delete(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
    }
}
