using System.Web;
using System.Web.Mvc;

namespace DevReadyAcademy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Error Handling
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleErrorAttribute() { View = "~/Views/Errors/Index.cshtml" });

            //Security
            //filters.Add(new AuthorizeAttribute()); //everything is secure
        }
    }
}
