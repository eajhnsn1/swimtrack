using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using AutoMapper;
using Eji.SwimTrack.Service.Controllers;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.DAL.Repositories;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Eji.SwimTrack.Models;

namespace Eji.SwimTrack.Service.Tests.SwimControllerTests
{
    public abstract class SwimControllerTestBase
    {
        // rather than mock mapping, just using a dead simple automapper map
        protected IMapper simpleMapper;

        // mock repository
        protected Mock<ISwimRepository> swimRepo;

        // fake swims
        protected List<Swim> swims;

        public SwimControllerTestBase()
        {
            MapperConfiguration mapConfig = new MapperConfiguration(e =>
            {
                e.CreateMap<Swim, SwimData>();
                e.CreateMap<SwimData, Swim>();
            });
            simpleMapper = mapConfig.CreateMapper();

            swims = new List<Swim>()
            {
                new Swim() { ShortCourse = true, DistanceUnits = CourseUnits.Meters, Distance = 100, Id = 1, TimeSeconds = 500},
                new Swim() { ShortCourse = true, DistanceUnits = CourseUnits.Meters, Distance = 200, Id = 10, TimeSeconds = 1000},
                new Swim() { ShortCourse = false, DistanceUnits = CourseUnits.Yards, Distance = 400, Id = 100, TimeSeconds = 2000}
            };

            Task<IEnumerable<Swim>> repoResult = Task<IEnumerable<Swim>>.FromResult<IEnumerable<Swim>>(swims);

            swimRepo = new Mock<ISwimRepository>();
            swimRepo.Setup(r => r.GetAllAsync()).Returns(repoResult);
            swimRepo.Setup(r => r.GetAll()).Returns(swims);
        }
    }
}
