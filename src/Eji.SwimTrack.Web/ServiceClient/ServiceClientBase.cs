﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eji.SwimTrack.Web.ServiceClient
{
    /// <summary>
    /// Base class for the REST clients
    /// </summary>
    public abstract class ServiceClientBase
    {
        readonly IHttpClientFactory clientFactory = null;

        public Uri ApiUri
        {
            get;
            internal set;
        }

        public ServiceClientBase(IConfiguration configuration, IHttpClientFactory httpClientFactory, string configurationKey)
        {
            clientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(HttpClientFactory));

            LoadConfiguration(configuration, configurationKey);
        }

        private void LoadConfiguration(IConfiguration configuration, string configurationKey)
        {
            string configValue = configuration[configurationKey];

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

        protected async Task PostAsync<T>(Uri requestUri, T data)
        {
            // don't dispose client per guidelines
            HttpClient httpClient = clientFactory.CreateClient();

            string dataToPost = JsonConvert.SerializeObject(data);

            HttpResponseMessage responseMessage = await httpClient.PostAsync(requestUri, new StringContent(dataToPost));
            responseMessage.EnsureSuccessStatusCode();
        }

        protected async Task<T> GetAsync<T>(Uri requestUri)
        {
            // don't dispose client per guidelines
            HttpClient httpClient = clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);
            if (responseMessage.IsSuccessStatusCode)
            {
                string body = await responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(body);
            }
            else
            {
                throw new InvalidOperationException($"Request failed: { responseMessage.StatusCode }");
            }
        }

        /// <summary>
        /// Get the URL for retrieving a swim
        /// </summary>
        protected Uri GetObjectUri(int objectId)
        {
            UriBuilder builder = new UriBuilder(ApiUri);
            builder.Path += $"/{objectId}";

            return builder.Uri;
        }
    }
}
