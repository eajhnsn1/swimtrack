using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using Eji.SwimTrack.Web.Models;
using Eji.SwimTrack.Service.Models;

namespace Eji.SwimTrack.Web.Tests.SwimsControllerTests
{
    public class AddShould : SwimsControllerTestBase
    {
        [Fact]
        public async Task CallServiceClient()
        {
            SwimEditViewModel vm = new SwimEditViewModel();

            vm.Distance = 100;
            vm.EventNumber = 1;
            vm.Heat = 1;
            vm.Lane = 1;
            vm.IsRelay = true;
            vm.LongCourse = false;

            SwimService.Setup(s => s.AddSwim(It.IsAny<SwimData>())).Returns(Task.FromResult(0));

            await SwimController.Add(vm);

            Func<SwimData, bool> validator = (d) =>
            {
                d.Distance.Should().Be(vm.Distance);
                d.EventNumber.Should().Be(vm.EventNumber);
                d.Heat.Should().Be(vm.Heat);
                d.Lane.Should().Be(vm.Lane);
                d.IsRelay.Should().Be(vm.IsRelay);
                d.ShortCourse.Should().Be(!vm.LongCourse);

                return true;
            };

            SwimService.Verify(s => s.AddSwim(It.Is<SwimData>(swim => validator(swim))), Times.Once);
        }
    }
}
