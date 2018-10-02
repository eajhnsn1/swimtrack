using AutoMapper;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models.Swimmers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.DataMapping
{
    /// <summary>
    /// Automapper profile for defining data mappings
    /// between Swimmer and SwimmerData (Entity Framework and service layer)
    /// </summary>
    public class SwimmerProfile : Profile
    {
        public SwimmerProfile()
        {
            CreateMap<SwimmerData, Swimmer>();
            CreateMap<Swimmer, SwimmerData>();
        }
    }
}
