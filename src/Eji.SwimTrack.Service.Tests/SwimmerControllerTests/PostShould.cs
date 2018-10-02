using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Extensions;
using Eji.SwimTrack.Service.Controllers;
using Eji.SwimTrack.Models.Entities;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.DAL.Repositories;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Eji.SwimTrack.Models;
using Eji.SwimTrack.Service.Models.Swimmers;

namespace Eji.SwimTrack.Service.Tests.SwimmerControllerTests
{
    public class PostShould : SwimmerControllerTestBase
    {
        [Fact]
        public async void AddSwim()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);
            SwimmerData newSwimmer = new SwimmerData()
            {
                FirstName = "Jackson",
                LastName = "White",
                Nickname = "Jack",
                BirthDate = 2.March(2009)
            };


            swimmerRepo.Setup(r => r.AddAsync(It.IsAny<Swimmer>(), true)).Returns(Task.FromResult(1));

            await controller.Post(newSwimmer);

            swimmerRepo.Verify(r => r.AddAsync(It.Is<Swimmer>(s => s.FirstName == "Jackson"), true), Times.Once);
        }
 
        [Fact]
        public async void RaiseError_GivenRepositoryAddFailure()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);
            SwimmerData newSwimmer = new SwimmerData();

            // returning 0, indicating a save didn't happen
            swimmerRepo.Setup(r => r.AddAsync(It.IsAny<Swimmer>(), true)).Returns(Task.FromResult(0));

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await controller.Post(newSwimmer));
        }
    }
}
