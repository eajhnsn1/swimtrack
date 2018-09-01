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
    public class GetShould : SwimControllerTestBase
    {
        [Fact]
        public async void ReturnAllSwims()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            IEnumerable<SwimData> results = await controller.Get();

            Assert.Collection(results, s => { Assert.Equal(100, s.Distance); Assert.True(s.ShortCourse); },
                                       s => { Assert.Equal(200, s.Distance); Assert.True(s.ShortCourse); },
                                       s => { Assert.Equal(400, s.Distance); Assert.False(s.ShortCourse); });
        }


        [Fact]
        public async void ReturnSwim_GivenId()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            swimRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns<int>(anId => Task<Swim>.FromResult(swims.First(s => s.Id == anId)));

            SwimData swim = await controller.Get(10);

            Assert.NotNull(swim);
            Assert.Equal(10, swim.Id);
            Assert.Equal(200, swim.Distance);
        }

        [Fact]
        public async void ReturnNull_GivenInvalidId()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            swimRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns(Task<Swim>.FromResult<Swim>(null));

            SwimData swim = await controller.Get(10);

            Assert.Null(swim);
        }

    }
}
