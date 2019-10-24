using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp1.Controllers
{
    /// <summary>
    /// 假设客户端只能发送GET和POST请求，使用MethodOverrideHandler重写请求谓词请求。
    /// </summary>
    public class MethodOverrideController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            return "Post actual";
        }
 

        // PUT api/<controller>/5
        public string Put(int id, [FromBody]string value)
        {
            return "Put actual";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            return "Delete actual";
        }
    }
}