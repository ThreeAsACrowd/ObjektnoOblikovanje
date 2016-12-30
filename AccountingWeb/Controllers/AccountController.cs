using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using AccountingWeb.Models;
using DataRepository.Repositories;
using DataRepository.Models;
using AccountingWeb.Security;

namespace AccountingWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }


        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
			DBPopulate.DBPopulator db = new DBPopulate.DBPopulator();
			db.populateDatabase();
			UserRepository userRepository = new UserRepository();
			if (Security.UserManager.IsValid(model.UserName, model.Password))
			{
				UserManager.LogIn(model.UserName, model.Password);
				return RedirectToAction("MyAction"); // auth succeed 
			}
			// invalid username or password
			ModelState.AddModelError("", "invalid username or password");
			return View();
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
			UserManager.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}