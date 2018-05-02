using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.Models
{
    public class SwimEditViewModel
    {
        public DateTime SwimDate { get; set; }

        public int Distance { get; set; }

        public string Stroke { get; set; }

        public bool IsRelay { get; set; }
        public bool LongCourse { get; set; }

        public int? EventNumber { get; set; }

        public int? Heat { get; set; }
        public int? Lane { get; set; }
    }
}
