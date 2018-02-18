using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Eji.SwimTrack.Service.Tests
{
    public class StartupShould
    {
        [Fact]
        public void RegisterAutoMapperProfile()
        {
            /*
            Mock<IServiceCollection> services = new Mock<IServiceCollection>();
            services.SetupAllProperties();

            Startup startup = new Startup(Mock.Of<IConfiguration>());
            startup.Configure(Mock.Of<IApplicationBuilder>(), Mock.Of<IHostingEnvironment>(), Mock.Of<ILoggerFactory>());
            */
        }
    }
}
