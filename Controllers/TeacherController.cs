using Exam.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Exam.Controllers
{
    public class TeacherController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllTeacher()
        {
            //var teachers = new List<Teacher>();
            var teachers = db.Teachers.ToList();
            return PartialView("_ListTeacher", teachers);
        }

        // GET: Teacher/Details/5
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

        // GET: Teacher/Create
        public ActionResult Create()
        {
            ViewBag.IsEdit = false;
            return PartialView("_DetailTeacher", new Teacher());
        }

        // POST: Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Teacher/Edit/5
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

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
