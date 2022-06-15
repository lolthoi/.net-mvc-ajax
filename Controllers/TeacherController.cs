using Exam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Exam.Controllers
{
    public class TeacherController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllTeacher()
        {
            var teachers = db.Teachers.ToList();
            return PartialView("_ListTeacher", teachers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        public ActionResult Create()
        {
            ViewBag.IsEdit = false;
            var fileName = "ActionPlanCostDetail_Color.xml";
            var url = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            var pathCombine = Path.Combine(url, fileName);

            XElement xDocument = XElement.Load(pathCombine);

            var data = xDocument.Descendants("Color").Select(x => new
            {
                Value = x.Attribute("Key").Value,
                Text = x.Attribute("Value").Value,
            }).ToList();

            List<SelectListItem> itemlist = new List<SelectListItem>();

            foreach (var item in data)
            {
                itemlist.Add(new SelectListItem() { Text = item.Text, Value = item.Value });
            }

            ViewBag.Color = itemlist;

            return PartialView("_DetailTeacher", new Teacher());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.IsEdit = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailTeacher", teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(false, "Error: id null", JsonRequestBehavior.AllowGet);
            }

            var teacher = db.Teachers.FirstOrDefault(x => x.Id == id);

            if (teacher == null)
            {
                return Json(false, "Error: Teacher not found", JsonRequestBehavior.AllowGet);
            }

            db.Teachers.Remove(teacher);
            db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
