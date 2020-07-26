using FeatureFlagFramework.Clients.JsonToggler;
using FeatureFlagFramework.Clients.JsonToggler.Client;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using FeatureFlagFramework.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler
{
    public sealed class JsonTogglerFrameworkClient : IFeatureFlagClient
    {
        private readonly Lazy<JsonTogglerClient> lazyClient;

        public JsonTogglerClient _client { get { return lazyClient.Value; } }

        private static readonly Lazy<IFeatureFlagClient> lazyFeatureFlagClient = new Lazy<IFeatureFlagClient>(() => new JsonTogglerFrameworkClient(new FeatureFlagClientDefaultSettings(Constants.ClientKeyName)));

        public static IFeatureFlagClient Instance { get { return lazyFeatureFlagClient.Value; } }

        private readonly FeatureFlagClientSettings settings;

        public JsonTogglerFrameworkClient(FeatureFlagClientSettings settings)
        {
            this.settings = settings;
            this.lazyClient = new Lazy<JsonTogglerClient>(() => new JsonTogglerClient(new JsonFlagSerializer(), settings.ClientKey));
        }

        public bool Evaluate(string flagName, bool defaultValue)
        {
            return _client.BoolVariation(flagName, defaultValue);
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


