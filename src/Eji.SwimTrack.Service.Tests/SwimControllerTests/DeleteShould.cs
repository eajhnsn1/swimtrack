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
    public class DeleteShould : SwimControllerTestBase
    {
        [Fact]
        public void RemoveSwimOnDelete()
        {
            swimRepo.Setup(r => r.Delete(It.IsAny<int>(), It.IsAny<Byte[]>(), true)).Returns(1);
            SwimController controller = new SwimController(simpleMapper, swimRepo.Object);

            byte[] tsBytes = new byte[] { 1, 1, 2, 3, 5 };
            string timestamp = JsonConvert.SerializeObject(tsBytes);

            controller.Delete(1, timestamp);

            swimRepo.Verify(r => r.Delete(1, tsBytes, true), Times.Once);
        }
    }
}
