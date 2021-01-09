using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoC.OxiServi.NativeInjector
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
