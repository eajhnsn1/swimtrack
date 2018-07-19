using Eji.SwimTrack.Models.Entities;
using System.Threading.Tasks;
using Xunit;

namespace Eji.SwimTrack.Data.Tests.SwimRepositoryTests
{
    public class AddShould : SwimRepositoryTestBase
    {
        [Fact]
        public void AddASwim()
        {
            Swim newSwim = new Swim() { Distance = 50, DistanceUnits = Models.CourseUnits.Yards, TimeSeconds = 200 };
            int initialCount = repository.Count;

            Assert.Equal(1, repository.Add(newSwim));
            Assert.Equal(initialCount + 1, repository.Count);
        }

        [Fact]
        public async Task AddASwimAsync()
        {
            Swim newSwim = new Swim() { Distance = 50, DistanceUnits = Models.CourseUnits.Yards, TimeSeconds = 200 };
            int initialCount = repository.Count;

            Assert.Equal(1, await repository.AddAsync(newSwim));
            Assert.Equal(initialCount + 1, repository.Count);
        }
    }
}
