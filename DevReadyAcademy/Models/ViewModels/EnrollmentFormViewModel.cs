using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.ViewModels
{
    public class EnrollmentFormViewModel
    {
        public Enrollment Enrollment { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Student> Students { get; set; }

    }
}