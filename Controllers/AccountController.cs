using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Auth_Forms.Models;

namespace Auth_Forms.Controllers
{
    public class AccountController : Controller
    {
        private UserContext context = new UserContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = context.Users
               .Any(u => u.Email.ToLower() == user
               .Email.ToLower() && u
               .Password.ToLower() == user.Password.ToLower());

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return RedirectToAction("Index", "Item");
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }

        public ActionResult Customer_Signup()
        {
            return View();
        }
    }
}