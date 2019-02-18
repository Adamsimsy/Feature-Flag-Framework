using Featureflow.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients
{
    public class FeatureFlowFrameworkClient : IFeatureFlagClient
    {
        private FeatureflowClient client;

        public FeatureFlowFrameworkClient(string clientKey)
        {
            client = new FeatureflowClient(clientKey);
        }

        public bool Evaluate(string flagName)
        {
            return client.Evaluate(flagName).IsOn();
        }
    }
}
