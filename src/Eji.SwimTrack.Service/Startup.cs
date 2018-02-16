using Eji.SwimTrack.DAL.Initializers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Eji.SwimTrack.DAL.EntityFramework;
using Eji.SwimTrack.DAL.Repositories;

namespace Eji.SwimTrack.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                });

            services.AddDbContext<SwimTrackContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SwimTrack")));

            services.AddScoped<ISwimRepository, SwimRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                if (Configuration.GetValue<bool>("ResetDatabase"))
                {
                    using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                    {
                        // the book was using app.ApplicationServices as the IServiceProvider here, which fails in Core 2.0.  Fails becuase that service provider
                        // didn't contain the StoreContext.
                        SwimDataInitializer.InitializeData(serviceScope.ServiceProvider);
                    }
                }

            }


            app.UseMvc();
        }
    }
}
