using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebAppWebHost.Filters;

namespace WebAppWebHost
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        { 
            filters.Add(new HandleErrorAttribute());
             
        }
    }
}
