using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
namespace HFMaracay.Core.Util
{
    public static class ObjectExtensions
    {
        private static object ConvertIfNonAvroType(object obj)
        {
            return obj is DateTime ? ((DateTime)obj).ToString("o") : obj;
        }
        public static JObject GetJsonObjetc(this Dictionary<string, object> document)
        {
            return JObject.Parse(JsonConvert.SerializeObject(document));
        }

        public static JObject GetJsonObjetc(this object document)
        {
            return JObject.Parse(JsonConvert.SerializeObject(document));
        }
        public static T ToObject<T>(this object obj)
        {
            Type TypeOfClass = typeof(T);
            return (T)Convert.ChangeType(obj, TypeOfClass);
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static T ToConvertObjects<T>(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
