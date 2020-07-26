using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonTogglerClient
    {
        private readonly IJsonClientProvider jsonClientProvider;

        public JsonTogglerClient(IJsonFlagSerializer serializer, string path)
        {
            jsonClientProvider = JsonClientProviderFactory.GetProvider(serializer, path);
        }

        internal bool BoolVariation(string flagName, bool defaultValue)
        {
            return jsonClientProvider.BoolVariation(flagName, defaultValue);
        }
    }
}
