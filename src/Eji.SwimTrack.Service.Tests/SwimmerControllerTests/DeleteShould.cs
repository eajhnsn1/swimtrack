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

namespace Eji.SwimTrack.Service.Tests.SwimmerControllerTests
{
    public class DeleteShould : SwimmerControllerTestBase
    {
        [Fact]
        public void RemoveSwimOnDelete()
        {
            swimmerRepo.Setup(r => r.Delete(It.IsAny<int>(), It.IsAny<Byte[]>(), true)).Returns(1);
            SwimmerController controller = new SwimmerController(simpleMapper, swimmerRepo.Object);

            byte[] tsBytes = new byte[] { 1, 1, 2, 3, 5 };
            string timestamp = JsonConvert.SerializeObject(tsBytes);

            controller.Delete(1, timestamp);

            swimmerRepo.Verify(r => r.Delete(1, tsBytes, true), Times.Once);
        }
    }
}
