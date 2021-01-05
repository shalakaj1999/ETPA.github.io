using ETAPM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETAPM.Controllers
{
    public class ExtraTimeRequestsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            AppUser LoggedUser = db.AppUsers.Where(u => u.EmailId == User.Identity.Name).FirstOrDefault();

            var request = from r in db.ExtraTimeRequests
                          join t in db.Tasks on r.TaskId equals t.TaskId
                          where t.AssignedByAppUserId == LoggedUser.AppUserId && r.RequestStatusId == 1
                          select r; 

            return View(request.ToList());
        }

        [HttpPost]
        public ActionResult AcceptExtraTimeRequest(int? ExtraTimeRequestId)
        {
            if (ModelState.IsValid)
            {
                ExtraTimeRequest request = db.ExtraTimeRequests.Find(ExtraTimeRequestId);

                if (request == null)
                    return Json(new { status = "error", message = "Request not found." }, JsonRequestBehavior.AllowGet);

                Task task = db.Tasks.Find(request.TaskId);

                request.RequestStatusId = 2;
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();

                task.Duration += request.Duration;
                task.EndDateTime = task.EndDateTime.AddMinutes(request.Duration);
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();


                Notification notification = new Notification
                {
                    TypeId = 2,
                    DataId = request.TaskId,
                    IsRead = false,
                    NotificationToAppUserId = task.AssignedToAppUserId,
                    Message = string.Format("Your request is accepted for extra time for {0}", task.Title),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                db.Notifications.Add(notification);
                db.SaveChanges();

                return Json(new { status = "ok", data = request, message = "Your request is accepted for extra time." }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { status = "error", message = "Data validation faild." }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RejectExtraTimeRequest(int? ExtraTimeRequestId)
        {
            if (ModelState.IsValid)
            {
                ExtraTimeRequest request = db.ExtraTimeRequests.Find(ExtraTimeRequestId);

                if (request == null)
                    return Json(new { status = "error", message = "Request not found." }, JsonRequestBehavior.AllowGet);

                Task task = db.Tasks.Find(request.TaskId);

                request.RequestStatusId = 3;
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();  

                Notification notification = new Notification
                {
                    TypeId = 2,
                    DataId = request.TaskId,
                    IsRead = false,
                    NotificationToAppUserId = task.AssignedToAppUserId,
                    Message = string.Format("Your request is rejected for extra time for {0}", task.Title),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                db.Notifications.Add(notification);
                db.SaveChanges();

                return Json(new { status = "ok", data = request, message = "Your request is rejected for extra time." }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { status = "error", message = "Data validation faild." }, JsonRequestBehavior.AllowGet);
        }
    }
}