using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAspNetCore.Settings
{
    public class SlackApiSettings
    {
        public string WebhookUrl { get; set; }
        public string DisplayName { get; set; }
    }
}
