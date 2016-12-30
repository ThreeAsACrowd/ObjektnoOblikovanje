using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataRepository.Models;
using DataRepository.Repositories;
using AccountingWeb.Security;

namespace AccountingWeb.Controllers
{
    public class OutgoingInvoiceController : Controller
    {
        //
        // GET: /OutgoingInvoice/
        public ActionResult Index()
        {
			OutgoingInvoiceRepository<OutgoingInvoice> repo = new OutgoingInvoiceRepository<OutgoingInvoice>();
			IList<OutgoingInvoice> outgoingInvoices = repo.getByUserId(UserManager.CurrentUser.Id);

            return View(outgoingInvoices);
        }

        //
        // GET: /OutgoingInvoice/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OutgoingInvoice/Create
        [HttpPost]
        public ActionResult Create(OutgoingInvoice outgoingInvoice)
        {
            try
            {
                // TODO: Add insert logic here
				OutgoingInvoiceRepository<OutgoingInvoice> repo = new OutgoingInvoiceRepository<OutgoingInvoice>();
				outgoingInvoice.FK_UserId = UserManager.CurrentUser.Id;
				repo.Create(outgoingInvoice);

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
			OutgoingInvoiceRepository<OutgoingInvoice> repo = new OutgoingInvoiceRepository<OutgoingInvoice>();
			OutgoingInvoice outgoingInvoice = repo.GetById(id);
            return View(outgoingInvoice);
        }

        //
        // POST: /OutgoingInvoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OutgoingInvoice outgoingInvoice)
        {
            try
            {
                // TODO: Add update logic here
				OutgoingInvoiceRepository<OutgoingInvoice> repo = new OutgoingInvoiceRepository<OutgoingInvoice>();
				repo.Update(outgoingInvoice);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // POST: /OutgoingInvoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
				OutgoingInvoiceRepository<OutgoingInvoice> repo = new OutgoingInvoiceRepository<OutgoingInvoice>();
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
