using FeatureFlagFramework.Clients.JsonToggler.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FeatureFlagFramework.Clients.JsonToggler.Models
{
    internal sealed class ThreadSafeToggleCollection : ReaderWriterLockSlimOf<ToggleCollection>
    {
    }

    public class ToggleCollection
    {
        [JsonIgnore]
        private Dictionary<string, FeatureToggle> Dictionary
        { get
            {
                Features = Features ?? new List<FeatureToggle>(0);
                var Dictionary = new Dictionary<string, FeatureToggle>(Features.Count);

                foreach (var featureToggle in Features)
                {
                    Dictionary.Add(featureToggle.Name, featureToggle);
                }
                return Dictionary;
            }
        }

        public ICollection<FeatureToggle> Features { get; set; }

        public FeatureToggle GetToggleByName(string name)
        {
            return Dictionary.TryGetValue(name, out var value)
                ? value
                : null;
        }
    }
}
