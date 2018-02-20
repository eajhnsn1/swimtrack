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
    /// Converts CourseUnits enum to DistanceUnits.  See DistanceUnitToCourseUnitTypeConverter for the reverse
    /// </summary>
    public class CourseUnitToDistanceUnitTypeConverter : ITypeConverter<CourseUnits, DistanceUnits>
    {
        public DistanceUnits Convert(CourseUnits source, DistanceUnits destination, ResolutionContext context)
        {
            switch (source)
            {
                case CourseUnits.Meters:
                    return DistanceUnits.Meters;

                case CourseUnits.Yards:
                    return DistanceUnits.Yards;

                default:
                    return default(DistanceUnits);
            }
        }
    }
}
