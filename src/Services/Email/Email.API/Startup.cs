using Email.API.IntegrationEvents.Events;
using Email.API.IntegrationEvents.Handlers;
using EslamiSepehr.EventBus.RabbitMQ.Extenstions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Email.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEsEventBusRabbitMQ(options =>
            {
                options.HostName = Configuration["EventBus:HostName"];
                options.VirtualHost = Configuration["EventBus:VirtualHost"];
                options.UserName = Configuration["EventBus:UserName"];
                options.Password = Configuration["EventBus:Password"];
                options.BrokerName = Configuration["EventBus:BrokerName"];
                options.QueueName = Configuration["EventBus:SubscriptionClientName"];
                options.RetryCount = Convert.ToInt32(Configuration["EventBus:RetryCount"]);
                options.DispatchConsumersAsync = false;
            });

            services.AddTransient<EmailSendIntegrationEventHandler>();
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
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

            app.ConfigureEsEventBus();
            app.SubscribeEsEventBus<EmailSendIntegrationEvent, EmailSendIntegrationEventHandler>();
        }

    }
}