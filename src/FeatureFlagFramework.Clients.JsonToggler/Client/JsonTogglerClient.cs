using FeatureFlagFramework.Clients.JsonToggler.Models;
using FeatureFlagFramework.Clients.JsonToggler.Scheduling;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonTogglerClient
    {
        private readonly IJsonClientProvider jsonClientProvider;
        private readonly ThreadSafeToggleCollection toggleCollection;

        public JsonTogglerClient(IJsonFlagSerializer serializer, string path)
        {
            jsonClientProvider = JsonClientProviderFactory.GetProvider(serializer, path);

            toggleCollection = new ThreadSafeToggleCollection()
            {
                Instance = jsonClientProvider.FetchToggles().Result.ToggleCollection
            };

            var fetchFeatureTogglesTask = new FetchFeatureTogglesTask(jsonClientProvider, toggleCollection);

            Task statisticsUploader = PeriodicAsync(async () =>
            {
                try
                {
                    await fetchFeatureTogglesTask.ExecuteAsync();
                }
                catch (Exception ex)
                {
                    // Log the exception
                }
            }, TimeSpan.FromSeconds(30));
        }

        internal bool BoolVariation(string flagName, bool defaultValue)
        {
            var toggle = toggleCollection.Instance.GetToggleByName(flagName);

            return toggle != null ? toggle.Enabled : defaultValue;
        }

        public static async Task PeriodicAsync(Func<Task> taskFactory, TimeSpan interval, CancellationToken cancellationToken = default)
        {
            while (true)
            {
                var delayTask = Task.Delay(interval, cancellationToken);
                await taskFactory();
                await delayTask;
            }
        }
    }
}
