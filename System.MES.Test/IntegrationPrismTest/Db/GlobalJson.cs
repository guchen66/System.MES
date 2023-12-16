using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationPrismTest.Db
{
    public class GlobalJson
    {
        IConfiguration _configuration;
        public GlobalJson(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void GetJson()
        {
            string s1 = _configuration.GetSection("AppInfo:Name").Value;
            var s2 = $@"{_configuration["Login:UserName"]}";
            var s3 = _configuration.GetConnectionString("DbType");
        }
    }
}
