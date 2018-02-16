using Eji.SwimTrack.Models;
using Eji.SwimTrack.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.DAL.Initializers
{
    public static class SampleSwimData
    {
        public static IEnumerable<Swim> GetSwims()
        {
            List<Swim> swims = new List<Swim>();
            for (int x = 50; x <= 2000; x += 50)
            {
                Swim swim = new Swim()
                {
                    Distance = x,
                    DistanceUnits = CourseUnits.Yards,
                    TimeSeconds = (x + 3) * 2
                };

                swims.Add(swim);
            }

            return swims;
        }
    }
}
