using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Service.DataMapping;
using Eji.SwimTrack.Models;

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

            SwimData swimData = Mapper.Map<SwimData>(swim);

            Assert.NotNull(swimData);
            Assert.Equal(swim.Distance, swimData.Distance);
            Assert.Equal(DistanceUnits.Meters, swimData.DistanceUnits);
            Assert.Equal(swim.Id, swimData.Id);
            Assert.Equal(swim.TimeSeconds, swimData.TimeSeconds);
        }
    }
}
