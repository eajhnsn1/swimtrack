using Eji.SwimTrack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eji.SwimTrack.Data.Tests.SwimRepositoryTests
{
    public class ReturnFirstShould : SwimRepositoryTestBase
    {
        [Fact]
        public void GetTheFirstRecord()
        {
            Swim swim = repository.GetFirst();

            Assert.NotNull(swim);
        }

        [Fact]
        public async Task GetTheFirstRecordAsync()
        {
            Swim swim = await repository.GetFirstAsync();

            Assert.NotNull(swim);
            Assert.Equal(swim, repository.GetFirst());
        }
    }
}
