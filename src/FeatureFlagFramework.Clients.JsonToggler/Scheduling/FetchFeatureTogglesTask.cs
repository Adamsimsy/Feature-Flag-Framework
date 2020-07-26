using FeatureFlagFramework.Clients.JsonToggler.Client;
using FeatureFlagFramework.Clients.JsonToggler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Scheduling
{
    internal class FetchFeatureTogglesTask
    {
        private readonly IJsonClientProvider jsonClientProvider;

        TimeSpan Interval { get; }
        private readonly ThreadSafeToggleCollection toggleCollection;

        public FetchFeatureTogglesTask(IJsonClientProvider jsonClientProvider, ThreadSafeToggleCollection toggleCollection)
        {
            this.jsonClientProvider = jsonClientProvider;
            this.toggleCollection = toggleCollection;
        }

        public async Task ExecuteAsync()
        {
            var result = await jsonClientProvider.FetchToggles();

            this.toggleCollection.Instance = result.ToggleCollection;
        }
    }
}
