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
        //
        // GET: /Expenditure/
        public ActionResult Index()
        {
			ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>(AccountingWeb.Database.SessionManager.SessionFactory);
			IList<Expenditure> expenditures = repo.getByUserId(UserManager.CurrentUser.Id);
			expenditures = expenditures.OrderByDescending(x => x.Date).ToList();
			expenditures.Add(new Expenditure()
			{
				Id = 1,
				Vat = new Vat() { Id = 1, Name="Mock VAT", Percentage=13 },
				Date = DateTime.Now,
				AmountCash = "100,00",
				AmountNonCashBenefit = "0,00",
				AmountTransferAccount = "0,00",
				FK_UserId = 1,
				Total = "100,00",
				Article22 = "0,00",
				JournalEntryNum = "mock expenditure",
				FK_VAT = 1
			});
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
			//ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
			//Expenditure expenditure = repo.GetById(id);

			//VatRepository vatRepo = new VatRepository(AccountingWeb.Database.SessionManager.SessionFactory);
			//List<Vat> vats = vatRepo.getAll().ToList();

			ExpenditureBindingModel expenditureBM = new ExpenditureBindingModel() { 
				Expenditure = new Expenditure(){
					Id = 1,
					Vat = new Vat() { Id = 1, Name="Mock VAT", Percentage=13 },
					Date = DateTime.Now,
					AmountCash = "100,00",
					AmountNonCashBenefit = "0,00",
					AmountTransferAccount = "0,00",
					FK_UserId = 1,
					Total = "100,00",
					Article22 = "0,00",
					JournalEntryNum = "mock expenditure",
					FK_VAT = 1
				},
				VATs = new List<Vat>()
				{
					new Vat(){ Id = 1, Name="Mock VAT1", Percentage=13 },
					new Vat(){ Id = 2, Name="Mock VAT2", Percentage=14 },
					new Vat(){ Id = 3, Name="Mock VAT3", Percentage=16 }
				}
			};
			
            return View(expenditureBM);
        }

        //
        // POST: /Expenditure/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExpenditureBindingModel expenditureBM)
        {
            try
            {
                // TODO: Add update logic here
				//ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
				//repo.Update(expenditureBM.Expenditure);

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
                // TODO: Add delete logic here
				//ExpenditureRepository<Expenditure> repo = new ExpenditureRepository<Expenditure>();
				//repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
