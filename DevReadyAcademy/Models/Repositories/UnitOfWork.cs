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
        public readonly ApplicationDbContext _context; //Make it private in Production

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new CategoryRepository(_context);
            Courses = new CourseRepository(_context);
            Students = new StudentRepository(_context);

            //...

            _context.Database.Log = Console.WriteLine;
        }

        public ICategoryRepository Categories { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }



        //...

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}