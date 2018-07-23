using DevReadyAcademy.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevReadyAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }

        public int CourseNumber { get; set; } // e.g. 20778

        [StringLength(1)]
        public string CourseVersion { get; set; } // e.g. A, B, C, etc.

        [StringLength(100)]
        public string Title { get; set; }

        //[NegativeHoursNotAllowed]
        [Display(Name = "Total Number of Hours")]
        public int TotalHours { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        
    }
}