using FeatureFlagFramework.Clients;
using FeatureFlagFramework.Clients.Featureflow;
using FeatureFlagFramework.Clients.LaunchDarkly;
using FeatureFlagFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework
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
