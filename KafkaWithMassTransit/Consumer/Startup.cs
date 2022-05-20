using Consumer.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Producer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Consumer
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
                x.AddRider(rider =>
                {
                    rider.AddConsumer<VideoDeletedEventConsumer>();
                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("localhost:9092");
                        k.TopicEndpoint<VideoDeletedEvent>(nameof(VideoDeletedEvent), GetUniqueName(nameof(VideoDeletedEvent)), e => {
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<VideoDeletedEventConsumer>(context);
                        });
                    });
                });
            });
            services.AddMassTransitHostedService();
        }

        private string GetUniqueName(string eventName)
        {
            string hostName = Dns.GetHostName();
            string classAssembly = Assembly.GetCallingAssembly().GetName().Name;
            return $"{hostName}.{classAssembly}.{eventName}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
