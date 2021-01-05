using ETAPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETAPM.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            AppUser LoggedUser = db.AppUsers.Where(u => u.EmailId == User.Identity.Name).FirstOrDefault();

            var tasks = db.Tasks.Where(t=>t.AssignedByAppUserId == LoggedUser.AppUserId || t.AssignedToAppUserId == LoggedUser.AppUserId).ToList();

            ViewBag.TotalTask = tasks.Count();
            ViewBag.TotalTaskInProgress = tasks.Count(t=>t.TaskStatusId == 1);
            ViewBag.TotalTaskCompleted = tasks.Count(t => t.TaskStatusId == 2);

            var tasktome = tasks.Where(t => t.AssignedToAppUserId == LoggedUser.AppUserId);
            ViewBag.TaskToMe = tasktome.Count();
            ViewBag.TaskInProgressToMe = tasktome.Count(t => t.TaskStatusId == 1);
            ViewBag.TaskCompletedToMe = tasktome.Count(t => t.TaskStatusId == 2);

            var taskbyme = tasks.Where(t => t.AssignedByAppUserId == LoggedUser.AppUserId);
            ViewBag.TaskByMe = taskbyme.Count();
            ViewBag.TaskInProgressByMe = taskbyme.Count(t => t.TaskStatusId == 1);
            ViewBag.TaskCompletedByMe = taskbyme.Count(t => t.TaskStatusId == 2);

            ViewBag.TaskList = tasks.Where(t=>t.TaskStatusId ==1);
            return View();
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