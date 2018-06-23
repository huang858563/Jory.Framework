using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Jory.Framework.Common
{
    public class ConfigHelper
    {
        public static string GetAppSettingValue(string key)
        {
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(key))
            {
                throw new ArgumentException("appSettings", key);
            }
            return ConfigurationManager.AppSettings[key];
        }

        public static void UpdateConfig<T>(T config)
        {
            Type configType = typeof(T);
            string configFilePath = GetConfigPath<T>();
            try
            {
                var xmlSerializer = new XmlSerializer(configType);
                using (var xmlTextWriter = new XmlTextWriter(configFilePath, Encoding.UTF8))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    var xmlNamespace = new XmlSerializerNamespaces();
                    xmlNamespace.Add(string.Empty, string.Empty);
                    xmlSerializer.Serialize(xmlTextWriter, config, xmlNamespace);
                }
            }
            catch (SecurityException ex)
            {
                throw new SecurityException(ex.Message, ex.DenySetInstance, ex.PermitOnlySetInstance, ex.Method,
                                            ex.Demanded, ex.FirstPermissionThatFailed);
            }
        }

        public static T GetConfig<T>() where T : class, new()
        {
            var configObject = new object();
            Type configType = typeof(T);
            string configFilePath = GetConfigPath<T>();
            if (File.Exists(configFilePath))
            {
                using (var xmlTextReader = new XmlTextReader(configFilePath))
                {
                    var xmlSerializer = new XmlSerializer(configType);
                    configObject = xmlSerializer.Deserialize(xmlTextReader);
                }
            }
            var config = configObject as T;
            if (config == null)
            {
                return new T();
            }
            return config;
        }

        public static string GetConfigPath<T>()
        {
            return Path.Combine( AppDomain.CurrentDomain.BaseDirectory, typeof(T).Name + ".config");
        }

        public static string ReadConfig<T>()
        {
            string configContent = string.Empty;
            string filePath = GetConfigPath<T>();
            if (File.Exists(filePath))
            {
                using (var sr = new StreamReader(filePath, Encoding.Default))
                {
                    configContent = sr.ReadToEnd();
                    sr.Close();
                }
            }
            return configContent;
        }

        public static void WriteConfig<T>(string config)
        {
            string fileName = GetConfigPath<T>();
            using (StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(config);
                w.Close();
            }
        }  

        //private static string AppSettingValue([CallerMemberName] string key = null)
        //{
        //    return ConfigurationManager.AppSettings[key];
        //}

        //public static string RedisConnectionString
        //{
        //    get
        //    {
        //        return string.IsNullOrWhiteSpace(AppSettingValue()) ? null : AppSettingValue();
        //    }
        //}
    }
}
