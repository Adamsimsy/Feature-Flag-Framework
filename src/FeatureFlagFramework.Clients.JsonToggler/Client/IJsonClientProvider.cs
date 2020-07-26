using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public interface IJsonClientProvider
    {
        bool BoolVariation(string flagName, bool defaultValue);
    }
}
