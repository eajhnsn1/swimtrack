using Eji.SwimTrack.Service.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eji.SwimTrack.Service.Models.Swimmers
{
    /// <summary>
    /// A single swimmer
    /// </summary>
    public class SwimmerData : BaseData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Nickname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
