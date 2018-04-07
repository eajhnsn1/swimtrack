using AutoMapper;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.DataMapping.TypeConverters;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.DataMapping
{
    /// <summary>
    /// AutoMapper profile for defining data mappings
    /// </summary>
    public class SwimProfile : Profile
    {
        public SwimProfile()
        {
            CreateMap<CourseUnits, DistanceUnits>().ConvertUsing<CourseUnitToDistanceUnitTypeConverter>();
            CreateMap<SwimStroke, Stroke>().ConvertUsing<SwimStrokeToStrokeTypeConverter>();

            CreateMap<Swim, SwimData>();
            CreateMap<SwimData, Swim>();
        }
    }
}
