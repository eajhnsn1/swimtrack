using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Eji.SwimTrack.Models.Entities;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Data.Tests.SwimmerRepositoryTests
{
    public class GetFirstShould : SwimmerRepositoryTestBase
    {
        [Fact]
        public void GetTheFirstRecord()
        {
            Swimmer swimmer = repository.GetFirst();

            Assert.NotNull(swimmer);
        }

        [Fact]
        public async Task GetTheFirstRecord_GivenAsync()
        {
            Swimmer swimmer = await repository.GetFirstAsync();

            Assert.NotNull(swimmer);
            Assert.Equal(swimmer, repository.GetFirst());
        }
    }
}
