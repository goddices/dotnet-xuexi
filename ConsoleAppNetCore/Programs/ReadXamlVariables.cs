using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleAppNetCore.Programs
{
    public class ReadXamlVariables
    {

        public async Task<(bool Valid, IEnumerable<object> Arguments)> TryReadAsync(Stream dgsFileStream, CancellationToken token)
        {
            XmlReader reader = XmlReader.Create(dgsFileStream);
            while (await reader.ReadAsync() && reader.NodeType == XmlNodeType.Element && string.Equals("x:Members", reader.Name))
            {
                break;
            }
        }
    }
}
