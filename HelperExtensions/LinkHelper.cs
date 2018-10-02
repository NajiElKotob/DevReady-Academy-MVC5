using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelperExtensions
{
    public static class LinkHelper
    {
        public static string ExternalLink(this HtmlHelper helper,                                    
                                            string url, 
                                            string text,
                                            string protocol = "",
                                            string target = "_blank")
        {
            if (!url.StartsWith("http",true,null))
            {
                protocol = "http://";
            }
            return $"<a href=\"{ protocol}{url}\" target=\"{target}\">{text}</a>";
        }
    }
}
