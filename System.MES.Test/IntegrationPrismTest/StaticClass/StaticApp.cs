using Furion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationPrismTest.StaticClass
{
    public class StaticApp
    {
        public static void Get()
        {
            //获取全局配置
            var settings = App.Settings;

            //获取配置对象
            var configuration = App.Configuration;
            var value = configuration["AppInfo:Name"];



        }
    }

}
