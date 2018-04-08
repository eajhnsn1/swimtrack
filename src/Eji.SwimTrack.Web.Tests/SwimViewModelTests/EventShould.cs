using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Web.Models;

namespace Eji.SwimTrack.Web.Tests.SwimViewModelTests
{
    public class EventShould
    {
        [Fact]
        public void CombineDistanceAndStroke()
        {
            SwimData swim = new SwimData()
            {
                Distance = 50,
                Stroke = Stroke.Backstroke,
            };


            SwimViewModel swimVm = new SwimViewModel(swim);

            swimVm.Event.Should().Be("50 Backstroke");
        }

        [Fact]
        public void ReturnIM()
        {
            SwimData swim = new SwimData()
            {
                Distance = 200,
                Stroke = Stroke.Medley,
            };


            SwimViewModel swimVm = new SwimViewModel(swim);

            swimVm.Event.Should().Be("200 Individual Medley");
        }

        [Fact]
        public void ReturnRelayMedley()
        {
            SwimData swim = new SwimData()
            {
                Distance = 200,
                Stroke = Stroke.Medley,
                IsRelay = true
            };

            SwimViewModel swimVm = new SwimViewModel(swim);

            swimVm.Event.Should().Be("200 Medley Relay");
        }

        [Fact]
        public void ReturnFreestyleRelay()
        {
            SwimData swim = new SwimData()
            {
                Distance = 200,
                Stroke = Stroke.Freestyle,
                IsRelay = true
            };

            SwimViewModel swimVm = new SwimViewModel(swim);

            swimVm.Event.Should().Be("200 Freestyle Relay");
        }
    }
}
