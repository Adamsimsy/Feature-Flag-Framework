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
        private readonly Lazy<IFeatureflowClient> lazyClient;

        public IFeatureflowClient _client { get { return lazyClient.Value; } }

        private static readonly Lazy<IFeatureFlagClient> lazyFeatureFlagClient = new Lazy<IFeatureFlagClient>(() => new FeatureFlowFrameworkClient(new DefaultSettings("FeatureFlagFramework.Clients.Featureflow")));

        public static IFeatureFlagClient Instance { get { return lazyFeatureFlagClient.Value; } }

        private readonly ClientSettings settings;

        public FeatureFlowFrameworkClient(ClientSettings settings)
        {
            this.settings = settings;
            this.lazyClient = new Lazy<IFeatureflowClient>(() => FeatureflowClientFactory.Create(settings.ClientKey));
        }

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
