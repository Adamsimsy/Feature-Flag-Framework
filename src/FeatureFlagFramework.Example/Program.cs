using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FeatureFlagFramework.Core;
using FeatureFlagFramework.Clients.LaunchDarkly;

namespace FeatureFlagFramework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientKey = ConfigurationManager.AppSettings[FeatureFlagFramework.Clients.LaunchDarkly.Constants.ClientKeyName];

            //FeatureFlagFramework - Instantiation with Custom Configuration used with Dependency Injection library of your choice
            IFeatureFlagClient featureFlagClientDependencyInjection = new LaunchDarklyFrameworkClient(new FeatureFlagClientSettings()
            {
                ClientKey = clientKey
            });

            //FeatureFlagFramework - Service Locator
            IFeatureFlagClient featureFlagClientServiceLocator = LaunchDarklyFrameworkClient.Instance;

            //FeatureFlagFramework - Service Locator Configuration
            //You don't need to set the key using the below if using the default AppSetting key names
            //FeatureFlagClientDefaultSettings.SetClientKey(Constants.ClientKeyName, clientKey);

            //FeatureFlagFramework - Factory to toggle between clients (e.g. between LaunchDarkly and FeatureFlow whilst evaluating clients)
            IFeatureFlagClient featureFlagClientFactory = FeatureFlagFramework.ClientFactory.Instance;

            while (true)
            {
                if (featureFlagClientDependencyInjection.Evaluate("example-feature-flag", false))
                {
                    Console.WriteLine(featureFlagClientDependencyInjection.GetType().ToString() + " with Instantiation True");
                }
                else
                {
                    Console.WriteLine(featureFlagClientDependencyInjection.GetType().ToString() + " with Instantiation False");
                }

                if (featureFlagClientServiceLocator.Evaluate("example-feature-flag", false))
                {
                    Console.WriteLine(featureFlagClientServiceLocator.GetType().ToString() + " with Service Locator True");
                }
                else
                {
                    Console.WriteLine(featureFlagClientServiceLocator.GetType().ToString() + " with Service Locator False");
                }

                if (featureFlagClientFactory.Evaluate("example-feature-flag", false))
                {
                    Console.WriteLine(featureFlagClientFactory.GetType().ToString() + " with Flagging Factory True");
                }
                else
                {
                    Console.WriteLine(featureFlagClientFactory.GetType().ToString() + " with Flagging Factory False");
                }

                Thread.Sleep(500);
            }
        }
    }
}
