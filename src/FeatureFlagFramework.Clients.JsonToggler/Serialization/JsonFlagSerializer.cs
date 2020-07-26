using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FeatureFlagFramework.Clients.JsonToggler.Serialization
{
    public class JsonFlagSerializer : IJsonFlagSerializer
    {
        private static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public T Deserialize<T>(string jsonString)
        {    
            return JsonSerializer.Deserialize<T>(jsonString, Options);
        }

        public string Serialize<t>(t jsonObject)
        {
            return JsonSerializer.Serialize(jsonObject, Options);
        }
    }
}
