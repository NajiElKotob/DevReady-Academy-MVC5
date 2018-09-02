using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.DTOs
{
    public class GpaDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CoursesCount { get; set; }
        public int GPA { get; set; }


    }
}