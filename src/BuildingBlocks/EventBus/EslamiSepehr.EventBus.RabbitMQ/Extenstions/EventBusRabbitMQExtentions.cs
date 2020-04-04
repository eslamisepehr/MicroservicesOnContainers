using EslamiSepehr.EventBus.Abstractions;
using EslamiSepehr.EventBus.Events;
using EslamiSepehr.EventBus.Extenstions;
using EslamiSepehr.EventBus.RabbitMQ.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EslamiSepehr.EventBus.RabbitMQ.Extenstions
{
    public static class EventBusRabbitMQExtentions
    {
        public static void AddEsEventBusRabbitMQ(this IServiceCollection services,
                                                 Action<EventBusRabbitMQOptions> configureOptions)
        {
            configureOptions(new EventBusRabbitMQOptions());
            services.Configure(configureOptions);

            services.AddSingleton<IRabbitMQPersistentConnection, DefaultRabbitMQPersistentConnection>();
            services.AddEsEventBus<EventBusRabbitMQ>();
        }

        private static IEventBus eventBus { get; set; }

        public static void ConfigureEsEventBus(this IApplicationBuilder app)
        {
            eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        }

        public static IApplicationBuilder SubscribeEsEventBus<Event, EventHandler>(this IApplicationBuilder app)
            where Event : IntegrationEvent
            where EventHandler : IIntegrationEventHandler<Event>
        {
            eventBus.Subscribe<Event, EventHandler>();
            return app;
        }

        public static IApplicationBuilder UnsubscribeEsEventBus<Event, EventHandler>(this IApplicationBuilder app)
            where Event : IntegrationEvent
            where EventHandler : IIntegrationEventHandler<Event>
        {
            eventBus.Unsubscribe<Event, EventHandler>();
            return app;
        }

        public static IApplicationBuilder SubscribeEsEventBus<DynamicHanlder>(this IApplicationBuilder app, string eventName)
            where DynamicHanlder : IDynamicIntegrationEventHandler
        {
            eventBus.SubscribeDynamic<DynamicHanlder>(eventName);
            return app;
        }

        public static IApplicationBuilder UnsubscribeEsEventBus<DynamicHanlder>(this IApplicationBuilder app, string eventName)
            where DynamicHanlder : IDynamicIntegrationEventHandler
        {
            eventBus.UnsubscribeDynamic<DynamicHanlder>(eventName);
            return app;
        }
    }
}
