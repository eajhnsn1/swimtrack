using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.DAL.Repositories;
using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Data.Tests.RepositoryTests
{
    [Collection("SwimTrack.DAL")]
    public class SwimRepositoryShould : IDisposable
    {
        private readonly SwimRepository repository;

        public SwimRepositoryShould()
        {
            DbContextOptions<SwimTrackContext> options = new DbContextOptionsBuilder<SwimTrackContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            repository = new SwimRepository(options);

            LoadSampleData();
        }

        public void Dispose()
        {
            repository.Dispose();
        }

        private void LoadSampleData()
        {
            List<Swim> swims = new List<Swim>();
            for (int x = 0; x < 10; x++)
            {
                swims.Add(new Swim() { Distance = (x + 1) * 100, DistanceUnits = Models.CourseUnits.Meters });
            }

            repository.AddRange(swims);
        }

        [Fact]
        public async Task ReturnAllAsync()
        {
            int expectedCount = repository.Count;

            int actualCount = (await repository.GetAllAsync()).Count();
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public void ContainAllSwims()
        {
            // this is really testing AddRange done in the setup
            Assert.Equal(10, repository.Count);
        }

        [Fact]
        public void AssignIds()
        {
            foreach (Swim swim in repository.GetAll())
            {
                Assert.True(swim.Id > 0);
            }
        }

        [Fact]
        public void DeleteBySwim()
        {
            Swim swimToDelete = repository.GetAll().Skip(4).First();
            int id = swimToDelete.Id;

            Assert.Equal(1, repository.Delete(swimToDelete));

            Assert.Null(repository.Find(id));
        }

        [Fact]
        public void DeleteByIdAndTimestamp()
        {
            Swim swimToDelete = repository.GetAll().Skip(4).First();
            int id = swimToDelete.Id;
            byte[] ts = swimToDelete.Timestamp;

            Assert.Equal(1, repository.Delete(id, ts));

            Assert.Null(repository.Find(id));
        }

        [Fact]
        public void ReturnFirst()
        {
            Swim swim = repository.GetFirst();

            Assert.NotNull(swim);
        }

        [Fact]
        public async Task ReturnFirstAsync()
        {
            Swim swim = await repository.GetFirstAsync();

            Assert.NotNull(swim);
            Assert.Equal(swim, repository.GetFirst());
        }

        [Fact]
        public void UpdateSwim()
        {
            Swim swim = repository.GetFirst();
            int initialCount = repository.Count;

            swim.Distance = 99;
            Assert.Equal(1, repository.Update(swim));

            // make sure an add wasn't performed
            Assert.Equal(initialCount, repository.Count);
            Assert.Equal(99, repository.GetFirst().Distance);            
        }

        [Fact]
        public void AddSingleSwim()
        {
            Swim newSwim = new Swim() { Distance = 50, DistanceUnits = Models.CourseUnits.Yards, TimeSeconds = 200 };
            int initialCount = repository.Count;

            Assert.Equal(1, repository.Add(newSwim));
            Assert.Equal(initialCount + 1, repository.Count);
        }

        [Fact]
        public async Task AddSingleSwimAsync()
        {
            Swim newSwim = new Swim() { Distance = 50, DistanceUnits = Models.CourseUnits.Yards, TimeSeconds = 200 };
            int initialCount = repository.Count;

            Assert.Equal(1, await repository.AddAsync(newSwim));
            Assert.Equal(initialCount + 1, repository.Count);
        }
    }
}
