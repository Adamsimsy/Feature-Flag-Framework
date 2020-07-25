using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Core
{
    public class FeatureFlagClientDefaultSettings : FeatureFlagClientSettings
    {
        public FeatureFlagClientDefaultSettings(string clientKeyName)
        {
            var value = ConfigurationManager.AppSettings[clientKeyName];

            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("appSettings with key '" + clientKeyName + "' not configured or empty.");
            }
            else if (value.Equals("CLIENT_KEY_HERE"))
            {
                throw new System.ArgumentException("appSettings with key '" + clientKeyName + "' is still set to default 'CLIENT_KEY_HERE'.");
            }

            this.ClientKey = value;
        }

        public static void SetClientKey(string key, string value)
        {
            ConfigurationManager.AppSettings.Set(key, value);
        }
    }
}
