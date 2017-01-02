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
using DataRepository.Repositories.InvoiceRepository;
using AccountingWeb.Database;

namespace AccountingWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        IUserRepository userRepository;
        public AccountController()
        {
            userRepository = new UserRepository(SessionManager.SessionFactory);
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
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {     
            if (ModelState.IsValid)
            {

                User user = userRepository.GetUserByCredentials(new UserCredentials(model.UserName, model.Password));
                if (user != null)
                {
                    UserManager.LogIn(user);
                    return RedirectToAction("Index", "Home"); // auth succeed 
                }
                else
                {
                    // invalid username or password
					ModelState.AddModelError("", "Invalid Username or Password");
                    return View();
                }
            }
            else
            {
                // username or password not entered
                return View();
            }
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