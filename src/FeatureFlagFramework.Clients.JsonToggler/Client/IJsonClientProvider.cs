using FeatureFlagFramework.Clients.JsonToggler.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public interface IJsonClientProvider
    {
        Task<FetchTogglesResult> FetchToggles();
    }
}
