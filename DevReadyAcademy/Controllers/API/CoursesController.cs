using DevReadyAcademy.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

/*
Responses Types:
 Ok
 NotFound
 Exception
 Unauthorized
 BadRequest
 Conflict
 Redirect
*/

namespace DevReadyAcademy.Controllers.API
{
    /// <summary>
    /// 
    /// </summary>
    public class CoursesController : ApiController
    {
   
        private ApplicationDbContext context;

        /// <summary>
        /// 
        /// </summary>
        public CoursesController()
        {
            context = new ApplicationDbContext();
        }


        /// <summary>
        /// GET: api/Courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            var courses = context.Courses.ToList();
            return Ok(courses);
        }


        // GET: api/Courses/5
        [HttpGet]
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            context.Entry(course).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Courses
        [HttpPost]
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Courses.Add(course);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete]
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            context.Courses.Remove(course);
            context.SaveChanges();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        [NonAction]
        private bool CourseExists(int id)
        {
            return context.Courses.Count(e => e.Id == id) > 0;
        }
    }
}
