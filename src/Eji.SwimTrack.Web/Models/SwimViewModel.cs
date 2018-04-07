using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.Models
{
    /// <summary>
    /// Single swim viwmodel
    /// </summary>
    public class SwimViewModel
    {
        SwimData swim = null;

        public DateTime? SwimDate
        {
            get { return swim.SwimDate; }
        }

        public string TimeText
        {
            get { return $"{swim.TimeSeconds} s."; }
        }

        public Decimal? TimeSeconds
        {
            get { return swim.TimeSeconds; }
        }

        public string CourseDescription
        {
            get
            {
                return swim.ShortCourse ? "short course" : "long course";
            }
        }

        public Stroke Stroke
        {
            get { return swim.Stroke; }
        }

        public int Distance
        {
            get { return swim.Distance; }
        }

        public string DistanceText
        {
            get
            {
                if (swim.Distance <= 0)
                {
                    return "Undefined";
                }

                return $"{swim.Distance} { GetDistanceName(swim.DistanceUnits)}";
            }
        }

        private string GetDistanceName(DistanceUnits units)
        {
            switch (units)
            {
                case DistanceUnits.Meters:
                    return "meter";
                case DistanceUnits.Yards:
                    return "yard";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public SwimViewModel(SwimData swim)
        {
            if (swim == null)
            {
                throw new ArgumentNullException(nameof(swim));
            }

            this.swim = swim;
        }
    }
}
