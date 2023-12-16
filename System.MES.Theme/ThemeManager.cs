using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace System.MES.Theme
{
    public static class ThemeManager
    {
        public static ResourceDictionary LoadTheme()
        {
            // 加载资源字典
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("/System.MES.Theme;component/Properties/ApplicationResource.xaml", UriKind.RelativeOrAbsolute);
            return resourceDictionary;
        }
    }
}
