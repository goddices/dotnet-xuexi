using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ConsoleAppNetCore.Programs
{
    public static class EmbeddedResourceClient
    {
        public static void Run()
        {
            Type type = MethodBase.GetCurrentMethod().DeclaringType;

            string _namespace = type.Namespace;

            //获得当前运行的Assembly

            Assembly _assembly = Assembly.GetExecutingAssembly();

            //根据名称空间和文件名生成资源名称

            string resourceName = _namespace + ".data.json";

            //根据资源名称从Assembly中获取此资源的Stream

            Stream stream = _assembly.GetManifestResourceStream(resourceName);
        }
    }
}
