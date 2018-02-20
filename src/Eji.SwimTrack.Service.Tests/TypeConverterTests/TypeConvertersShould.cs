using AutoMapper;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Service.DataMapping.TypeConverters;
using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Eji.SwimTrack.Service.Tests.TypeConverterTests
{
    /// <summary>
    /// Tests the various ITypeConverters
    /// </summary>
    [Collection("AutoMapper")]
    public class TypeConvertersShould : IDisposable
    {
        /// <summary>
        /// Reset and initialize the mapper
        /// </summary>
        public TypeConvertersShould()
        {
            Mapper.Reset();
            Mapper.Initialize(m =>
            {
                m.CreateMap<CourseUnits, DistanceUnits>().ConvertUsing<CourseUnitToDistanceUnitTypeConverter>();
                m.CreateMap<DistanceUnits, CourseUnits>().ConvertUsing<DistanceUnitToCourseUnitTypeConverter>();
            });
        }

        public void Dispose()
        {
            Mapper.Reset();
        }

        [Theory]
        [InlineData(CourseUnits.Meters, DistanceUnits.Meters)]
        [InlineData(CourseUnits.Yards, DistanceUnits.Yards)]
        public void MapToDistanceUnits(CourseUnits source, DistanceUnits expected)
        {
            Assert.Equal(expected, Mapper.Map<DistanceUnits>(source));
        }

        [Theory]
        [InlineData(DistanceUnits.Meters, CourseUnits.Meters)]
        [InlineData(DistanceUnits.Yards, CourseUnits.Yards)]
        public void MapToCourseUnits(DistanceUnits source, CourseUnits expected)
        {
            Assert.Equal(expected, Mapper.Map<CourseUnits>(source));
        }
    }
}
