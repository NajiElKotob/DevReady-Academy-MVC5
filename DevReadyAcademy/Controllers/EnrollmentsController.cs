using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevReadyAcademy.Models;

namespace DevReadyAcademy.Controllers
{
    public class EnrollmentsController : Controller
    {
        private const string EnrollmentFormConst = "EnrollmentForm";
        private const string EnrollmentsConst = "Courses";
        private const string IndexConst = "Index";

        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollments = context.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = context.Enrollments.Include(s => s.Student)
                                                        .Include(c => c.Course)
                                                        .SingleOrDefault(e => e.Id == id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(context.Courses, "Id", "CourseCode");
            ViewBag.StudentId = new SelectList(context.Students, "Id", "FullName");

            ViewBag.ActionTitle = "New Enrollment";
            ViewBag.EditMode = false;

            return View(EnrollmentFormConst);
        }


        // POST: Courses/Save/CourseFormViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "Id,CourseId,StudentId,EnrollmentDate,Grade")]
                                    Enrollment enrollment)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.CourseId = new SelectList(context.Courses, "Id", "CourseCode");
                ViewBag.StudentId = new SelectList(context.Students, "Id", "FullName");

                ViewBag.ActionTitle = enrollment.Id == 0 ? "New Enrollment" : "Edit";
                ViewBag.EditMode = enrollment.Id == 0 ? false : true;

                return View(EnrollmentFormConst, enrollment);
            }

            if (enrollment.Id == 0) //New Enrollment
            {
                enrollment.EnrollmentDate = DateTime.Now;
                enrollment.Grade = 0;
                context.Enrollments.Add(enrollment);
            }
            else //Modified Enrollment
            {

                Enrollment enrollmentInDb = context.Enrollments.Find(enrollment.Id);
                if (enrollmentInDb == null)
                {
                    return HttpNotFound();
                }


                enrollmentInDb.CourseId = enrollment.CourseId;
                enrollmentInDb.StudentId = enrollment.StudentId;
                enrollmentInDb.Grade = enrollment.Grade;
                enrollmentInDb.EnrollmentDate = enrollment.EnrollmentDate;
            }

            context.SaveChanges();

            return RedirectToAction(IndexConst);
        }


        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(context.Courses, "Id", "CourseCode", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(context.Students, "Id", "FullName", enrollment.StudentId);

            ViewBag.EditMode = true;
            ViewBag.Title = "Edit";
            return View(EnrollmentFormConst, enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /* 
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit([Bind(Include = "Id,CourseId,StudentId,EnrollmentDate,Grade")] Enrollment enrollment)
         {
             if (ModelState.IsValid)
             {
                 context.Entry(enrollment).State = EntityState.Modified;
                 context.SaveChanges();
                 return RedirectToAction("Index");
             }
             ViewBag.CourseId = new SelectList(context.Courses, "Id", "CourseCode", enrollment.CourseId);
             ViewBag.StudentId = new SelectList(context.Students, "Id", "FullName", enrollment.StudentId);
             return View(enrollment);
         }
         */

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,StudentId")] Enrollment enrollment)
        {

            if (ModelState.IsValid)
            {
                enrollment.EnrollmentDate = DateTime.Now;

                context.Enrollments.Add(enrollment);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            var errors = ModelState.Select(m => m.Value.Errors)
                           .Where(e => e.Count > 0)
                           .ToList();

            ViewBag.CourseId = new SelectList(context.Courses, "Id", "CourseCode", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(context.Students, "Id", "FullName", enrollment.StudentId);
            return View(enrollment);
        }
        */

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = context.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = context.Enrollments.Find(id);
            context.Enrollments.Remove(enrollment);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
