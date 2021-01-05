using ETAPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETAPM.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNewNotification()
        {
            AppUser LoggedUser = db.AppUsers.Where(u => u.EmailId == User.Identity.Name).FirstOrDefault();

            var noties = db.Notifications.Where(n => n.NotificationToAppUserId == LoggedUser.AppUserId && n.IsRead == false).ToList();
            return Json(noties, JsonRequestBehavior.AllowGet);
        }
    }
}