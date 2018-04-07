using AutoMapper;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.DataMapping.TypeConverters
{
    public class StrokeToSwimStrokeTypeConverter : ITypeConverter<Stroke, SwimStroke>
    {
        public SwimStroke Convert(Stroke source, SwimStroke destination, ResolutionContext context)
        {
            switch (source)
            {
                case Stroke.Unknown:
                    return SwimStroke.Unknown;

                case Stroke.Backstroke:
                    return SwimStroke.Backstroke;

                case Stroke.Breaststroke:
                    return SwimStroke.Breaststroke;

                case Stroke.Butterfly:
                    return SwimStroke.Butterfly;

                case Stroke.Freestyle:
                    return SwimStroke.Freestyle;

                default:
                    return default(SwimStroke);
            }
        }
    }
}
