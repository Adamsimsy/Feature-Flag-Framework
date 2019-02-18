using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework
{
    public interface IFeatureFlagClient
    {
        bool Evaluate(string flagName, bool defaultValue);
        int Evaluate(string flagName, int defaultValue);
        string Evaluate(string flagName, string defaultValue);
    }
}
