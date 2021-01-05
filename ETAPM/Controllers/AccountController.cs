using ETAPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ETAPM.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult MyProfile()
        {
            AppUser user = db.AppUsers.Where(u => u.EmailId == User.Identity.Name).FirstOrDefault();
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SignIn sign)
        {
            AppUser user = db.AppUsers.Where(u => u.EmailId == sign.Username && u.Password == sign.Password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.Message = "Enter valid email and password";
                return View(sign);
            }

            FormsAuthentication.SetAuthCookie(sign.Username, sign.KeepMeLogin);

            return RedirectToAction("", "Dashboard");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}