using DevReadyAcademy.Models;
using DevReadyAcademy.Models.Repositories;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

/*
IHttpActionResult Responses Types:
https://www.infoworld.com/article/3192176/application-development/my-two-cents-on-using-the-ihttpactionresult-interface-in-webapi.html

Ok
NotFound
Exception
Unauthorized
BadRequest
Conflict
Redirect
InvalidModelState
*/

namespace DevReadyAcademy.Controllers.API
{
    /// <summary>
    /// 
    /// </summary>
    public class CoursesController : ApiController
    {

        private UnitOfWork unitOfWork; 

        /// <summary>
        /// 
        /// </summary>
        public CoursesController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }


        /// <summary>
        /// GET: api/Courses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetCourses()
        {        
            return Ok(unitOfWork.Courses.GetAll());
        }


        // GET: api/Courses/5
        [HttpGet]
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = unitOfWork.Courses.Get(id);
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

            unitOfWork.Courses.Update(course);

            try
            {
                unitOfWork.Save();
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

            unitOfWork.Courses.Add(course);
            unitOfWork.Save();

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete]
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = unitOfWork.Courses.Get(id);
            if (course == null)
            {
                return NotFound();
            }

            unitOfWork.Courses.Remove(course);
            unitOfWork.Save();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        [NonAction]
        private bool CourseExists(int id)
        {
            return unitOfWork.Courses.IsExist(id);
        }
    }
}
