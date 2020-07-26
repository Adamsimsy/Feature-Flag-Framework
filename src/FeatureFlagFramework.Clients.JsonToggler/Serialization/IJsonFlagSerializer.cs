using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler.Serialization
{
    public interface IJsonFlagSerializer
    {
        T Deserialize<T>(string jsonString);

        string Serialize<t>(t jsonObject);
    }
}
