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

namespace Eji.SwimTrack.Service.Tests.SwimControllerTests
{
    public class SwimControllerShould
    {
        // rather than mock mapping, just using a dead simple automapper map
        IMapper simpleMapper;

        // mock repository
        Mock<ISwimRepository> swimRepo;

        // fake swims
        List<Swim> swims;

        public SwimControllerShould()
        {
            MapperConfiguration mapConfig = new MapperConfiguration(e =>
            {
                e.CreateMap<Swim, SwimData>();
            });
            simpleMapper = mapConfig.CreateMapper();

            swims = new List<Swim>()
            {
                new Swim() { Distance = 100, Id = 1, TimeSeconds = 500},
                new Swim() { Distance = 200, Id = 10, TimeSeconds = 1000},
                new Swim() { Distance = 400, Id = 100, TimeSeconds = 2000}
            };

            Task<IEnumerable<Swim>> repoResult = Task<IEnumerable<Swim>>.FromResult<IEnumerable<Swim>>(swims);

            swimRepo = new Mock<ISwimRepository>();
            swimRepo.Setup(r => r.GetAllAsync()).Returns(repoResult);
            swimRepo.Setup(r => r.GetAll()).Returns(swims);
        }

        [Fact]
        public async void ReturnAllSwimsOnGet()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            IEnumerable<SwimData> results = await controller.Get();

            Assert.Collection(results, s => { Assert.Equal(100, s.Distance); },
                                       s => { Assert.Equal(200, s.Distance); },
                                       s => { Assert.Equal(400, s.Distance); });
        }


        [Fact]
        public async void ReturnSwimGivenId()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            swimRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns<int>(anId => Task<Swim>.FromResult(swims.First(s => s.Id == anId)));

            SwimData swim = await controller.Get(10);

            Assert.NotNull(swim);
            Assert.Equal(10, swim.Id);
            Assert.Equal(200, swim.Distance);
        }
    }
}
