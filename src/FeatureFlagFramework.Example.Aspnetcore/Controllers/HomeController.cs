﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeatureFlagFramework.Example.Aspnetcore.Models;
using FeatureFlagFramework.CoreStandard;

namespace FeatureFlagFramework.Example.Aspnetcore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeatureFlagClient featureFlagClient;

        public HomeController(ILogger<HomeController> logger, IFeatureFlagClient featureFlagClient)
        {
            _logger = logger;
            this.featureFlagClient = featureFlagClient;
        }

        public IActionResult Index()
        {
            if(featureFlagClient.Evaluate("example-feature-flag", false))
            {
                ViewData["Flag"] = "Enabled";
            }

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