using Eji.SwimTrack.Service.Controllers;
using Moq;
using Newtonsoft.Json;
using System.Linq;
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

        [Fact]
        public void ConvertTimeStamp()
        {
            Mock<ControllerBase> controller = new Mock<ControllerBase>() { CallBase = true };

            byte[] timeStamp = new byte[] { 1, 2, 3, 4, 5, 6 };
            string stringContent = JsonConvert.SerializeObject(timeStamp);

            byte[] converted = controller.Object.ConvertTimeStamp(stringContent);

            Assert.True(converted.SequenceEqual(timeStamp));
        }
    }
}
