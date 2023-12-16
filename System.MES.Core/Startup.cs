using Furion;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.MES.Core.Const;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Core
{
    [AppStartup(800)]
    public sealed class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurableOptions<AppInfoOptions>();
        }

    }
}
