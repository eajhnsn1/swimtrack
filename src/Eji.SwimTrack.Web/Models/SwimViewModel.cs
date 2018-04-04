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

        public string Distance
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
