using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Xml;

namespace Marketing.GestaoVerbas.Core
{
    public static class Config
    {
        public static String UrlApiToken() { return OpenConfigFile().AppSettings.Settings["urlApiToken"].Value; }
        public static String AuthUser() { return OpenConfigFile().AppSettings.Settings["authUser"].Value; }
        public static String AuthPassword() { return OpenConfigFile().AppSettings.Settings["authPassword"].Value; }
        public static String UrlApi() { return OpenConfigFile().AppSettings.Settings["urlApi"].Value; }
        
        public static Configuration OpenConfigFile()
        {
            String str = ConfigurationManager.AppSettings["config"];

            ConfigurationFileMap fileMap = new ConfigurationFileMap(str); //Path to your config file

            Configuration config = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            return config;
        }
    }
}