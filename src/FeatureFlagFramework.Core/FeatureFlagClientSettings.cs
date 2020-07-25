using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Core
{
    public class FeatureFlagClientSettings
    {
        private string clientKey;

        public string ClientKey {
            get
            {
                return clientKey;
            }
            set
            {
                FeatureFlagClientDefaultSettings.ValidateValue("Set by FeatureFlagClientSettings", value);

                clientKey = value;
            }
        }
    }
}
