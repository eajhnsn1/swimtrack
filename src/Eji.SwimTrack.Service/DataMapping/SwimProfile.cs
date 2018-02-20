using AutoMapper;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Models.Entities;
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
            CreateMap<CourseUnits, MeasurementUnit>().ConvertUsing(value =>
            {
                switch (value)
                {
                    case CourseUnits.Meters:
                        return MeasurementUnit.Meters;

                    case CourseUnits.Yards:
                        return MeasurementUnit.Yards;

                    default:
                        throw new NotSupportedException($"{value} is not supported in the data mapping");
                }
            });


            CreateMap<Swim, SwimData>();
        }
    }
}
