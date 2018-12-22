using Eji.SwimTrack.Web.ServiceClient;
using Eji.SwimTrack.Web.ServiceClient.Options;
using Eji.SwimTrack.Web.Tests.Fakes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Eji.SwimTrack.Web.Tests.SwimServiceClientTests
{
    public class SwimServiceClientTestBase
    {
        Mock<FakeHttpMessageHandler> handler = null;
        Mock<IConfiguration> configuration = null;
        Mock<IHttpClientFactory> factory = null;

        protected SwimServiceClient Client { get; set;  }
        protected Mock<FakeHttpMessageHandler> Handler { get; set;  }

        protected readonly string dummyUrl = "http://www.example.com/api/swim";

        public SwimServiceClientTestBase()
        {
            Handler = new Mock<FakeHttpMessageHandler>() { CallBase = true };
            HttpClient httpClient = new HttpClient(Handler.Object);

            factory = new Mock<IHttpClientFactory>();
            factory.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(httpClient);

            Mock<IOptions<SwimServiceClientOptions>> options = new Mock<IOptions<SwimServiceClientOptions>>();
            options.Setup(o => o.Value).Returns(new SwimServiceClientOptions() { Url = dummyUrl });

            Client = new SwimServiceClient(options.Object, factory.Object);
        }

        protected void SetupResponseFailure(HttpStatusCode status)
        {
            Handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage()
            {
                StatusCode = status,
                Content = new StringContent("")
            });
        }

        /// <summary>
        /// Sets up a response for a particular URI
        /// </summary>
        protected void SetupResponseContent(string uriPath, string responseFileName)
        {
            UriBuilder uriBuilder = new UriBuilder(dummyUrl);
            uriBuilder.Path += uriPath;

            Handler.Setup(h => h.Send(It.Is<HttpRequestMessage>(r => r.RequestUri == uriBuilder.Uri))).Returns(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(GetTestResponse(responseFileName))
            });
        }

        protected void SetupResponseEmptyBodySuccess()
        {
            Handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("")
            });
        }

        protected void SetupResponseContent(string responseFileName)
        {
            Handler.Setup(h => h.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(GetTestResponse(responseFileName))
            });
        }

        protected string GetTestResponse(string responseName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetType(), $"ApiData.SwimApi.{responseName}"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException();
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
