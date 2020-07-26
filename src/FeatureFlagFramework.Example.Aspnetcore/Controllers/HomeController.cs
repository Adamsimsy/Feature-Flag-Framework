using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeatureFlagFramework.Example.Aspnetcore.Models;
using FeatureFlagFramework.Core;
using FeatureFlagFramework.Clients.JsonToggler;

namespace FeatureFlagFramework.Example.Aspnetcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureFlagClient featureFlagClientDependencyInjection;
        private readonly IFeatureFlagClient featureFlagClientServiceLocator;

        public HomeController(ILogger<HomeController> logger, IFeatureFlagClient featureFlagClient)
        {
            _logger = logger;

            //FeatureFlagFramework - Dependency Injection Client Retrieval
            this.featureFlagClientDependencyInjection = featureFlagClient;

            //FeatureFlagFramework - Service Locator Client Retrieval
            this.featureFlagClientServiceLocator = JsonTogglerFrameworkClient.Instance;
        }

        public IActionResult Index()
        {
            //FeatureFlagFramework - Dependency Injection Flag Evaluation
            ViewData["Flag-DI"] = this.featureFlagClientDependencyInjection.Evaluate("example-feature-flag", false);

            //FeatureFlagFramework - Service Locator Client Flag Evaluation
            ViewData["Flag-SL"] = this.featureFlagClientServiceLocator.Evaluate("example-feature-flag", false);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
