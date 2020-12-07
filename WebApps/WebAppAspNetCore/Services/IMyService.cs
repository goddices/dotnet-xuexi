using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAspNetCore.Settings;

namespace WebAppAspNetCore.Services
{
    public interface IMyService
    {
        string[] GetValues();
    }


}
