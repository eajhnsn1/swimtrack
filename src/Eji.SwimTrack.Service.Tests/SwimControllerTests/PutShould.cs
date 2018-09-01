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
    public class PutShould : SwimControllerTestBase
    {

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
