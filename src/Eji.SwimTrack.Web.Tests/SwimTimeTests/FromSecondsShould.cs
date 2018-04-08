using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Eji.SwimTrack.Web.Utility;

namespace Eji.SwimTrack.Web.Tests.SwimTimeTests
{
    public class FromSecondsShould
    {
        [Fact]
        public void Throw_GivenNegativeSeconds()
        {
            Action act = () => SwimTime.FromSeconds(-1);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ReturnAMinute_Given60Seconds()
        {
            SwimTime time = SwimTime.FromSeconds(60);
            time.Minutes.Should().Be(1);
            time.Seconds.Should().Be(0);
            time.Hundredths.Should().Be(0);
        }

        [Fact]
        public void ReturnMinutes_GivenMoreThan60Seconds()
        {
            SwimTime time = SwimTime.FromSeconds(120);
            time.Minutes.Should().Be(2);
            time.Seconds.Should().Be(0);
            time.Hundredths.Should().Be(0);
        }

        [Fact]
        public void ReturnMinutesAndSeconds_GivenMoreThan60Seconds()
        {
            SwimTime time = SwimTime.FromSeconds(130);
            time.Minutes.Should().Be(2);
            time.Seconds.Should().Be(10);
            time.Hundredths.Should().Be(0);
        }


        [Fact]
        public void ReturnHundredths()
        {
            SwimTime time = SwimTime.FromSeconds(1.02M);
            time.Minutes.Should().Be(0);
            time.Seconds.Should().Be(1);
            time.Hundredths.Should().Be(2);
        }

    }
}
