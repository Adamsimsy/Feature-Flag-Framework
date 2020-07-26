using FeatureFlagFramework.Clients.JsonToggler.Client;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FeatureFlagFramework.Clients.JsonToggler.Tests.Client
{
    public class JsonHttpClientProviderTests
    {
        [Fact]
        public void BoolVariation_WhenFlagExistsInHttpEndpoint_FlagObjectReturned()
        {
            //Arrange
            var testUrl = "http://localhost/api/flags/*";
            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When(testUrl)
                    .Respond("application/json", "{ \"features\" : [{ \"name\" : \"test\", \"enabled\": true }] }");

            var provide = new JsonHttpClientProvider(new JsonFlagSerializer(), testUrl, mockHttp.ToHttpClient());

            //Act
            var result = provide.BoolVariation("test", false);

            //Assert
            Assert.True(result);
        }
    }
}
