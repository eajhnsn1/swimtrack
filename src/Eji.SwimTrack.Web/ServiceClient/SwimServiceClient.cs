using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.ServiceClient
{
    /// <summary>
    /// REST client for the swim api
    /// </summary>
    public class SwimServiceClient : ISwimServiceClient
    {
        HttpClient httpClient = null;

        public SwimServiceClient(HttpClient httpClient)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            this.httpClient = httpClient;
        }
    }
}
