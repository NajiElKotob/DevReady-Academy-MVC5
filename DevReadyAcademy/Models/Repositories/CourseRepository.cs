using DevReadyAcademy.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.Models.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Course> GetActiveCourses()
        {
            return AppContext.Courses.Where(c => c.IsActive == true).ToList();
        }


        public ApplicationDbContext AppContext
        {
            get { return base.Context as ApplicationDbContext; }
        }
    }
}