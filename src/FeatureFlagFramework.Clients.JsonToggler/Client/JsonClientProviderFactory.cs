using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public static class JsonClientProviderFactory
    {
        public static IJsonClientProvider GetProvider(IJsonFlagSerializer serializer, string path)
        {
            if (path.Contains("http"))
            {
                return new JsonHttpClientProvider(serializer, path);
            }
            else
            {
                return new JsonFileClientProvider(serializer, path);
            }
        }
    }
}
