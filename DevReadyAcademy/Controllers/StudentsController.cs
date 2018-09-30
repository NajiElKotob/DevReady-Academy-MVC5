using DevReadyAcademy.Models;
using DevReadyAcademy.Models.Repositories;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevReadyAcademy.Controllers
{
    public class StudentsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private UnitOfWork db = new UnitOfWork(new ApplicationDbContext());

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.GetAll());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Get(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            var student = new Student() { RegistrationDate = DateTime.Now };

            return View(student);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, HttpPostedFileBase studentPhoto)
        {
            if (ModelState.IsValid)
            {

                if (studentPhoto != null && studentPhoto.ContentLength > 0)
                {

                    using (var reader = new System.IO.BinaryReader(studentPhoto.InputStream))
                    {
                        student.Photo = reader.ReadBytes(studentPhoto.ContentLength);
                        //Or HttpPostedFileBase Photo = Request.Files["studentPhoto"];

                        student.PhotoType = studentPhoto.ContentType;
                    }
                }


                db.Students.Add(student);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Get(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,RegistrationDate")] Student student, HttpPostedFileBase studentPhoto)
        {
            if (ModelState.IsValid)
            {
                if (studentPhoto != null && studentPhoto.ContentLength > 0)
                {

                    using (var reader = new System.IO.BinaryReader(studentPhoto.InputStream))
                    {
                        student.Photo = reader.ReadBytes(studentPhoto.ContentLength);
                        //Or HttpPostedFileBase Photo = Request.Files["studentPhoto"];

                        student.PhotoType = studentPhoto.ContentType;
                    }
                }

                db.Students.Update(student);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Get(id.Value);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Get(id);
            db.Students.Remove(student);
            db.Save();
            return RedirectToAction("Index");
        }

        public ActionResult CalculateGPA(int id)
        {
            ViewBag.AverageGPA = db.Students.CalculateAvergeGPA(id);
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
