using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.DAL.Repositories;
using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.Data.Tests.SwimRepositoryTests
{
    public abstract class SwimRepositoryTestBase : IDisposable
    {
        protected readonly SwimRepository repository;

        public SwimRepositoryTestBase()
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
    }
}
