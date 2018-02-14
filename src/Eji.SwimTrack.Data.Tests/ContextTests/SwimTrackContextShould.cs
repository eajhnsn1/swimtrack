using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Eji.SwimTrack.Data.Tests.ContextTests
{
    /// <summary>
    /// Following a naming convention proposed by @brendoneus 
    /// </summary>
    [Collection("Swim.DAL")]
    public class SwimTrackContextShould : IDisposable
    {
        private readonly SwimTrackContext db;

        public SwimTrackContextShould()
        {
            DbContextOptions<SwimTrackContext> options = new DbContextOptionsBuilder<SwimTrackContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;

            db = new SwimTrackContext(options);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        /// <summary>
        /// Sort of a useless test since we know EntityFramework works :)
        /// 
        /// But, gotta start somewhere
        /// </summary>
        [Fact]
        public void AddASwimWithDbSet()
        {
            Swim swim = new Swim() { Distance = 100, DistanceUnits= Models.CourseUnits.Meters, TimeSeconds=30 };
            db.Swims.Add(swim);

            db.SaveChanges();
            Assert.Equal(EntityState.Unchanged, db.Entry(swim).State);
            Assert.Equal(1, db.Swims.Count());
        }

        [Fact]
        public void RetrieveAllSwims()
        {
            Swim swim = new Swim() { Distance = 250, DistanceUnits= Models.CourseUnits.Meters, TimeSeconds=30 };
            Swim swim2 = new Swim() { Distance = 100, DistanceUnits= Models.CourseUnits.Meters, TimeSeconds=30 };
            Swim swim3 = new Swim() { Distance = 500, DistanceUnits= Models.CourseUnits.Meters, TimeSeconds=30 };
            db.Swims.Add(swim);
            db.Swims.Add(swim2);
            db.Swims.Add(swim3);

            db.SaveChanges();

            var swims = db.Swims.OrderBy(o => o.Distance).ToList();
            Assert.Equal(3, swims.Count);
            Assert.Equal(100, swims[0].Distance);
            Assert.Equal(250, swims[1].Distance);
            Assert.Equal(500, swims[2].Distance);
        }
    }
}
