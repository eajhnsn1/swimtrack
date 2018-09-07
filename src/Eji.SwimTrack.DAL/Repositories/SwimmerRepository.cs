using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.DAL.Repositories
{
    public class SwimmerRepository : RepositoryBase<Swimmer>, ISwimmerRepository
    {
        public SwimmerRepository(DbContextOptions<SwimTrackContext> options)
            : base(options)
        {

        }

        public SwimmerRepository()
        {

        }
    }
}
