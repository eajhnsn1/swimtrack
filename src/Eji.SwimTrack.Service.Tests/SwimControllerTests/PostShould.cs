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
    public class PostShould : SwimControllerTestBase
    {
        [Fact]
        public async void AddSwim()
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
        public async void RaiseError_GivenRepositoryAddFailure()
        {
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);
            SwimData newSwim = new SwimData();

            // returning 0, indicating a save didn't happen
            swimRepo.Setup(r => r.AddAsync(It.IsAny<Swim>(), true)).Returns(Task.FromResult(0));

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await controller.Post(newSwim));
        }
    }
}
