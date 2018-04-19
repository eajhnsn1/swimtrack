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
    public class GetAllSwimsShould : SwimServiceClientTestBase
    {
        public GetAllSwimsShould()
        {
        }


        [Fact]
        public async Task MakeHttpRequest()
        {
            Handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError));

            await Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetAllSwimsAsync());

            Handler.Verify(h => h.Send(It.Is<HttpRequestMessage>(r => r.RequestUri == new Uri(dummyUrl))), Times.Once);
        }

        [Fact]
        public async Task DeserializeMany_GivenSuccess()
        {
            SetupResponseContent("AllSwims.json");

            IEnumerable<SwimData> swimData = await Client.GetAllSwimsAsync();

            Assert.NotNull(swimData);
            Assert.Equal(40, swimData.Count());
            Assert.True(swimData.All(d => d.Id > 0));
        }

        [Fact]
        public async Task DeserializeOne_GivenSuccess()
        {
            SetupResponseContent("OneSwim.json");

            IEnumerable<SwimData> swimData = await Client.GetAllSwimsAsync();

            Assert.Collection(swimData, s =>
            {
                Assert.Equal(2, s.Id);
                Assert.Equal(50, s.Distance);
                Assert.Equal(DistanceUnits.Yards, s.DistanceUnits);
                Assert.Equal(106, s.TimeSeconds);
            });
        }

        [Fact]
        public async Task DeserializationFails_GivenServiceFailure()
        {
            SetupResponseFailure(System.Net.HttpStatusCode.InternalServerError);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await Client.GetAllSwimsAsync());
        }
    }
}
