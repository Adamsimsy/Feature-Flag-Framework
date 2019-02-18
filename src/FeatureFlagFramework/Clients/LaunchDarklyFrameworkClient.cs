using LaunchDarkly.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients
{
    public class LaunchDarklyFrameworkClient : IFeatureFlagClient
    {
        private LdClient client;

        public LaunchDarklyFrameworkClient(string clientKey)
        {
            Configuration ldConfig = LaunchDarkly.Client.Configuration.Default(clientKey);

            client = new LdClient(ldConfig);
        }

        public bool Evaluate(string flagName)
        {
            return client.BoolVariation(flagName, CreateUser(), false);
        }

        static internal User CreateUser()
        {
            var key = Guid.NewGuid().ToString();

            //LaunchDarkly won't update display name unless both first and last is set.
            return User.WithKey(key).AndAnonymous(true).AndEmail("anonymous@user.com").AndFirstName("anonymous").AndLastName("anonymous");
        }
    }
}
