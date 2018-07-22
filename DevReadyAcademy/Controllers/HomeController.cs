using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevReadyAcademy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // throw new NullReferenceException();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Errors Testing
        public ActionResult FileNotFound()
        {
            return HttpNotFound();
        }

        //[HandleError(View = "~/Views/Errors/FileNotFound.cshtml", ExceptionType = typeof(NullReferenceException))]
        //[HandleError(Order = 2, View = "Error", ExceptionType = typeof(DivideByZeroException))]
        public ActionResult ThrowException()
        {
            throw new NullReferenceException();
        }

    }
}