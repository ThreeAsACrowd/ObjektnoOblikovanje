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
    public class IngoingInvoiceController : Controller
    {
        //
        // GET: /IngoingInvoice/
        public ActionResult Index()
        {
			IngoingInvoiceRepository<IngoingInvoice> repo = new IngoingInvoiceRepository<IngoingInvoice>();
			IList<IngoingInvoice> ingoingInvoices = repo.getByUserId(UserManager.CurrentUser.Id);

            return View(ingoingInvoices);
        }

        //
        // GET: /IngoingInvoice/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IngoingInvoice/Create
        [HttpPost]
        public ActionResult Create(IngoingInvoice ingoingInvoice)
        {
            try
            {
                // TODO: Add insert logic here
				IngoingInvoiceRepository<IngoingInvoice> repo = new IngoingInvoiceRepository<IngoingInvoice>();
				ingoingInvoice.FK_UserId = UserManager.CurrentUser.Id;
				repo.Create(ingoingInvoice);
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
			IngoingInvoiceRepository<IngoingInvoice> repo = new IngoingInvoiceRepository<IngoingInvoice>();
			IngoingInvoice ingoingInvoice = repo.GetById(id);

            return View(ingoingInvoice);
        }

        //
        // POST: /IngoingInvoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IngoingInvoice ingoingInvoice)
        {
            try
            {
                // TODO: Add update logic here
				IngoingInvoiceRepository<IngoingInvoice> repo = new IngoingInvoiceRepository<IngoingInvoice>();
				repo.Update(ingoingInvoice);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // POST: /IngoingInvoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
				IngoingInvoiceRepository<IngoingInvoice> repo = new IngoingInvoiceRepository<IngoingInvoice>();
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
