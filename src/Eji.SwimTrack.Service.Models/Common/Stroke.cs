using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eji.SwimTrack.Service.Models.Common
{
    public enum Stroke
    {
        [Display(Name="")]
        Unknown = 0,
        Butterfly = 1,
        Backstroke = 2,
        Breaststroke = 3,
        Freestyle = 4,
        Medley = 5
    }
}
