using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetryExtensions.HttpClient;

namespace JokeCentral
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            services.AddOpenTelemetryTracing(builder =>
                builder
                    .AddAspNetCoreInstrumentation()
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("JokeCentral"))
                    .AddHttpClientInstrumentation(options =>
                        options.Enrich = ActivityNameEnricher.Enrich)
                    .AddOtlpExporter(opt => opt.Endpoint = new Uri(this.Configuration["OtelcolEndpoint"]))
                    .AddConsoleExporter()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Api}/{action=Index}/{id?}");
            });
        }
    }
}
