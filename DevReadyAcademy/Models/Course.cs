using DevReadyAcademy.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevReadyAcademy.Models
{
    public class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

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

        [NegativeValuesNotAllowed]
        [Display(Name = "Hours")]
        public int TotalHours { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Publish Date")]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Activation Date")]
        public DateTime? FirstActivationDate { get; set; }

        //[Display(Name = "Discontinued")]
        //public bool IsDiscontinued { get; set; }

        public virtual IEnumerable<Enrollment> Enrollments { get; set; }


        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


        //Unmapped Methods

        [Display(Name = "Code")]
        [NotMapped]
        public string CourseCode { get {
                return $"{CourseNumber}-{CourseVersion}";
            } }
    }
}