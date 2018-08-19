using DevReadyAcademy.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context)
            : base(context)
        {
        }


        public ApplicationDbContext AppContext
        {
            get { return base.Context as ApplicationDbContext; }
        }

        public IEnumerable<Course> GetActiveStudents()
        {
            //return AppContext.Students.Where(s => s.LastName == "").ToList();
           return null;
        }
    }
}