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
    public class SwimServiceClientShould
    {
        [Fact]
        public void ReadApiUrlFromConfig()
        {
            string dummyUrl = "http://www.example.com/api/swim";
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["SwimTrackServices:SwimApiUrl"]).Returns(dummyUrl);
            HttpClient httpClient = new HttpClient();

            SwimServiceClient swimClient = new SwimServiceClient(configuration.Object, httpClient);

            Assert.Equal(new Uri(dummyUrl), swimClient.ApiUri);
        }

        [Fact]
        public void FailReadingApiUrlFromConfig_GivenInvalidUrl()
        {
            string dummyUrl = "garbage";
            Mock<IConfiguration> configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["SwimTrackServices:SwimApiUrl"]).Returns(dummyUrl);
            HttpClient httpClient = new HttpClient();

            UriFormatException exception = Assert.Throws<UriFormatException>(() => {
                SwimServiceClient swimClient = new SwimServiceClient(configuration.Object, httpClient);
            });

            Assert.True(exception.Data.Contains("Service"));
            Assert.True(exception.Data.Contains("ConfigurationValue"));

            Assert.Equal(nameof(SwimServiceClient), exception.Data["Service"]);
            Assert.Equal(dummyUrl, exception.Data["ConfigurationValue"]);
        }
    }
}
