using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework
{
    public interface IFeatureFlagClient
    {
        bool Evaluate(string flagName);
    }
}
