using Eji.SwimTrack.Service.Models;
using Eji.SwimTrack.Service.Models.Common;
using Eji.SwimTrack.Web.Utility;
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
            get
            {
                if (swim.TimeSeconds.HasValue)
                {
                    SwimTime swimTime = SwimTime.FromSeconds(swim.TimeSeconds.Value);
                    return swimTime.ToString();
                }
                else
                {
                    return "";
                }
            }
        }

        public int Id
        {
            get { return swim.Id; }
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

        public int? Heat
        {
            get { return swim.Heat; }
        }

        public int? Lane
        {
            get { return swim.Lane; }
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

        public string Event
        {
            get
            {
                return $"{Distance} { GetSwimName(swim.Stroke, swim.IsRelay) }";
            }
        }

        public int? EventNumber
        {
            get { return swim.EventNumber; }
        }

        public bool? IsRelay
        {
            get { return swim.IsRelay; }
        }

        public string Notes
        {
            get { return swim.Notes; }
        }

        public bool? DQ
        {
            get { return swim.DQ; }
        }

        private string GetSwimName(Stroke stroke, bool relay)
        {
            string name = "";
            switch (stroke)
            {
                case Stroke.Backstroke:
                    name = "Backstroke";
                    break;
                case Stroke.Breaststroke:
                    name = "Breaststroke";
                    break;
                case Stroke.Butterfly:
                    name = "Butterfly";
                    break;
                case Stroke.Freestyle:
                    name = "Freestyle";
                    break;
                case Stroke.Medley:
                    name = "Medley";
                    break;
            }

            if (!relay && stroke == Stroke.Medley)
            {
                name = "Individual Medley";
            }
            else if (relay)
            {
                name = $"{ name } Relay";
            }

            return name;
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
