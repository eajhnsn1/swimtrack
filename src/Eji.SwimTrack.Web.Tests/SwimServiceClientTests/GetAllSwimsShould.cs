using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Web.ServiceClient;
using Eji.SwimTrack.Web.Tests.Fakes;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eji.SwimTrack.Web.Tests.SwimServiceClientTests
{
    public class GetAllSwimsShould
    {
        Mock<FakeHttpMessageHandler> handler = null;
        Mock<IConfiguration> configuration = null;
        HttpClient httpClient = null;
        readonly string dummyUrl = "http://www.example.com/api/swim";

        public GetAllSwimsShould()
        {
            configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["SwimTrackServices:SwimApiUrl"]).Returns(dummyUrl);

            handler = new Mock<FakeHttpMessageHandler>() { CallBase = true };
            httpClient = new HttpClient(handler.Object);
        }

        private string GetTestResponse(string responseName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), $"ApiData.SwimApi.{responseName}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException();
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        [Fact]
        public async Task MakeHttpRequest()
        {
            handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError));

            SwimServiceClient client = new SwimServiceClient(configuration.Object, httpClient);
            await Assert.ThrowsAsync<InvalidOperationException>(() => client.GetAllSwims());

            handler.Verify(h => h.Send(It.Is<HttpRequestMessage>(r => r.RequestUri == new Uri(dummyUrl))), Times.Once);
        }

        [Fact]
        public async Task DeserializeMany_GivenSuccess()
        {
            handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(GetTestResponse("AllSwims.json"))
            });

            SwimServiceClient client = new SwimServiceClient(configuration.Object, httpClient);
            IEnumerable<SwimData> swimData = await client.GetAllSwims();

            Assert.NotNull(swimData);
            Assert.Equal(40, swimData.Count());
            Assert.True(swimData.All(d => d.Id > 0));
        }

        [Fact]
        public async Task DeserializeOne_GivenSuccess()
        {
            handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(GetTestResponse("OneSwim.json"))
            });

            SwimServiceClient client = new SwimServiceClient(configuration.Object, httpClient);
            IEnumerable<SwimData> swimData = await client.GetAllSwims();

            Assert.Collection(swimData, s =>
            {
                Assert.Equal(2, s.Id);
                Assert.Equal(50, s.Distance);
                Assert.Equal(DistanceUnits.Yards, s.DistanceUnits);
                Assert.Equal(106, s.TimeSeconds);
            });
        }
    }
}
