using FeatureFlagFramework.Clients.JsonToggler.Models;
using FeatureFlagFramework.Clients.JsonToggler.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FeatureFlagFramework.Clients.JsonToggler.Tests.Serialization
{
    public class JsonFlagSerializerTests
    {
        private IJsonFlagSerializer serializer;

        public JsonFlagSerializerTests()
        {
            serializer = new JsonFlagSerializer();
        }

        [Fact]
        public void Deserialize_WhenStringIsValidJson_FlagObjectReturned()
        {
            //Arrange
            var value = "{ \"features\" : [{ \"name\" : \"test\", \"enabled\": true }] }";

            //Act
            var result = serializer.Deserialize<ToggleCollection>(value);

            //Assert
            Assert.True(result.GetToggleByName("test").Enabled);
        }

        [Fact]
        public void Serialize_WhenValidObject_StringReturned()
        {
            //Arrange
            var value = new ToggleCollection() { Features = new List<FeatureToggle>() { new FeatureToggle() { Name = "Test", Enabled = true } } };

            //Act
            var result = serializer.Serialize(value);

            //Assert
            Assert.Contains("Test", result);
            Assert.Contains("true", result);
        }
    }
}
