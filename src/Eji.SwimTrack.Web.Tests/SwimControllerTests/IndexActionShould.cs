﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Eji.SwimTrack.Web.ServiceClient;
using Moq;
using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Web.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eji.SwimTrack.Web.Models;

namespace Eji.SwimTrack.Web.Tests.SwimControllerTests
{
    public class IndexActionShould
    {
        Mock<ISwimServiceClient> swimService = new Mock<ISwimServiceClient>();
        SwimController swimController = null;

        public IndexActionShould()
        {
            List<SwimData> swims = new List<SwimData>()
            {
                new SwimData() {
                    Distance = 50,
                    DistanceUnits = DistanceUnits.Yards,
                    Completed = false,
                    ShortCourse = true,
                    SwimDate = new DateTime(2018, 4, 1),
                },
                new SwimData() {
                    Distance = 100,
                    DistanceUnits = DistanceUnits.Yards,
                    Completed = false,
                    ShortCourse = true,
                    SwimDate = new DateTime(2018, 4, 1),
                }
            };

            Task<IEnumerable<SwimData>> result = Task<IEnumerable<SwimData>>.FromResult((IEnumerable<SwimData>)(swims));
            swimService.Setup(s => s.GetAllSwimsAsync()).Returns(result);

            swimController = new SwimController(swimService.Object);
        }

        [Fact]
        public async Task CreateSwimIndexViewModel()
        {
            ViewResult result = await swimController.Index() as ViewResult;

            SwimIndexViewModel vm = result.Model as SwimIndexViewModel;
            vm.Should().NotBeNull();

            vm.Swims.Should().HaveCount(2);
        }
    }
}
