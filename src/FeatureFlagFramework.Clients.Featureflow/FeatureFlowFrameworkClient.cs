using FeatureFlagFramework.Core;
using FeatureFlagFramework.Core.Helpers;
using Featureflow.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FeatureFlagFramework.Clients.Featureflow
{
    public class FeatureFlowFrameworkClient : IFeatureFlagClient
    {
        private static readonly Lazy<IFeatureflowClient> lazyClient = new Lazy<IFeatureflowClient>(() => FeatureflowClientFactory.Create(ClientHelper.GetClientKey("FeatureFlagFramework.ClientKey.FeatureFlow")));

        public static IFeatureflowClient _client { get { return lazyClient.Value; } }

        private static readonly Lazy<IFeatureFlagClient> lazyFeatureFlagClient = new Lazy<IFeatureFlagClient>(() => new FeatureFlowFrameworkClient());

        public static IFeatureFlagClient Instance { get { return lazyFeatureFlagClient.Value; } }

        public bool Evaluate(string flagName, bool defaultValue)
        {
            //TODO: Impelement defaultValue
            return _client.Evaluate(flagName).IsOn();
        }

        public int Evaluate(string flagName, int defaultValue)
        {
            throw new NotImplementedException();
        }

        public string Evaluate(string flagName, string defaultValue)
        {
            throw new NotImplementedException();
        }
    }
}
