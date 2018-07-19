using Eji.SwimTrack.Models.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eji.SwimTrack.Data.Tests.SwimRepositoryTests
{
    public class GetAllShould : SwimRepositoryTestBase
    {
        [Fact]
        public void SetupTest_ContainAllSwims()
        {
            // this is really testing AddRange done in the setup
            Assert.Equal(10, repository.Count);
        }

        [Fact]
        public void SetupTest_AssignIds()
        {
            foreach (Swim swim in repository.GetAll())
            {
                Assert.True(swim.Id > 0);
            }
        }

        [Fact]
        public async Task ReturnAllAsync()
        {
            int expectedCount = repository.Count;
            int actualCount = (await repository.GetAllAsync()).Count();

            actualCount.Should().Be(actualCount);
        }
    }
}
