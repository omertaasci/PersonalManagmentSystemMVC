using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalManagmentSystem.Models.Entity;

namespace PersonalManagmentSystem.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        PersonalManagmentSystemDBEntities db = new PersonalManagmentSystemDBEntities();
        public ActionResult Index()
        {
            return View(db.Tbl_Personel.ToList());
        }


        /*----------- ADD NEW PERSONEL -----------*/
        [HttpGet]
        public ActionResult NewPersonel()
        {
            List<SelectListItem> personelRoleDropDown = (from i in db.Tbl_Role.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = i.RoleName,
                                                            Value = i.RoleID.ToString()
                                                        }).ToList();
            ViewBag.personelRoleDropDown_ViewBag = personelRoleDropDown;

            return View();
        }

        [HttpPost]
        public ActionResult NewPersonel(Tbl_Personel personel)
        {
            var role = db.Tbl_Role.Where(m => m.RoleID == personel.Tbl_Role.RoleID).FirstOrDefault();
            personel.Tbl_Role = role;
            db.Tbl_Personel.Add(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*----------- GET PERSONEL -----------*/
        public ActionResult GetPersonel(int id)
        {
            var findPersonel = db.Tbl_Personel.Find(id);

            List<SelectListItem> personelRoleDropDown = (from i in db.Tbl_Role.ToList()
                                                         select new SelectListItem
                                                         {
                                                             Text = i.RoleName,
                                                             Value = i.RoleID.ToString()
                                                         }).ToList();
            ViewBag.personelRoleDropDown_ViewBag = personelRoleDropDown;

            return View("GetPersonel", findPersonel);
        }

        /*----------- EDIT PERSONEL -----------*/
        public ActionResult EditPersonel(Tbl_Personel personel)
        {
            var findPersonel = db.Tbl_Personel.Find(personel.PersonelID);

            findPersonel.PersonelFirstName = personel.PersonelFirstName;
            findPersonel.PersonelLastName = personel.PersonelLastName;
            findPersonel.PersonelAge = personel.PersonelAge;
            findPersonel.PersonelAddress = personel.PersonelAddress;
            findPersonel.PersonelSalary = personel.PersonelSalary;
            findPersonel.PersonelRole = personel.PersonelRole;

            var role = db.Tbl_Role.Where(m => m.RoleID == personel.Tbl_Role.RoleID).FirstOrDefault();
            findPersonel.PersonelRole = role.RoleID;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        /*----------- DELETE PERSONEL -----------*/
        public ActionResult DeletePersonel(int id)
        {
            var findPersonel = db.Tbl_Personel.Find(id);
            db.Tbl_Personel.Remove(findPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}