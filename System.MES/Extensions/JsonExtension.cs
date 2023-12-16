using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Extensions
{
    public class JsonExtension
    {
        public static IConfiguration Configuration { get; private set; }
        public static void GetDefaultJsonLevel()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            var configuration = App.GetService<IConfiguration>();
            var Name = configuration["Cache:CacheType"];
        }

    }
}
