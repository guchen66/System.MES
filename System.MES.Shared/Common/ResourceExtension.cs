using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace System.MES.Shared.Common
{
    /// <summary>
    /// 加载资源字典的两种方式
    /// </summary>
    public static class ResourceExtension
    {
        public static ResourceDictionary Read()
        {
            var dictionaryXaml = @"
    <ResourceDictionary xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source=""pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml"" />
            <ResourceDictionary Source=""pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml"" />
            <ResourceDictionary Source=""pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml"" />
            <ResourceDictionary Source=""pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Indigo.xaml"" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>";

            return (ResourceDictionary)System.Windows.Markup.XamlReader.Parse(dictionaryXaml);
        }


        public static ResourceDictionary LoadTheme()
        {
            // 加载资源字典
            var resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri("/System.MES.Theme;component/Properties/ApplicationResource.xaml", UriKind.RelativeOrAbsolute);

            return resourceDictionary;
        }
    }
}
