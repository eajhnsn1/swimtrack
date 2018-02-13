using Eji.SwimTrack.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eji.SwimTrack.Models.Entities
{
    /// <summary>
    /// Represents a single recorded swim
    /// </summary>
    [Table("Swims")]
    public class Swim : EntityBase
    {
        public int Distance { get; set; }

        public CourseUnits DistanceUnits { get; set; }

        public Nullable<decimal> TimeSeconds { get; set; }
    }
}
