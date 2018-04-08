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

        public override string ToString()
        {
            string total = "";

            total = (Seconds + (Hundredths / 100.0)).ToString("0.00");

            if (Minutes > 0)
            {
                if (Seconds < 10)
                {
                    total = $"{Minutes}:0{total}";
                }
                else
                {
                    total = $"{Minutes}:{total}";
                }
            }

            return total;
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
