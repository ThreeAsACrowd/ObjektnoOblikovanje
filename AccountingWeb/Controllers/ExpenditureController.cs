using DataRepository.Models;
using DataRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingWeb.Security;
using AccountingWeb.Attributes;
using DataRepository.nHibernateDb;
using AccountingWeb.Database;
using AccountingWeb.BindingModels;

namespace AccountingWeb.Controllers
{
	[AccountingAuthorize]
    public class ExpenditureController : Controller
    {
		private IMonetaryFlowRepository<Expenditure> expenditureRepository = new ExpenditureRepository<Expenditure>(AccountingWeb.Database.SessionManager.SessionFactory);
		private IVatRepository vatRepository = new VatRepository(AccountingWeb.Database.SessionManager.SessionFactory);
        //
        // GET: /Expenditure/
        public ActionResult Index()
        {
			IList<Expenditure> expenditures = expenditureRepository.getByUserId(UserManager.CurrentUser.Id);
			expenditures = expenditures.OrderByDescending(x => x.Date).ToList();

			return View(expenditures);
        }

        //
        // GET: /Expenditure/Create
        public ActionResult Create()
        {
			Expenditure expenditure = new Expenditure();
			expenditure.Date = DateTime.Now;

			List<Vat> vats = vatRepository.getAll().ToList();

			ExpenditureBindingModel expenditureBM = new ExpenditureBindingModel(expenditure, vats);
            
			return View(expenditureBM);
        }

        //
        // POST: /Expenditure/Create
        [HttpPost]
        public ActionResult Create(ExpenditureBindingModel expenditureBM)
        {
            try
            {
                // TODO: Add insert logic here
				if (ModelState.IsValid)
				{
					expenditureBM.Expenditure.FK_UserId = UserManager.CurrentUser.Id;
					expenditureBM.Expenditure.User = UserManager.CurrentUser;
					expenditureBM.Expenditure.Vat = vatRepository.GetById(expenditureBM.Expenditure.FK_VAT);
					expenditureRepository.Create(expenditureBM.Expenditure);
				}

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
			Expenditure expenditure = expenditureRepository.GetById(id);

			List<Vat> vats = vatRepository.getAll().ToList();

			ExpenditureBindingModel expenditureBM = new ExpenditureBindingModel(expenditure, vats);
			
            return View(expenditureBM);
        }

        //
        // POST: /Expenditure/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExpenditureBindingModel expenditureBM)
        {
            try
            {
				if(ModelState.IsValid)
				{
					expenditureBM.Expenditure.FK_UserId = UserManager.CurrentUser.Id;
					expenditureBM.Expenditure.User = UserManager.CurrentUser;
					expenditureBM.Expenditure.Vat = vatRepository.GetById(expenditureBM.Expenditure.FK_VAT);
					expenditureRepository.Update(expenditureBM.Expenditure);
				}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Expenditure/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
				expenditureRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
