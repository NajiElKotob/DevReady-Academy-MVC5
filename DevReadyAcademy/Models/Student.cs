using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models
{
    public class Student
    {
        public int Id { get; set; }
         public string FirstMidName { get; set; }
       public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}