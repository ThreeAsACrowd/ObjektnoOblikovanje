using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingWeb.Controllers
{
    public class MonetaryFlowReportController : Controller
    {
        //
        // GET: /MonetaryFlow/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /MonetaryFlow/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MonetaryFlow/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MonetaryFlow/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MonetaryFlow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MonetaryFlow/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MonetaryFlow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MonetaryFlow/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
