using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalManagmentSystem.Models.Entity;

namespace PersonalManagmentSystem.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        PersonalManagmentSystemDBEntities db = new PersonalManagmentSystemDBEntities();
        public ActionResult Index()
        {
            return View(db.Tbl_Role.ToList());
        }

        [HttpGet]
        public ActionResult NewRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewRole(Tbl_Role role)
        {
            db.Tbl_Role.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetRole(int id)
        {
            var findRole = db.Tbl_Role.Find(id);
            return View("GetRole", findRole);
        }

        public ActionResult EditRole(Tbl_Role role)
        {
            var findRole = db.Tbl_Role.Find(role.RoleID);
            findRole.RoleName = role.RoleName;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRole(int id)
        {
            var findRole = db.Tbl_Role.Find(id);
            db.Tbl_Role.Remove(findRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}