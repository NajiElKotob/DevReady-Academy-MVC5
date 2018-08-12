using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.DTOs
{
    public class CourseDTO
    {

        public int Id { get; set; }

        public int CourseNumber { get; set; } // e.g. 20778

        public string CourseVersion { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TotalHours { get; set; }

        public bool IsActive { get; set; }

        public int CategoryId { get; set; }




    }
}