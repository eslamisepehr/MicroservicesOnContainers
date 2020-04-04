namespace EslamiSepehr.EventBus.RabbitMQ.Options
{
    public class EventBusRabbitMQOptions
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; } = "es_event_bus_queue";
        public string BrokerName { get; set; } = "es_event_bus";
        public int RetryCount { get; set; } = 5;
        public bool DispatchConsumersAsync { get; set; } = true;
    }
}
