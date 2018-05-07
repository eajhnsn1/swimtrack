using Eji.SwimTrack.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using System.Net.Http;

namespace Eji.SwimTrack.Web.Tests.SwimServiceClientTests
{
    public class AddSwimShould : SwimServiceClientTestBase
    {
        [Fact]
        public void Throw_GivenFailure()
        {
            SetupResponseFailure(System.Net.HttpStatusCode.BadRequest);

            SwimData swimData = new SwimData();

            // func so that an async can be awaited
            Func<Task> addAction = async () => { await Client.AddSwim(swimData); };

            addAction.Should().Throw<HttpRequestException>();
        }
    }
}
