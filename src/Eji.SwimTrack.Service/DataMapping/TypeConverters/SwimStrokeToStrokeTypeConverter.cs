using AutoMapper;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.DataMapping.TypeConverters
{
    public class SwimStrokeToStrokeTypeConverter : ITypeConverter<SwimStroke, Stroke>
    {
        public Stroke Convert(SwimStroke source, Stroke destination, ResolutionContext context)
        {
            switch (source)
            {
                case SwimStroke.Unknown:
                    return Stroke.Unknown;

                case SwimStroke.Backstroke:
                    return Stroke.Backstroke;

                case SwimStroke.Breaststroke:
                    return Stroke.Breaststroke;

                case SwimStroke.Butterfly:
                    return Stroke.Butterfly;

                case SwimStroke.Freestyle:
                    return Stroke.Freestyle;

                case SwimStroke.Medley:
                    return Stroke.Medley;

                default:
                    return default(Stroke);
            }
        }
    }
}
