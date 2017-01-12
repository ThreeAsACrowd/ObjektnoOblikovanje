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
    public class IngoingInvoiceController : Controller
    {
		private IInvoiceRepository<IngoingInvoice> ingoingInvoiceRepository = new IngoingInvoiceRepository<IngoingInvoice>(SessionManager.SessionFactory);

        //
        // GET: /IngoingInvoice/
        public ActionResult Index()
        {
			IList<IngoingInvoice> ingoingInvoices = ingoingInvoiceRepository.getByUserId(UserManager.CurrentUser.Id);
			ingoingInvoices = ingoingInvoices.OrderByDescending(x => x.Date).ToList();
            return View(ingoingInvoices);
        }

        //
        // GET: /IngoingInvoice/Create
        public ActionResult Create()
        {
			IngoingInvoice ingoingInvoice = new IngoingInvoice();
			ingoingInvoice.Date = DateTime.Now;

            return View(ingoingInvoice);
        }

        //
        // POST: /IngoingInvoice/Create
        [HttpPost]
        public ActionResult Create(IngoingInvoice ingoingInvoice)
        {
            try
            {
				if (ModelState.IsValid)
				{
					ingoingInvoice.FK_UserId = UserManager.CurrentUser.Id;
					ingoingInvoice.User = UserManager.CurrentUser;
					ingoingInvoiceRepository.Create(ingoingInvoice);
				}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /IngoingInvoice/Edit/5
        public ActionResult Edit(int id)
        {
            IngoingInvoice ingoingInvoice = ingoingInvoiceRepository.GetById(id);

            return View(ingoingInvoice);
        }

        //
        // POST: /IngoingInvoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IngoingInvoice ingoingInvoice)
        {
            try
            {
				if (ModelState.IsValid)
				{
					ingoingInvoice.FK_UserId = UserManager.CurrentUser.Id;
					ingoingInvoice.User = UserManager.CurrentUser;
					ingoingInvoiceRepository.Update(ingoingInvoice);
				}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // POST: /IngoingInvoice/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
				ingoingInvoiceRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
