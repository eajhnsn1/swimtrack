using Eji.SwimTrack.Service.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        IHttpClientFactory clientFactory = null;

        public Uri ApiUri
        {
            get;
            internal set;
        }

        public SwimServiceClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory == null)
            {
                throw new ArgumentNullException(nameof(httpClientFactory));
            }

            this.clientFactory = httpClientFactory;

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

        /// <summary>
        /// Retrieve all swims
        /// </summary>
        public async Task<IEnumerable<SwimData>> GetAllSwims()
        {
            HttpClient httpClient = clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync(ApiUri);
            if (responseMessage.IsSuccessStatusCode)
            {
                string body = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<SwimData>>(body);
            }
            else
            {
                throw new InvalidOperationException($"Request failed: { responseMessage.StatusCode }");
            }
        }
    }
}
