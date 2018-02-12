using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.DAL.EntityFramework
{
    /// <summary>
    /// DbContext for SwimTrack
    /// </summary>
    public class SwimTrackContext : DbContext
    {
        public DbSet<Swim> Swims { get; set; }

        public SwimTrackContext()
        {

        }

        public SwimTrackContext(DbContextOptions options) : base (options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // if configuration wasn't done through the constructor, default our database
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SwimTrackDev;Trusted_Connection=True;MultipleActiveResultSets=true;",
                    options => options.EnableRetryOnFailure());
            }
        }
    }
}
