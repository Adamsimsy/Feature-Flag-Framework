using FeatureFlagFramework.Clients.JsonToggler.Models;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonHttpClientProvider : IJsonClientProvider
    {
        private readonly IJsonFlagSerializer serializer;
        private readonly string url;
        private readonly HttpClient httpClient;

        public JsonHttpClientProvider(IJsonFlagSerializer serializer, string url) : this(serializer, url, new HttpClient())
        {
        }

        public JsonHttpClientProvider(IJsonFlagSerializer serializer, string url, HttpClient client)
        {
            this.serializer = serializer;
            this.url = url;
            httpClient = client;
        }

        public async Task<FetchTogglesResult> FetchToggles()
        {
            var json = await GetJsonString(url);

            return new FetchTogglesResult()
            {
                ToggleCollection = serializer.Deserialize<ToggleCollection>(json)
            };
        }

        private async Task<string> GetJsonString(string url)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                 return await httpClient.GetStringAsync(url);
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
