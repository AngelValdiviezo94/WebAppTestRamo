using System.Web;
using System.Web.Mvc;

namespace WebAppRamo
{
    public class FilterConfig
    {
        /*
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        */

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute()); // Bloquea todo el sitio
            filters.Add(new HandleErrorAttribute());
        }
    }
}
