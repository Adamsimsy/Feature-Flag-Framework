using FeatureFlagFramework.Clients.JsonToggler.Models;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonHttpClientProvider : IJsonClientProvider
    {
        private readonly IJsonFlagSerializer serializer;
        private readonly ToggleCollection toggleCollection;
        private readonly HttpClient httpClient;

        public JsonHttpClientProvider(IJsonFlagSerializer serializer, string url) : this(serializer, url, new HttpClient())
        {
        }

        public JsonHttpClientProvider(IJsonFlagSerializer serializer, string url, HttpClient client)
        {
            this.serializer = serializer;

            httpClient = client;

            toggleCollection = serializer.Deserialize<ToggleCollection>(GetJsonString(url));
        }

        public bool BoolVariation(string flagName, bool defaultValue)
        {
            var toggle = toggleCollection.GetToggleByName(flagName);

            return toggle != null ? toggle.Enabled : defaultValue;
        }

        private string GetJsonString(string url)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                 return httpClient.GetStringAsync(url).Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return string.Empty;
        }
    }
}
