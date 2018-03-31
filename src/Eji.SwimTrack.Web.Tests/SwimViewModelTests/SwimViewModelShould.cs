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
    public class SwimViewModelShould
    {
        [Fact]
        public void ReturnDistance()
        {
            SwimData swimData = new SwimData();
            swimData.Distance = 50;
            swimData.DistanceUnits = DistanceUnits.Meters;

            SwimViewModel vm = new SwimViewModel(swimData);

            vm.Distance.Should().Be("50 meter");
        }
    }
}
