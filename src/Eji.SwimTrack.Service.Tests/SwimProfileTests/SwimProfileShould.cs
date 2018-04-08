using AutoMapper;
using Xunit;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Service.DataMapping;
using Eji.SwimTrack.Models;
using FluentAssertions;

namespace Eji.SwimTrack.Service.Tests.SwimProfileTests
{
    [Collection("AutoMapper")]
    public class SwimProfileShould 
    {
        public SwimProfileShould()
        {
            Mapper.Reset();
            Mapper.Initialize(m => m.AddProfile<SwimProfile>());
        }

        [Fact]
        public void MapSwimToSwimData()
        {
            Swim swim = new Swim();
            swim.Distance = 100;
            swim.DistanceUnits = SwimTrack.Models.CourseUnits.Meters;
            swim.Id = 100;
            swim.TimeSeconds = 123.45M;
            swim.Timestamp = new byte[] { 1, 2, 3 };
            swim.Stroke = SwimStroke.Backstroke;
            swim.Heat = 10;
            swim.Lane = 4;
            swim.IsRelay = true;
            swim.Notes = "test";
            swim.EventNumber = 100;
            swim.DQ = true;

            SwimData swimData = Mapper.Map<SwimData>(swim);

            swimData.Should().NotBeNull();
            swimData.Distance.Should().Be(swim.Distance);
            swimData.DistanceUnits.Should().Be(DistanceUnits.Meters);
            swimData.Id.Should().Be(swim.Id);
            swimData.TimeSeconds.Should().Be(swim.TimeSeconds);
            swimData.Heat.Should().Be(swim.Heat);
            swimData.Lane.Should().Be(swim.Lane);
            swimData.Stroke.Should().Be(Stroke.Backstroke);
            swimData.IsRelay.Should().Be(swim.IsRelay);
            swimData.DQ.Should().Be(swim.DQ);
            swimData.Notes.Should().Be(swim.Notes);
            swimData.EventNumber.Should().Be(swim.EventNumber);
        }
    }
}
