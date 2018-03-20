using Eji.SwimTrack.Web.ServiceClient;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Eji.SwimTrack.Web.Tests.SwimServiceClientTests
{
    public class ConstructorShould
    {
        [Fact]
        public void ReadApiUrlFromConfig()
        {
            string dummyUrl = "http://www.example.com/api/swim";
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["SwimTrackServices:SwimApiUrl"]).Returns(dummyUrl);
            Mock<IHttpClientFactory> mockFactory = new Mock<IHttpClientFactory>();

            SwimServiceClient swimClient = new SwimServiceClient(configuration.Object, mockFactory.Object);

            Assert.Equal(new Uri(dummyUrl), swimClient.ApiUri);
        }

        [Fact]
        public void FailReadingApiUrlFromConfig_GivenInvalidUrl()
        {
            string dummyUrl = "garbage";
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["SwimTrackServices:SwimApiUrl"]).Returns(dummyUrl);
            Mock<IHttpClientFactory> mockFactory = new Mock<IHttpClientFactory>();

            UriFormatException exception = Assert.Throws<UriFormatException>(() => {
                SwimServiceClient swimClient = new SwimServiceClient(configuration.Object, mockFactory.Object);
            });

            Assert.True(exception.Data.Contains("Service"));
            Assert.True(exception.Data.Contains("ConfigurationValue"));

            Assert.Equal(nameof(SwimServiceClient), exception.Data["Service"]);
            Assert.Equal(dummyUrl, exception.Data["ConfigurationValue"]);
        }
    }
}
