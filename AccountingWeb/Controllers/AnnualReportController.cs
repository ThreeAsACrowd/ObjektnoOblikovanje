using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingWeb.Controllers
{
    public class AnnualReportController : Controller
    {
        //
        // GET: /AnnualReport/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /AnnualReport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AnnualReport/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AnnualReport/Create
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
        // GET: /AnnualReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AnnualReport/Edit/5
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
        // GET: /AnnualReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AnnualReport/Delete/5
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
