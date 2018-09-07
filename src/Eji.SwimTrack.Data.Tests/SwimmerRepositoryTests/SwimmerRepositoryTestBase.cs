using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.DAL.Repositories;
using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.Data.Tests.SwimmerRepositoryTests
{
    public abstract class SwimmerRepositoryTestBase : IDisposable
    {
        protected readonly SwimmerRepository repository;

        public SwimmerRepositoryTestBase()
        {

            DbContextOptions<SwimTrackContext> options = new DbContextOptionsBuilder<SwimTrackContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            repository = new SwimmerRepository(options);

            LoadSampleData();
        }

        private void LoadSampleData()
        {
            List<Swimmer> swimmers = new List<Swimmer>();

            for (int x = 0; x < 10; x++)
            {
                swimmers.Add(new Swimmer()
                {
                    FirstName = $"FirstName{x}",
                    LastName = $"LastName{x}",
                    DisplayName = $"DisplayName{x}",
                    Nickname = $"NickName{x}",
                    BirthDate = new DateTime(2000, 4, 1),
                });
            }

            repository.AddRange(swimmers);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
