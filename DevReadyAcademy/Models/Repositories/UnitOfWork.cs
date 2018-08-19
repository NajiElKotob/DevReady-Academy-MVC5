using DevReadyAcademy.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 Usage:
using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
    {
        // Example 1
        var course = unitOfWork.Courses.Get(1);

        // Example 2
        var courses = unitOfWork.Courses.GetActiveCourses();

        // Example 3
        var student = new Student...
        var courses = new List<Course>()...

        unitOfWork.Student.Add(student);
        unitOfWork.Courses.AddRange(courses);
        unitOfWork.Complete();
    }
 */

namespace DevReadyAcademy.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            _context.Database.Log = Console.WriteLine;

            Categories = new CategoryRepository(_context);
            Courses = new CourseRepository(_context);
            Students = new StudentRepository(_context);

            //...
        }

        public ICategoryRepository Categories { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }



     
        public int Save()
        {

            //if (_context.ChangeTracker.HasChanges() == true)
            //{
            //    Courses.RefreshCache();
            //    Categories.RefreshCache();
            //    Students.RefreshCache();
            //}
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}