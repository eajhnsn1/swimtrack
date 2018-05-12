using Eji.SwimTrack.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using System.Net.Http;
using Moq;
using Newtonsoft.Json;

namespace Eji.SwimTrack.Web.Tests.SwimServiceClientTests
{
    public class AddSwimShould : SwimServiceClientTestBase
    {
        [Fact]
        public void Throw_GivenFailure()
        {
            SetupResponseFailure(System.Net.HttpStatusCode.BadRequest);

            SwimData swimData = new SwimData();

            // func so that an async can be awaited
            Func<Task> addAction = async () => { await Client.AddSwim(swimData); };

            addAction.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public async Task PostJsonData()
        {
            SwimData originalData = new SwimData()
            {
                Completed = false,
                Distance = 100,
                DistanceUnits = Service.Models.Common.DistanceUnits.Meters,
                DQ = false,
                EventNumber = 100,
                Heat = 4,
                Lane = 1,
                IsRelay = false,
                Notes = "testing",
                ShortCourse = true,
                Stroke = Service.Models.Common.Stroke.Backstroke,
                SwimDate = DateTime.Parse("5/1/2018"),
                TimeSeconds = 400,
            };

            SetupResponseEmptyBodySuccess();

            await Client.AddSwim(originalData);

            Func<HttpRequestMessage, bool> validation = (m =>
            {
                string sentContent = (m.Content as StringContent)?.ReadAsStringAsync().Result ?? "";
                sentContent.Should().Be(JsonConvert.SerializeObject(originalData));

                return true;
            });

            // check what was sent aover the wire
            Handler.Verify(h => h.Send(It.Is<HttpRequestMessage>(m => validation(m))), Times.Once);
        }
    }
}
