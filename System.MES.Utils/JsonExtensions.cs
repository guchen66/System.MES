using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.MES.Utils
{
    public static class JsonExtensions
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        public static readonly JsonSerializerSettings JsonDeserializerSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        static JsonExtensions()
        {
          //  JsonSerializerSettings.Converters.Add(FileLocatorConverter);
        }

        public static string ToJson<T>(this T @object, Formatting formatting = Formatting.None, bool specifyRootType = true)
        {
            var type = @object.GetType();

            return typeof(T) != type && specifyRootType
                ? JsonConvert.SerializeObject(@object, typeof(T), formatting, JsonSerializerSettings)
                : JsonConvert.SerializeObject(@object, formatting, JsonSerializerSettings);
        }

        public static T ToObject<T>(this string json)
        {
            return !string.IsNullOrWhiteSpace(json)
                ? JsonConvert.DeserializeObject<T>(json, JsonDeserializerSettings)
                : default;
        }


    }

   
}
