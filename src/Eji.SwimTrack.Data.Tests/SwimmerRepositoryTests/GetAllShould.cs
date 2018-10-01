using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Data.Tests.SwimmerRepositoryTests
{
    public class GetAllShould : SwimmerRepositoryTestBase
    {

        [Fact]
        public async Task ReturnAllAsync()
        {
            int expectedCount = repository.Count;
            int actualCount = (await repository.GetAllAsync()).Count();

            actualCount.Should().Be(actualCount);
        }
    }
}
