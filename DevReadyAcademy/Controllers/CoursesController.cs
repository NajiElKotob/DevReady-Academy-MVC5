using AutoMapper;
using DevReadyAcademy.Models;
using DevReadyAcademy.Models.Constants;
using DevReadyAcademy.Models.DTOs;
using DevReadyAcademy.Models.Repositories;
using DevReadyAcademy.Models.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DevReadyAcademy.Controllers
{
    public class CoursesController : Controller
    {
        //Constants
        private const string CourseFormConst = "CourseForm";
        private const string CoursesConst = "Courses";
        private const string IndexConst = "Index";


        //private ApplicationDbContext context = new ApplicationDbContext();

        private UnitOfWork unitOfWork = new UnitOfWork(new ApplicationDbContext());

        // GET: Courses
        [AllowAnonymous]
        public ActionResult Index()
        {
            //return View(unitOfWork.Courses.GetAll(true)); //Getting data from Cache

            return View(unitOfWork.Courses.GetAll()); //Getting data directly from Database

        }

        // GET: Courses/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Course course = unitOfWork.Courses.Get(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }


        // GET: Courses/Create
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create()
        {
            ViewBag.ActionTitle = "New Course";

            return View(CourseFormConst, new CourseFormViewModel()
            {
                Course = new Course(),
                Categories = unitOfWork.Categories.GetAll()
            });
        }



        // GET: Courses/Edit/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var courseInDb = unitOfWork.Courses.Get(id.Value);
            if (courseInDb == null)
            {
                return HttpNotFound();
            }

            ViewBag.ActionTitle = $"Edit Course ({courseInDb.CourseCode})";
            return View(CourseFormConst, new CourseFormViewModel()
            {
                Course = courseInDb,
                Categories = unitOfWork.Categories.GetAll()
            });

        }

        // POST: Courses/Save/CourseFormViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save([Bind(Exclude = "PublishDate,FirstActivationDate")]
                                    Course course)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CourseFormViewModel
                {
                    Course = course,
                    Categories = unitOfWork.Categories.GetAll()
                };

                return View(CourseFormConst, viewModel);
            }

            if (course.Id == 0) //New Course
            {
                course.PublishDate = DateTime.Now;

                if (course.IsActive == true)
                {
                    course.FirstActivationDate = DateTime.Now;
                }
                unitOfWork.Courses.Add(course);
            }
            else //Modified Course
            {
                var courseInDb = unitOfWork.Courses.Get(course.Id);
                if (courseInDb == null)
                {
                    return HttpNotFound();
                }

                courseInDb.CourseNumber = course.CourseNumber;
                courseInDb.CourseVersion = course.CourseVersion;
                courseInDb.Description = course.Description;
                courseInDb.TotalHours = course.TotalHours;
                courseInDb.VideoURL = course.VideoURL;
                courseInDb.IsActive = course.IsActive;
                courseInDb.CategoryId = course.CategoryId;

                //TODO: Review the security AND business logic
                if (course.IsActive == true && courseInDb.IsActive == false)
                {
                    courseInDb.FirstActivationDate = DateTime.Now;
                }



               // unitOfWork.Courses.Update(course); //https://msdn.microsoft.com/en-us/library/jj592676%28v=vs.113%29.aspx
            }

            unitOfWork.Save();

            return RedirectToAction(IndexConst, CoursesConst);
        }



        // GET: Courses/Delete/5
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = unitOfWork.Courses.Get(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = unitOfWork.Courses.Get(id);
            unitOfWork.Courses.Remove(course);
            unitOfWork.Save();
            return RedirectToAction(IndexConst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
