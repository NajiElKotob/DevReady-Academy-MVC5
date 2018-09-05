using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevReadyAcademy.Models;
using DevReadyAcademy.Models.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DevReadyAcademy.Controllers.Security
{
    public class RolesController : Controller
    {

        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Roles
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var roleName = collection["RoleName"];

                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var role = new IdentityRole { Name = roleName };

                    roleManager.Create(role);
                }

                //context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}