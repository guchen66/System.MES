using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Utils
{
    public static class FurionExtension
    {
        public static void RegisterViewsFromJson(this IServiceCollection serviceCollection, Assembly assembly, string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            Dictionary<string, string> viewDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            foreach (var kvp in viewDict)
            {
                Type viewType = assembly.GetType(kvp.Value);
               // serviceCollection.AddSingleton(typeof(object), viewType, kvp.Key);
            }
        }
    }

}
