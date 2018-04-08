using Eji.SwimTrack.Web.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Eji.SwimTrack.Web.Tests.SwimTimeTests
{
    public class ToStringShould
    {
        [Fact]
        public void OutputLeadingTrailingZero_GivenHundredthsOnly()
        {
            SwimTime time = SwimTime.FromSeconds(0.90M);

            time.ToString().Should().Be("0.90");
        }

        [Fact]
        public void OutputLeadingHundredthsZero_GivenLessThan10Hundredths()
        {
            SwimTime time = SwimTime.FromSeconds(0.02M);

            time.ToString().Should().Be("0.02");
        }

        [Fact]
        public void OutputSecondsAndHundredths()
        {
            SwimTime time = SwimTime.FromSeconds(30.21M);

            time.ToString().Should().Be("30.21");
        }

        [Fact]
        public void OutputMinutesSecondsAndHundredths_WithLeadingSecondsZero()
        {
            SwimTime time = SwimTime.FromSeconds(65.01M);

            time.ToString().Should().Be("1:05.01");
        }

        [Fact]
        public void OutputMinutesSecondsAndHundredths()
        {
            SwimTime time = SwimTime.FromSeconds(65.25M);

            time.ToString().Should().Be("1:05.25");
        }
    }
}
