using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetCore.Settings;

namespace WebAppAspNetCore.Services
{

    public class MyService : IMyService
    {
        private readonly SlackApiSettings _devSettings;
        private readonly SlackApiSettings _generalSettings;
        private readonly SlackApiSettings _publicSettings;

        //options也可以注入到service中
        //IOptionsSnapshot 类似IOptionsMonitor
        //https://andrewlock.net/using-multiple-instances-of-strongly-typed-settings-with-named-options-in-net-core-2-x/
        //https://andrewlock.net/creating-singleton-named-options-with-ioptionsmonitor/
        public MyService(IOptionsSnapshot<SlackApiSettings> options)
        {
            /* 
             * IOptionsSnapshot和IOptionsMonitor的区别
             *  IOptionsMonitor<T> is a bit like IOptions<T> in some ways and IOptionsSnapshot<T> in others:
             *  It's registered as a Singleton (like IOptions<T>)
             *  It contains a CurrentValue property that gets the default strongly-typed settings object 
             *   as a Singleton (like IOptions<T>.Value)
             *  It has a Get(name) method for returning named options (like IOptionsSnapshot<T>). 
             *  Unlike IOptionsSnapshot<T>, these named options are Singletons.
             *  Responds to changes in the underlying IConfiguration object by re-binding options. 
             *   Note this only happens when the configuration changes (not every request like IOptionsSnapshot<T> does).
             *  IOptionsMonitor<T> is itself a Singleton, and it caches both the default and named options for the lifetime of the app. However, if the underlying IConfiguration that the options are bound to changes, IOptionsMonitor<T> will throw away the old values, and rebuild the strongly-typed settings. You can register to be informed about those changes with the OnChange(listener) method, but I won't go into that in this post.
             */
            _devSettings = options.Get("Dev");
            _generalSettings = options.Get("General");
            _publicSettings = options.Get("Public");
        }
        public string[] GetValues()
        {
            return new string[] { _devSettings.DisplayName, _devSettings.WebhookUrl };
        }
    }
}
