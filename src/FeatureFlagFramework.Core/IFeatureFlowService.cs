using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Core
{
    public interface IFeatureFlowService
    {
        IFeatureFlagClient Client { get; }
    }
}
