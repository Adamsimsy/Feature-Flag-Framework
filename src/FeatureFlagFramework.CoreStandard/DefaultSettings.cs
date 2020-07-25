using FeatureFlagFramework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Core
{
    public class DefaultSettings : ClientSettings
    {
        public DefaultSettings(string clientKeyName)
        {
            this.ClientKey = ClientHelper.GetClientKey(clientKeyName);
        }
    }
}
