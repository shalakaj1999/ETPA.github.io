using ETAPM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETAPM.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            AppUser LoggedUser = db.AppUsers.Where(u => u.EmailId == User.Identity.Name).FirstOrDefault();

            var users = db.AppUsers.ToList();
            var tasks = db.Tasks.Where(t=>t.TaskStatusId == 1 && (t.AssignedByAppUserId == LoggedUser.AppUserId || t.AssignedToAppUserId == LoggedUser.AppUserId) ).ToList();

            var hrs = new Dictionary<string, string>();
            var mns = new Dictionary<string, string>();

            for (int i = 0; i < 24; i++)
                hrs.Add(string.Format("{0:00}", i), string.Format("{0:00}", i));

            for (int i = 0; i < 60; i++)
                mns.Add(string.Format("{0:00}", i), string.Format("{0:00}", i));

            ViewBag.StartHours = new SelectList(hrs, "Key", "Value");
            ViewBag.StartMinutes = new SelectList(mns, "Key", "Value");
            ViewBag.AssignedToAppUserId = new SelectList(users, "AppUserId", "UniqueName");
            ViewBag.TaskList = tasks;

            return View();
        }
         
        [HttpPost]
        public ActionResult Create(CreateTask NewTask)
        {
            if (ModelState.IsValid)
            {
                AppUser user = db.AppUsers.Where(u => u.EmailId == User.Identity.Name).FirstOrDefault();

                DateTime startDateTime = NewTask.StartDate.Value.AddHours(NewTask.StartHours).AddMinutes(NewTask.StartMinutes);
                int duration = Convert.ToInt32(NewTask.Duration);
                DateTime endDateTime = startDateTime.AddMinutes(duration);

                Task t = new Task
                {
                    Title = NewTask.Title,
                    Description = NewTask.Description,
                    StartDateTime = startDateTime,
                    Duration = duration,
                    EndDateTime = endDateTime, 
                    Progress = 0,
                    TaskStatusId = 1,
                    ParentTaskId = NewTask.ParentTaskId,
                    AssignedByAppUserId = user.AppUserId,
                    AssignedToAppUserId = NewTask.AssignedToAppUserId,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                db.Tasks.Add(t);
                db.SaveChanges();
                return Json(new { status = "ok", data=t, message = "Task created successfully." }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { status = "error", message = "Data validation faild." }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("", "Tasks");

            Task task = db.Tasks.Find(id);

            if (task == null)
                return RedirectToAction("", "Tasks");

            var users = db.AppUsers.ToList();
            var tasks = db.Tasks.Where(tsk=>tsk.ParentTaskId == task.TaskId).ToList();
            var files = db.TaskFiles.Where(f => f.TaskId == task.TaskId).ToList();


            var hrs = new Dictionary<string, string>();
            var mns = new Dictionary<string, string>();

            for (int i = 0; i < 24; i++)
                hrs.Add(string.Format("{0:00}", i), string.Format("{0:00}", i));

            for (int i = 0; i < 60; i++)
                mns.Add(string.Format("{0:00}", i), string.Format("{0:00}", i));

            ViewBag.StartHours = new SelectList(hrs, "Key", "Value");
            ViewBag.StartMinutes = new SelectList(mns, "Key", "Value");
            ViewBag.AssignedToAppUserId = new SelectList(users, "AppUserId", "UniqueName");
            ViewBag.TaskList = tasks;
            ViewBag.FilesList = files;

            return View(task);
        }

        [HttpPost]
        public ActionResult UpdateTaskProgress(UpdateTaskProgress NewUpdateTaskProgress)
        {
            if (ModelState.IsValid)
            {
                Task task = db.Tasks.Find(NewUpdateTaskProgress.TaskId);

                if (task == null) 
                    return Json(new { status = "error", message = "Task not found to update." }, JsonRequestBehavior.AllowGet);

                task.Progress = Convert.ToInt32(NewUpdateTaskProgress.Progress);

                if (task.Progress == 100)
                    task.TaskStatusId = 2;

                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { status = "ok", data = task, message = "Task created successfully." }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { status = "error", message = "Data validation faild." }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CreateExtraTimeRequest(CreateExtraTimeRequest NewExtraTimeRequest)
        {
            if (ModelState.IsValid)
            {
                Task task = db.Tasks.Find(NewExtraTimeRequest.TaskId);

                if (task == null)
                    return Json(new { status = "error", message = "Task not found to place extra time requets." }, JsonRequestBehavior.AllowGet);

                ExtraTimeRequest request = new ExtraTimeRequest
                {
                    TaskId = task.TaskId,
                    Duration = Convert.ToInt32(NewExtraTimeRequest.Duration),
                    RequestStatusId = 1,
                    Message = NewExtraTimeRequest.Message,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                db.ExtraTimeRequests.Add(request);
                db.SaveChanges();

                 
                Notification notification = new Notification
                {
                    TypeId = 1,
                    DataId = request.ExtraTimeRequestId,
                    IsRead = false,
                    NotificationToAppUserId = task.AssignedByAppUserId,
                    Message = string.Format("You have requested for extra time for {0} by {1} {2}", task.Title, task.AssignedTo.FirstName, task.AssignedTo.LastName),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };

                db.Notifications.Add(notification);
                db.SaveChanges();

                return Json(new { status = "ok", data = request, message = "Extra time request submited successfully" }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { status = "error", message = "Data validation faild." }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult CreateFiles([Bind(Include = "TaskId,PostedFiles")] TaskFile file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var f in file.PostedFiles)
                    {

                        //Save files
                        string DirPath = Server.MapPath("~/DbContents/Tasks/Files/");
                        if (!Directory.Exists(DirPath))
                            Directory.CreateDirectory(DirPath);

                        string FileExtension = Path.GetExtension(f.FileName);
                        string NewFileName = string.Format("{0}{1}", App.GetShortFileName("FILE"), FileExtension);
                        string NewFullFileName = DirPath + NewFileName;

                        file.FileName = NewFileName;

                        db.TaskFiles.Add(file);
                        db.SaveChanges();

                        f.SaveAs(NewFullFileName);

                    }

                    var files = db.TaskFiles.Where(f => f.TaskId == file.TaskId).Select(f => new {
                        f.TaskFileId,
                        f.TaskId,
                        f.FileName
                    });

                    return Json(new
                    {
                        status = "ok",
                        message = string.Format("{0} files have been uploaded of {1}", file.PostedFiles.Count, file.PostedFiles.Count),
                        data = files
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "Internal server error." + ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { status = "error", message = "Data validation failed. (Insure you have uploaded files having valid sizes.)" }, JsonRequestBehavior.AllowGet);
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