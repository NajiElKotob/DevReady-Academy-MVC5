using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevReadyAcademy.Controllers.Security
{
    [AllowAnonymous]
    public class WhoAmIController : Controller
    {
        // GET: WhoAmI
        public ActionResult Index()
        {
            return View();
        }
    }
}