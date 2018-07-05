using Eji.SwimTrack.Models.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eji.SwimTrack.Models.Entities
{
    /// <summary>
    /// Represents a single recorded swim
    /// </summary>
    [Table("Swims")]
    public class Swim : EntityBase
    {
        /// <summary>
        /// When the swim has or will occur
        /// </summary>
        public DateTime? SwimDate { get; set; }

        /// <summary>
        /// Whether the swim has been completed
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Long or short course
        /// </summary>
        public bool ShortCourse { get; set; }

        /// <summary>
        /// Event# at a meet
        /// </summary>
        public int? EventNumber { get; set; }

        /// <summary>
        /// Heat Number
        /// </summary>
        public int? Heat { get; set; }

        /// <summary>
        /// Lane Number
        /// </summary>
        public int? Lane { get; set; }

        /// <summary>
        /// Length of the swim
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Meter or Yard metric
        /// </summary>
        public CourseUnits DistanceUnits { get; set; }

        /// <summary>
        /// Which of the 4 strokes
        /// </summary>
        public SwimStroke Stroke { get; set; }

        /// <summary>
        /// Swim time
        /// </summary>
        public decimal? TimeSeconds { get; set; }

        /// <summary>
        /// Relay swim 
        /// </summary>
        public bool IsRelay { get; set; }

        [Column(TypeName="nvarchar(max)")]
        public string Notes { get; set; }

        public bool? DQ { get; set; }

        public int? SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }
    }
}
