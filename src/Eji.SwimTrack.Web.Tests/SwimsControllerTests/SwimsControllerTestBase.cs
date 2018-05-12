using Eji.SwimTrack.Web.Controllers;
using Eji.SwimTrack.Web.ServiceClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.Web.Tests.SwimsControllerTests
{
    /// <summary>
    /// Base class for SwimsController tests
    /// </summary>
    public abstract class SwimsControllerTestBase
    {
        protected Mock<ISwimServiceClient> SwimService { get; set; } = null;
        protected SwimsController SwimController { get; set; } = null;

        public SwimsControllerTestBase()
        {
            SwimService = new Mock<ISwimServiceClient>();
            SwimController = new SwimsController(SwimService.Object);
        }
    }
}
