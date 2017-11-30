using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class CustomAccountController : Controller
    {
        ApplicationDbContex context = new ApplicationDbContex();
        IdentityResult result = new IdentityResult();
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            CustomLoginViewMode aLogin = new CustomLoginViewMode();
            return View(aLogin);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(CustomLoginViewMode aLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(aLogin);
            }
            PMS.App_Start.IdentityConfig.ApplicationSignInManager signInManager = Request.GetOwinContext().Get<PMS.App_Start.IdentityConfig.ApplicationSignInManager>();
            SignInStatus sighInStatus = signInManager.PasswordSignIn(aLogin.Email, aLogin.Passwod, false, false);
            switch (sighInStatus)
            {
                case SignInStatus.Success:
                    return Redirect("/");
                default:
                    ModelState.AddModelError("", "Invalid Attempt");
                    return View(aLogin);
            }
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterViewModel aRegister = new RegisterViewModel();
            return View(aRegister);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel aRegister)
        {
            PMS.App_Start.IdentityConfig.ApplicationUserManager userManager = Request.GetOwinContext().Get<PMS.App_Start.IdentityConfig.ApplicationUserManager>();
            ApplicationUser user = new ApplicationUser()
            {
                UserName = aRegister.UserName,
                PasswordHash = new PasswordHasher().HashPassword(aRegister.Password),
                Email = aRegister.UserName
            };
            IdentityResult result = userManager.Create(user);
            if (result.Succeeded)
            {
                PMS.App_Start.IdentityConfig.ApplicationSignInManager signInManager = Request.GetOwinContext().Get<PMS.App_Start.IdentityConfig.ApplicationSignInManager>();
                signInManager.SignIn(user, false, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string error_message = "";
                var errors = result.Errors.ToList();
                foreach (var aError in errors)
                {
                    error_message = error_message + aError.ToString();
                }
                ViewBag.error_message = error_message;
                return View(aRegister);
            }
            return View(aRegister);
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("/");
        }
	}
}