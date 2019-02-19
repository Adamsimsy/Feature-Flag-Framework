using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Helpers
{
    public static class ClientHelper
    {
        public static string GetClientKey(string settingName)
        {
            var value = ConfigurationManager.AppSettings[settingName];

            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("appSettings with key '" + settingName + "' not configured or empty.");
            }
            else if(value.Equals("CLIENT_KEY_HERE"))
            {
                throw new System.ArgumentException("appSettings with key '" + settingName + "' is still set to default 'CLIENT_KEY_HERE'.");
            }

            return value;
        }
    }
}
