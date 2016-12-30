using DataRepository.Models;
using DataRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Security;

namespace AccountingWeb.Controllers
{
    public class ExpenditureController : Controller
    {
        //
        // GET: /Expenditure/
        public ActionResult Index()
        {
			ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
			IList<Expenditure> expenditures = repo.getByUserId(UserManager.CurrentUser.Id);

			return View(expenditures);
        }

        //
        // GET: /Expenditure/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Expenditure/Create
        [HttpPost]
        public ActionResult Create(Expenditure expenditure)
        {
            try
            {
                // TODO: Add insert logic here
				ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
				expenditure.FK_UserId = UserManager.CurrentUser.Id;
				repo.Create(expenditure);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Expenditure/Edit/5
        public ActionResult Edit(int id)
        {
			ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
			Expenditure expenditure = repo.GetById(id);
            return View(expenditure);
        }

        //
        // POST: /Expenditure/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Expenditure expenditure)
        {
            try
            {
                // TODO: Add update logic here
				ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
				repo.Update(expenditure);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Expenditure/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
				ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
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
