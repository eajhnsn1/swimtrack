using AutoMapper;
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
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup(Mock.Of<IConfiguration>());

            startup.ConfigureServices(services);

            ServiceProvider provider = services.BuildServiceProvider();
            IMapper mapper = provider.GetService<IMapper>();
            Assert.NotNull(mapper);
        }
    }
}
