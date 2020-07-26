using FeatureFlagFramework.Clients.JsonToggler.Models;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonFileClientProvider : IJsonClientProvider
    {
        private readonly IJsonFlagSerializer serializer;
        private readonly string filePath;

        public JsonFileClientProvider(IJsonFlagSerializer serializer, string filePath)
        {
            this.serializer = serializer;
            this.filePath = filePath;
        }

        public async Task<FetchTogglesResult> FetchToggles()
        {
            var json = await GetJsonString(filePath);

            return new FetchTogglesResult()
            {
                ToggleCollection = serializer.Deserialize<ToggleCollection>(json)
            };
        }

        private async Task<string> GetJsonString(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
