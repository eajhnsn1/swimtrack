using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.Utility
{
    /// <summary>
    /// Represents a swim time result
    /// </summary>
    public class SwimTime
    {
        decimal? totalSeconds;

        public int Minutes
        {
            get; internal set;
        }
        public int Seconds
        {
            get; internal set;
        }
        public int Hundredths
        {
            get; internal set;
        }

        public static SwimTime FromSeconds(decimal seconds)
        {
            if (seconds < 0)
            {
                throw new ArgumentException($"{ nameof(seconds) } must be greater than or equal to zero.", nameof(seconds));
            }


            int min = (int)seconds / 60;
            int sec = (int)seconds % 60;
            int hundredths = (int)((seconds - Math.Floor(seconds)) * 100);

            return new SwimTime()
            {
                Minutes = min,
                Seconds = sec,
                Hundredths = hundredths
            };
        }
    }
}
