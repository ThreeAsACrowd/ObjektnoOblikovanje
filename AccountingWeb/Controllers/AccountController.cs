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
using Database;

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

            bool isCredentialsFormatValid = ValidationHelper.IsCredentialsValid(model.UserName, model.Password);
            if (isCredentialsFormatValid)
            {

                User user = userRepository.GetUserByCredentials(new UserCredentials(model.UserName, model.Password));
                if (user != null)
                {
                    UserManager.LogIn(user);
                    return RedirectToAction("MyAction"); // auth succeed 
                }
                else
                {
                    // invalid username or password
                    ModelState.AddModelError("", "invalid username or password");
                    return View();
                }
            }
            else
            {
                // username or password is too short
                ModelState.AddModelError("", "Username and password should be minimum " + ValidationHelper.USERNAME_MIN_LENGTH + " characters length");
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