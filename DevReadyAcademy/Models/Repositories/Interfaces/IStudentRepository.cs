using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevReadyAcademy.Models.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetActiveStudents();
        int CalculateAvergeGPA(int studentId);
       
    }

}
