using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Rayner.Data
{
    public class Settings
    {
        public enum DatabaseType
        {
            MySQL = 1,
            MsSQL = 2
        }

        private static Dictionary<string, string> _Settings { get; set; }
        private static bool _cached { get; set; }

        public static string Username
        {
            get
            {
                if (!_cached)
                    LoadCache();
                return _Settings["SQLUsername"];
            }
        }
        public static string Password
        {
            get
            {
                if (!_cached)
                    LoadCache();
                return _Settings["SQLPassword"];
            }
        }
        public static string Database
        {
            get
            {
                if (!_cached)
                    LoadCache();
                return _Settings["SQLDatabase"];
            }
        }
        public static string Host
        {
            get
            {
                if (!_cached)
                    LoadCache();
                return _Settings["SQLHost"];
            }
        }
        public static void LoadCache()
        {
            _Settings = new Dictionary<string, string>();
            
            var cacheKeys = new List<string>
            {
                "SQLUsername",
                "SQLPassword",
                "SQLDatabase",
                "SQLHost"
            };
            foreach (var k in cacheKeys)
            {
                _Settings.Add(k, ConfigurationManager.AppSettings[k]);
            }
            _cached = true;
        }
    }
}
