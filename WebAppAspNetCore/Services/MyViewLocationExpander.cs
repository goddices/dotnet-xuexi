using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace WebAppAspNetCore.Services
{
    public class MyViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.IsApp())
            {
                viewLocations = new[] {
                        $"/Views/AppViews/{{1}}/{{0}}.cshtml",
                        $"/Views/AppViews/Shared/{{0}}.cshtml",
                    };
            }
            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Populate();
        }
    }

    public static class ViewLocationExpanderContextExtension
    {

        public static void Populate(this ViewLocationExpanderContext context)
        {
            string userAgent = context.ActionContext.HttpContext.Request.Headers["User-Agent"];
            if (userAgent.Contains("Firefox"))
            {
                context.Values.Add("UseApp", "true");
            }
        }

        public static bool IsApp(this ViewLocationExpanderContext context)
        {
            return context.Values.TryGetValue("UseApp", out string valstr) &&
                bool.TryParse(valstr, out bool useApp) && useApp;
        }

    }
}
