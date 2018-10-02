using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Eji.SwimTrack.Service.Controllers;
using Eji.SwimTrack.Service.Models.Swimmers;
using Moq;
using Eji.SwimTrack.Models.Entities;

namespace Eji.SwimTrack.Service.Tests.SwimmerControllerTests
{
    public class PutShould : SwimmerControllerTestBase
    {

        [Fact]
        public void UpdateOnPut()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);
            SwimmerData swimmer = new SwimmerData();

            swimmer.Id = 2;
            swimmer.Nickname = "Johnny";

            // indicate a single record was updated
            swimmerRepo.Setup(r => r.Update(It.IsAny<Swimmer>(), true)).Returns(1);

            controller.Put(2, swimmer);

            // make sure Update was called on the repository 
            swimmerRepo.Verify(r => r.Update(It.Is<Swimmer>(s => s.Id == 2 && 
                                                            s.Nickname == "Johnny"), true), Times.Once);
        }

        [Fact]
        public void FailUpdateOnPut_GivenWrongId()
        {
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);
            SwimmerData swimmer = new SwimmerData();
            swimmer.Id = 2;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => controller.Put(1, swimmer));
            Assert.Contains("Invalid URL", ex.Message, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
