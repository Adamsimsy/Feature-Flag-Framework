using FeatureFlagFramework.Clients;
using FeatureFlagFramework.Clients.FeatureflowStandard;
using FeatureFlagFramework.Clients.LaunchDarklyStandard;
using FeatureFlagFramework.CoreStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFrameworkStandard
{
    public static class ClientFactory
    {
        public static IFeatureFlagClient Instance
        {
            get
            {
                IFeatureFlagClient client;

                var LaunchDarklyClient = LaunchDarklyFrameworkClient.Instance;

                if (LaunchDarklyClient.Evaluate("toggle-feature-service", true))
                {
                    client = LaunchDarklyClient;
                }
                else
                {
                    client = FeatureFlowFrameworkClient.Instance;
                }

                return client;
            }
        }
    }
}
