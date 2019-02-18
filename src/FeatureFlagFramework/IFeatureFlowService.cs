using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework
{
    public interface IFeatureFlowService
    {
        IFeatureFlagClient Client { get; }
    }
}
