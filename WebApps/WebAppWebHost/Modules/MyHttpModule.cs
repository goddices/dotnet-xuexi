using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAppWebHost.Modules
{
    public class MyHttpModule : IHttpModule
    {
        public void Dispose()
        {
            Debug.WriteLine("MyHttpModule Dispose hash code = " + GetHashCode(), "Debug");
        }

        public void Init(HttpApplication context)
        {
            Debug.WriteLine("MyHttpModule Init hash code = " + GetHashCode(), "Debug");
            context.BeginRequest += Context_BeginRequest;
            context.EndRequest += Context_EndRequest;
        }

        private void Context_EndRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("MyHttpModule EndRequest hash code = " + GetHashCode(), "Debug");
            //throw new NotImplementedException();
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            Debug.WriteLine("MyHttpModule BeginRequest hash code = " + GetHashCode(), "Debug");
            //throw new NotImplementedException();
        }
    }
}