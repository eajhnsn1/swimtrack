using Eji.SwimTrack.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Eji.SwimTrack.Web.Tests.SwimServiceClientTests
{
    public class GetSwimShould : SwimServiceClientTestBase
    {
        [Fact]
        public async Task GetOne_GivenSuccess()
        {
            SetupResponseContent("/2", "SingleSwim.json");

            SwimData swim = await Client.GetSwim(2);

            swim.Should().NotBeNull();
            swim.Id.Should().Be(2);
            swim.Distance.Should().Be(50);
            swim.TimeSeconds.Should().Be(106);
        }
    }
}
