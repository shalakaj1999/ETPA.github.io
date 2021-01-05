using ETAPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETAPM.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.EmployeeList = db.AppUsers.Where(au => au.AppRoleId == 2).ToList();
            return View();
        }

        public ActionResult Create(AppUser employee)
        {
            ModelState.Remove("employee.Password");
            ModelState.Remove("employee.AppRoleId");
            if (ModelState.IsValid)
            {
                employee.Password = "Password";
                employee.AppRoleId = 2;

                db.AppUsers.Add(employee);
                db.SaveChanges();
                return Json(new { status = "ok", data = employee, message = "Employee created successfully." }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { status = "error", message = "Data validation faild." }, JsonRequestBehavior.AllowGet);
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