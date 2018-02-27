using Eji.SwimTrack.Service.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Eji.SwimTrack.Service.Tests.ControllerBaseTests
{
    public class ControllerBaseShould 
    {
        [Fact]
        public void ConvertTimeStamp_GivenEmptyString()
        {
            Mock<ControllerBase> controller = new Mock<ControllerBase>() { CallBase = true };

            Assert.Null(controller.Object.ConvertTimeStamp(""));
        }

        [Fact]
        public void ConvertTimeStampReturnEmpty_GivenInvalidString()
        {
            Mock<ControllerBase> controller = new Mock<ControllerBase>() { CallBase = true };

            Assert.Null(controller.Object.ConvertTimeStamp("a;lskdjfl;asjf883ra;j"));
        }
    }
}
