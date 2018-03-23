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
        /// Length of the swim
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// Meter or Yard metric
        /// </summary>
        public CourseUnits DistanceUnits { get; set; }

        /// <summary>
        /// Swim time
        /// </summary>
        public Nullable<decimal> TimeSeconds { get; set; }
    }
}
