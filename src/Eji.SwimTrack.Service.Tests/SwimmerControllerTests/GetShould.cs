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
using Eji.SwimTrack.Service.Models.Swimmers;
using FluentAssertions;

namespace Eji.SwimTrack.Service.Tests.SwimmerControllerTests
{
    public class GetShould : SwimmerControllerTestBase
    {
        [Fact]
        public async void ReturnAllSwimmers()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);

            IEnumerable<SwimmerData> results = await controller.Get();

            results.Should().HaveCount(2).
                And.Contain(s => s.FirstName == "Jane").
                And.Contain(s => s.FirstName == "John");
        }


        [Fact]
        public async void ReturnSwimmer_GivenId()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);

            swimmerRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns<int>(anId => Task<Swim>.FromResult(swimmers.First(s => s.Id == anId)));

            SwimmerData swimmer = await controller.Get(1);

            Assert.NotNull(swimmer);
            Assert.Equal(1, swimmer.Id);
            Assert.Equal("Jane", swimmer.FirstName);
        }

        [Fact]
        public async void ReturnNull_GivenInvalidId()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);

            swimmerRepo.Setup(r => r.FindAsync(It.IsAny<int>())).Returns(Task<Swimmer>.FromResult<Swimmer>(null));

            SwimmerData swim = await controller.Get(10);

            Assert.Null(swim);
        }

    }
}
