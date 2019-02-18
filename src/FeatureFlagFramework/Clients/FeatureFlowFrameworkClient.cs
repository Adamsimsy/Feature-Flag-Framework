using Featureflow.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients
{
    public class FeatureFlowFrameworkClient : IFeatureFlagClient
    {
        private IFeatureflowClient _client;

        public FeatureFlowFrameworkClient(string clientKey)
        {
            _client = FeatureflowClientFactory.Create(clientKey);
        }

        public bool Evaluate(string flagName)
        {
            return _client.Evaluate(flagName).IsOn();
        }
    }
}
