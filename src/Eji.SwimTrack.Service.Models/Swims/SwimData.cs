﻿using Eji.SwimTrack.Service.Models.Common;
using System;

namespace Eji.SwimTrack.Service.Models
{
    /// <summary>
    /// Represents a single Swim
    /// </summary>
    public class SwimData : BaseData
    {
        public int Distance { get; set; }

        public MeasurementUnit DistanceUnit { get; set; }

        public Nullable<decimal> TimeSeconds { get; set; }
    }
}