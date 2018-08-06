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

        [Display(Name ="Number")]
        public int CourseNumber { get; set; } // e.g. 20778


        [Display(Name = "Version")]
        [StringLength(1)]
        public string CourseVersion { get; set; } = "A"; // e.g. A, B, C, etc.

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(400)]
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }

        [NegativeHoursNotAllowed]
        [Display(Name = "Hours")]
        public int TotalHours { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

       
        public DateTime PublishDate { get; set; }

       
        public DateTime? FirstActivationDate { get; set; }

        
        public DateTime? FirstDeactivationDate { get; set; }

        public virtual IEnumerable<Enrollment> Enrollments { get; set; }


        [Display(Name = "Code")]
        [NotMapped]
        public string CourseCode { get {
                return $"{CourseNumber}-{CourseVersion}";
            } }
    }
}