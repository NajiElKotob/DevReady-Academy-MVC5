using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevReadyAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }

        public int CourseNumber { get; set; } // e.g. 20778

        [StringLength(1)]
        public string CourseVersion { get; set; } // e.g. A, B, C, etc.
        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        
    }
}