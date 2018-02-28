using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Service.Converters
{
    public static class TimeStampConverter
    {
        /// <summary>
        /// Converts a text/json timestamp into the byte array needed by 
        /// the data layer
        /// </summary>
        public static byte[] ConvertTimeStamp(string timestampText)
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
