using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDbFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAppAspNetCore.Services;
using WebAppAspNetCore.Settings;

namespace WebAppAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //依赖注入
        private SqlearnContext context;
        private MySettings mySettingsMonitor;

        private MySettings mySettingsOptions;
        private IMyService myService;

        /*
         * 微软的Options模式
         *   https://docs.microsoft.com/en-gb/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.2#basic-options-configuration
         * 在appsettings.json中配置MySettings对象，在Starup中注册该对象
         *   services.Configure<MySettings>(Configuration.GetSection("MySettings")); 
         */
        public ValuesController(SqlearnContext context,
            IOptionsMonitor<MySettings> optionsMonitor,
            IOptions<MySettings> options,
            IMyService myService)
        {
            this.context = context;

            // settings的值需要用CurrentValue获取
            // IOptionsMonitor和IOptions的区别
            // monitor可以监控appsettings.json的变化，及时更新。 而option在程序启动之后就不会再变化了
            this.mySettingsMonitor = optionsMonitor.CurrentValue;
            this.mySettingsOptions = options.Value;
            this.myService = myService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
                mySettingsMonitor.RegisterDate.ToString(),
                mySettingsMonitor.WebsiteOwner ,
                mySettingsOptions.RegisterDate.ToString(),
                mySettingsOptions.WebsiteOwner,
                string.Join(':' ,myService.GetValues())
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Course>> Get(int id)
        {
            //using Microsoft.EntityFrameworkCore 调用ToListAsync方法
            using (context)
            {
                return await context.Course.Where(c => c.Teacher.Name == "BillGates").ToListAsync();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
