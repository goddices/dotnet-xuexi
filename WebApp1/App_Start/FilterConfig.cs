using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebApp1.Filters;

namespace WebApp1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        { 
            filters.Add(new HandleErrorAttribute());
             
        }
    }
}
