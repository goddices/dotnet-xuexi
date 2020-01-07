using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebAppWebHost.Handlers
{
    public delegate void MyHandlerAsyncCaller(HttpContext context);
    public class MyHandler : IHttpAsyncHandler
    {
        private MyHandlerAsyncCaller caller;
        public bool IsReusable => true;

        public MyHandler()
        {
            caller = new MyHandlerAsyncCaller(BeginProcessRequestInner);
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {

            return caller.BeginInvoke(context, cb, extraData);
        }

        private void BeginProcessRequestInner(HttpContext context)
        {
            Debug.WriteLine("BeginProcessRequest : request uri:" + context.Request.Url.ToString() + " hash code = " + GetHashCode(), "Debug");
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            Debug.WriteLine("EndProcessRequest : hash code = " + GetHashCode(), "Debug");
        }

        public void ProcessRequest(HttpContext context)
        {
            Debug.WriteLine("ProcessRequest : request uri:" + context.Request.Url.ToString() + " hash code = " + GetHashCode(), "Debug");
        }
    }
}