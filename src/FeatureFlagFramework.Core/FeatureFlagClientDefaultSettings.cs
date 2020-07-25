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

            ValidateValue(clientKeyName, value);

            this.ClientKey = value;
        }

        public static void SetClientKey(string clientKeyName, string value)
        {
            ValidateValue(clientKeyName, value);

            ConfigurationManager.AppSettings.Set(clientKeyName, value);
        }

        internal static string ValidateValue(string clientKeyName, string value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value))
            {
                throw new System.ArgumentException("appSettings with key '" + clientKeyName + "' not configured or empty.");
            }
            else if (value.Equals("CLIENT_KEY_HERE"))
            {
                throw new System.ArgumentException("appSettings with key '" + clientKeyName + "' is still set to default 'CLIENT_KEY_HERE'.");
            }
            return value;
        }
    }
}
