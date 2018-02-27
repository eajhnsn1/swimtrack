using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.Controllers
{
    /// <summary>
    /// Base controller for containing utility methods
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        public byte[] ConvertTimeStamp(string timestampText)
        {
            if (String.IsNullOrEmpty(timestampText))
            {
                return null;
            }

            if (!timestampText.StartsWith("\""))
            {
                timestampText = $"\"{timestampText}\"";
            }

            try
            {
                return JsonConvert.DeserializeObject<byte[]>(timestampText);
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}
