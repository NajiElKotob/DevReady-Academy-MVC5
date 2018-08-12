using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.ViewModels
{
    public class CourseFormViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}