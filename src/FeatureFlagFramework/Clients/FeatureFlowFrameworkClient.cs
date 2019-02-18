using Featureflow.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FeatureFlagFramework.Clients
{
    public class FeatureFlowFrameworkClient : IFeatureFlagClient
    {
        private static readonly Lazy<IFeatureflowClient> lazyClient = new Lazy<IFeatureflowClient>(() => FeatureflowClientFactory.Create(ConfigurationManager.AppSettings["FeatureFlagFramework.FeatureFlow"]));

        public static IFeatureflowClient _client { get { return lazyClient.Value; } }

        private static readonly Lazy<IFeatureFlagClient> lazyFeatureFlagClient = new Lazy<IFeatureFlagClient>(() => new FeatureFlowFrameworkClient());

        public static IFeatureFlagClient Instance { get { return lazyFeatureFlagClient.Value; } }

        public bool Evaluate(string flagName)
        {
            return _client.Evaluate(flagName).IsOn();
        }
    }
}
