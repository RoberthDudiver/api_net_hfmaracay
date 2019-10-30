using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Collections;
using System;
using Serilog;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Extensions.Configuration.Json;

namespace HFMaracay.Core
{
    public static class AppConfiguration
    {
        static IConfiguration Configuration;

        static AppConfiguration()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetAssembly(typeof(AppConfiguration)).Locati‌​on);
            var environment = Environment.GetEnvironmentVariable("HF_ENVIRONMENT");
            var envDiscriminator = environment != null ? string.Concat(".", environment) : string.Empty;

            var builder = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile($"./Configuration/appsettings{envDiscriminator}.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(Configuration)
                .CreateLogger();
        }

        public static string GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }

        public static string GetConfiguration(string key)
        {
            return Configuration[key];
        }

        public static T GetConfiguration<T>(string key)
        {
            var originalValue = Configuration[key];
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFrom(null, CultureInfo.InvariantCulture, originalValue);
        }

        public static T GetSection<T>(string key) where T : class, new()
        {
            var entity = new T();
            Configuration.GetSection(key).Bind(entity);
            return entity;
        }

        public static Dictionary<string, object> GetDictionary(string key)
        {
            return Configuration.GetSection(key).GetChildren()
                            .Select(item =>
                            {
                                var asBool = GetValueOrNull<bool>(item.Value);
                                var asInt = GetValueOrNull<int>(item.Value);
                                object value;

                                if (asBool != null)
                                {
                                    value = asBool;
                                }
                                else if (asInt != null)
                                {
                                    value = asInt;
                                }
                                else
                                {
                                    value = item.Value;
                                }

                                return new KeyValuePair<string, object>(item.Key, value);
                            })
                            .ToDictionary(x => x.Key, x => x.Value);
        }

        public static T? GetValueOrNull<T>(this string valueAsString) where T : struct
        {
            try
            { 
                if (typeof(T) == typeof(bool))
                {
                    return (T)Convert.ChangeType(Convert.ToBoolean(valueAsString.ToLower()), typeof(T));
                }
                return (T)Convert.ChangeType(valueAsString, typeof(T));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
