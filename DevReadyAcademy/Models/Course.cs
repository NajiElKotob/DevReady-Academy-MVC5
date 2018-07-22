using System.Collections.Generic;

namespace DevReadyAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        
    }
}