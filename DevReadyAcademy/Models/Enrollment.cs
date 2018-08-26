using DevReadyAcademy.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevReadyAcademy.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [NegativeValuesNotAllowed]
        public int Grade { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}