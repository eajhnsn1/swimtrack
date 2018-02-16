using System;
using System.Collections.Generic;
using System.Text;
using Eji.SwimTrack.DAL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Eji.SwimTrack.DAL.Initializers
{
    public static class SwimDataInitializer
    {
        public static void InitializeData(IServiceProvider provider)
        {
            SwimTrackContext context = provider.GetService<SwimTrackContext>();
            InitializeData(context);
        }

        public static void InitializeData(SwimTrackContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
        private static void SeedData(SwimTrackContext context)
        {
            if (!context.Swims.Any())
            {
                context.Swims.AddRange(SampleSwimData.GetSwims());
                context.SaveChanges();
            }
        }

        private static void ClearData(SwimTrackContext context)
        {
            ExecuteDeleteSQL(context, "swims");
            ResetIdentity(context);
        }

        private static void ResetIdentity(SwimTrackContext context)
        {
            foreach (string table in new string[] { "swims"})
            {
                string sql = $"DBCC CHECKIDENT ('dbo.{table}', RESEED,  1)";
                context.Database.ExecuteSqlCommand(sql);
            }
        }

        private static void ExecuteDeleteSQL(SwimTrackContext context, string tableName)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM dbo." + tableName); 
        }
    }
}
