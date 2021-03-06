﻿using FeatureFlagFramework.Clients.JsonToggler.Client;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace FeatureFlagFramework.Clients.JsonToggler.Tests.Client
{
    public class JsonFileClientProviderTests
    {
        [Fact]
        public void BoolVariation_WhenFlagExistsInJsonFile_FlagObjectReturned()
        {
            //Arrange
            string basePath = Environment.CurrentDirectory;
            string relativePath = "..\\..\\Files\\valid.json";

            string fullPath = Path.GetFullPath(relativePath, basePath);

            //Fix live unit testing path
            fullPath = fullPath.Replace("bin", "").Replace(".vs\\FeatureFlagFramework\\v16\\lut\\0\\t", "");

            var provider = new JsonFileClientProvider(new JsonFlagSerializer(), fullPath);

            //Act
            var result = provider.FetchToggles().Result.ToggleCollection.GetToggleByName("example-feature-flag");

            //Assert
            Assert.True(result.Enabled);
        }
    }
}
