using LaunchDarkly.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FeatureFlagFramework.Clients
{
    public sealed class LaunchDarklyFrameworkClient : IFeatureFlagClient
    {
        private static readonly Lazy<LdClient> lazyClient = new Lazy<LdClient>(() => new LdClient(ConfigurationManager.AppSettings["FeatureFlagFramework.LaunchDarkly"]));

        public static LdClient _client { get { return lazyClient.Value; } }

        private static readonly Lazy<IFeatureFlagClient> lazyFeatureFlagClient = new Lazy<IFeatureFlagClient>(() => new LaunchDarklyFrameworkClient());

        public static IFeatureFlagClient Instance { get { return lazyFeatureFlagClient.Value; } }

        public bool Evaluate(string flagName, bool defaultValue)
        {
            return _client.BoolVariation(flagName, CreateUser(), defaultValue);
        }

        public int Evaluate(string flagName, int defaultValue)
        {
            throw new NotImplementedException();
        }

        public string Evaluate(string flagName, string defaultValue)
        {
            throw new NotImplementedException();
        }

        static internal User CreateUser()
        {
            var key = Guid.NewGuid().ToString();

            //LaunchDarkly won't update display name unless both first and last is set.
            return User.WithKey(key).AndAnonymous(true).AndEmail("anonymous@user.com").AndFirstName("anonymous").AndLastName("anonymous");
        }
    }
}


