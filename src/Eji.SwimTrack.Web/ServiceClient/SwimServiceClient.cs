using Microsoft.Extensions.Configuration;
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
        const string CONFIG_SWIMAPIURI = "SwimTrackServices:SwimApiUrl";
        HttpClient httpClient = null;

        public Uri ApiUri
        {
            get;
            internal set;
        }

        public SwimServiceClient(IConfiguration configuration, HttpClient httpClient)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            this.httpClient = httpClient;

            LoadConfiguration(configuration);
        }

        private void LoadConfiguration(IConfiguration configuration)
        {
            string configValue = configuration[CONFIG_SWIMAPIURI];

            try
            {
                ApiUri = new Uri(configValue);
            }
            catch (UriFormatException ex)
            {
                ex.Data["Service"] = nameof(SwimServiceClient);
                ex.Data["ConfigurationValue"] = configValue;

                throw;
            }
        }
    }
}
