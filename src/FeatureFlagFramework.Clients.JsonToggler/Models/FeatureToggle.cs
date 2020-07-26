using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureFlagFramework.Clients.JsonToggler.Models
{
    public class FeatureToggle
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}
