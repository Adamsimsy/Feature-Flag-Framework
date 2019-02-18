using FeatureFlagFramework.Clients;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FeatureFlagFramework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            IFeatureFlagClient client;

            IFeatureFlagClient FeatureflowClient = new FeatureFlowFrameworkClient(ConfigurationManager.AppSettings["FeatureFlagFramework.FeatureFlow"]);
            IFeatureFlagClient LaunchDarklyClient = LaunchDarklyFrameworkClient.Instance;

            while (true)
            {
                if (LaunchDarklyClient.Evaluate("toggle-feature-flow-service"))
                {
                    client = LaunchDarklyClient;                    
                }
                else
                {
                    client = FeatureflowClient;
                }

                if (client.Evaluate("api-633-optimized-matches-endpoint"))
                {
                    Console.WriteLine(client.GetType().ToString() + " True");
                }
                else
                {
                    Console.WriteLine(client.GetType().ToString() + " False");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
