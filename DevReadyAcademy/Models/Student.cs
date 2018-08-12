using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models
{
    public class Student
    {

        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }


        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual IEnumerable<Enrollment> Enrollments { get; set; }

        [Display(Name = "Name")]
        [NotMapped]
        public string FullName {
            get {
                return $"{FirstName} {LastName}";
            }
        }

    }
}