using DevReadyAcademy.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public int CalculateAvergeGPA(int studentId)
        {
            SqlParameter paramStudentId = new SqlParameter("@StudentId", studentId);
            var averageGPA = AppContext.Database.SqlQuery<int>("usp_CalculateAverageGPA @StudentId",
                                                                paramStudentId).SingleOrDefault();
            return averageGPA;
        }

        public IEnumerable<Student> GetActiveStudents()
        {
            //return AppContext.Students.Where(s => s.LastName == "").ToList();
           return null;
        }

     
    }
}