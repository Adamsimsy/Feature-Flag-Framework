using FeatureFlagFramework.Clients.JsonToggler.Models;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonFileClientProvider : IJsonClientProvider
    {
        private readonly IJsonFlagSerializer serializer;
        private readonly ToggleCollection toggleCollection;

        public JsonFileClientProvider(IJsonFlagSerializer serializer, string filePath)
        {
            this.serializer = serializer;

            var jsonString = File.ReadAllText(filePath);
            toggleCollection = serializer.Deserialize<ToggleCollection>(jsonString);

        }

        public bool BoolVariation(string flagName, bool defaultValue)
        {
            var toggle = toggleCollection.GetToggleByName(flagName);

            return toggle != null ? toggle.Enabled : defaultValue;
        }
    }
}
