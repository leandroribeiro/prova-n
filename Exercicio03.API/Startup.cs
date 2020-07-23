using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicio03.API.Infrastructure;
using Exercicio03.Application;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Exercicio03.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddHealthChecks()
                .AddProcessAllocatedMemoryHealthCheck(512); // 512 MB max allocated memory;

            services
                .AddHealthChecksUI(s => s.AddHealthCheckEndpoint("ready", "http://localhost/health"))
                .AddInMemoryStorage();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["Cache:Connection"];
            });

            services.AddScoped<MultiploDeOnzeValidator>();
            services.AddScoped<IMultiploDeOnzeValidator>(provider => new CachedMultiploDeOnzeValidator(
                provider.GetRequiredService<MultiploDeOnzeValidator>(),
                provider.GetRequiredService<IDistributedCache>()));

            //services.AddSingleton<IMultiploDeOnzeValidator, CachedMultiploDeOnzeValidator>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecksUI(options => options.UIPath = "/health-ui");
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }).RequireHost("*:80", "*:443", "*:5000", "*:5001");
            });
        }
    }
}