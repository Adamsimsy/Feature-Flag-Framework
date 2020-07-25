using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.CoreStandard
{
    public interface IFeatureFlowService
    {
        IFeatureFlagClient Client { get; }
    }
}
