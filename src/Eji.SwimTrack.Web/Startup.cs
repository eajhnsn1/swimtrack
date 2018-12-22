using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Eji.SwimTrack.Web.ServiceClient;
using Eji.SwimTrack.Web.ServiceClient.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NonFactors.Mvc.Grid;

namespace Eji.SwimTrack.Web
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
            services.AddMvc();

            // Guidance is to have ONE http client in the app
            // .NET Core 2.1 will include an httpclientfactory, which should be used
            // instead.  For now, just do it like this.
            services.AddTransient<ISwimServiceClient, SwimServiceClient>()
                    .AddHttpClient()
                    .AddMvcGrid();

            services.Configure<SwimServiceClientOptions>(Configuration.GetSection("SwimTrackServices:Swim"));
            services.Configure<SwimmerServiceClientOptions>(Configuration.GetSection("SwimTrackServices:Swimmer"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
