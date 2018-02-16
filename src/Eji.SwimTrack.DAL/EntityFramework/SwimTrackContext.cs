using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            // skip migrations during unit testing 
            if (!Database.ProviderName.EndsWith("InMemory"))
            {
                Database.Migrate();
            }
        }

        /// <summary>
        /// Model is being generated
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Swim>().Property(p => p.TimeSeconds).HasColumnType("decimal(8, 2)");
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
