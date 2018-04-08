using Eji.SwimTrack.Service.Models.Common;
using System;

namespace Eji.SwimTrack.Service.Models
{
    /// <summary>
    /// Represents a single Swim
    /// </summary>
    public class SwimData : BaseData
    {
        public bool ShortCourse { get; set; }
        public bool Completed { get; set; }
        public DateTime? SwimDate { get; set; }

        public int Distance { get; set; }

        public DistanceUnits DistanceUnits { get; set; }

        public Stroke Stroke { get; set; }

        public int? Heat { get; set; }
        public int? Lane { get; set; }

        public decimal? TimeSeconds { get; set; }

        public bool IsRelay { get; set; }

        public string Notes { get; set; }

        public bool? DQ { get; set; }

        public int? EventNumber { get; set; }
    }
}
