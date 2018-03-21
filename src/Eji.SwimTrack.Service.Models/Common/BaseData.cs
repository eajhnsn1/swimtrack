using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.Service.Models.Common
{
    /// <summary>
    /// Base class for DTO objects *Data for the SwimTrack API
    /// </summary>
    public abstract class BaseData
    {
        public int Id { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
