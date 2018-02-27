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
                e.CreateMap<SwimData, Swim>();
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
        public async void ReturnSwimOnGet_GivenId()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            swimRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns<int>(anId => Task<Swim>.FromResult(swims.First(s => s.Id == anId)));

            SwimData swim = await controller.Get(10);

            Assert.NotNull(swim);
            Assert.Equal(10, swim.Id);
            Assert.Equal(200, swim.Distance);
        }

        [Fact]
        public async void ReturnNullOnGet_GivenInvalidId()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            swimRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns(Task<Swim>.FromResult<Swim>(null));

            SwimData swim = await controller.Get(10);

            Assert.Null(swim);
        }

        [Fact]
        public async void AddOnPost()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);
            SwimData newSwim = new SwimData();
            newSwim.Distance = 100;
            newSwim.TimeSeconds = 40;

            swimRepo.Setup(r => r.AddAsync(It.IsAny<Swim>(), true)).Returns(Task.FromResult(1));

            await controller.Post(newSwim);

            swimRepo.Verify(r => r.AddAsync(It.Is<Swim>(s => s.Distance == 100), true), Times.Once);
        }
 
        [Fact]
        public async void AddOnPostRaisesError_GivenRepositoryAddFailure()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);
            SwimData newSwim = new SwimData();

            // returning 0, indicating a save didn't happen
            swimRepo.Setup(r => r.AddAsync(It.IsAny<Swim>(), true)).Returns(Task.FromResult(0));

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await controller.Post(newSwim));
        }

        [Fact]
        public void UpdateOnPut()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);
            SwimData newSwim = new SwimData();
            newSwim.Distance = 100;
            newSwim.TimeSeconds = 40;
            newSwim.Id = 300;

            // indicate a single record was updated
            swimRepo.Setup(r => r.Update(It.IsAny<Swim>(), true)).Returns(1);

            controller.Put(300, newSwim);

            // make sure Update was called on the repository 
            swimRepo.Verify(r => r.Update(It.Is<Swim>(s => s.Id == 300 && 
                                                            s.Distance == 100 && 
                                                            s.TimeSeconds == 40), true), Times.Once);
        }

        [Fact]
        public void FailUpdateOnPut_GivenWrongId()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);
            SwimData newSwim = new SwimData();
            newSwim.Id = 300;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => controller.Put(1, newSwim));
            Assert.Contains("Invalid URL", ex.Message, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
