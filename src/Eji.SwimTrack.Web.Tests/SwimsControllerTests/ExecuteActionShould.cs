using System;
using System.Collections.Generic;
using System.Text;
using Eji.SwimTrack.Web.Controllers;
using Eji.SwimTrack.Web.Models;
using Eji.SwimTrack.Web.ServiceClient;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Eji.SwimTrack.Web.Tests.SwimsControllerTests
{
    public class ExecuteActionShould
    {
        Mock<ISwimServiceClient> swimService = new Mock<ISwimServiceClient>();
        SwimsController swimController = null;

        public ExecuteActionShould()
        {
            swimController = new SwimsController(swimService.Object);
        }

        [Fact]
        public async void RedirectToPrintSheet_GivinPrintSheetAction()
        {
            IActionResult result = await swimController.Execute(SwimListCommand.PrintSheet, new[] { 1, 2, 3 });

            result.Should().BeAssignableTo<RedirectToActionResult>();

            RedirectToActionResult redirectToAction = result as RedirectToActionResult;
            redirectToAction.ActionName.Should().Be(nameof(SwimSheetController.Index));
            redirectToAction.ControllerName.Should().Be("SwimSheet");
        }
    }
}
