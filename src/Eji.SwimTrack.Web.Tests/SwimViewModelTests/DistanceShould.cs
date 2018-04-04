using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Eji.SwimTrack.Web.Tests.SwimViewModelTests
{
    public class DistanceShould
    {
        SwimData swimData = new SwimData();
        SwimViewModel swimVm = null;

        public DistanceShould()
        {
            swimVm = new SwimViewModel(swimData);
        }

        [Fact]
        public void BeDistanceText()
        {
            swimData.Distance = 50;
            swimData.DistanceUnits = DistanceUnits.Meters;

            swimVm.Distance.Should().Be("50 meter");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void BeUndefined_GivenInvalidDistance(int distance)
        {
            swimData.Distance = distance;

            swimVm.Distance.Should().Be("Undefined");
        }

    }
}
