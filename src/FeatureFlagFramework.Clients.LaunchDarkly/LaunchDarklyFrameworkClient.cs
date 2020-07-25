using FeatureFlagFramework.Core;
using FeatureFlagFramework.Core.Helpers;
using LaunchDarkly.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FeatureFlagFramework.Clients.LaunchDarkly
{
    public sealed class LaunchDarklyFrameworkClient : IFeatureFlagClient
    {
        private readonly Lazy<LdClient> lazyClient;

        public LdClient _client { get { return lazyClient.Value; } }

        private static readonly Lazy<IFeatureFlagClient> lazyFeatureFlagClient = new Lazy<IFeatureFlagClient>(() => new LaunchDarklyFrameworkClient(new DefaultSettings("FeatureFlagFramework.Clients.LaunchDarkly")));

        public static IFeatureFlagClient Instance { get { return lazyFeatureFlagClient.Value; } }

        private readonly ClientSettings settings;

        public LaunchDarklyFrameworkClient(ClientSettings settings)
        {
            this.settings = settings;
            this.lazyClient = new Lazy<LdClient>(() => new LdClient(settings.ClientKey));
        }

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


