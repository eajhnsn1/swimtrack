using AutoMapper;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.DataMapping.TypeConverters
{
    /// <summary>
    /// Converts DistanceUnits enum to CourseUnits.  See CourseUnitToDistanceUnitTypeConverter for the reverse
    /// </summary>
    public class DistanceUnitToCourseUnitTypeConverter : ITypeConverter<DistanceUnits, CourseUnits>
    {
        public CourseUnits Convert(DistanceUnits source, CourseUnits destination, ResolutionContext context)
        {
            switch (source)
            {
                case DistanceUnits.Meters:
                    return CourseUnits.Meters;

                case DistanceUnits.Yards:
                    return CourseUnits.Yards;

                default:
                    return default(CourseUnits);
            }
        }
    }
}
