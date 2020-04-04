using EslamiSepehr.EventBus.Events;

namespace Book.API.IntegrationEvents.Events
{
    public class EmailSendIntegrationEvent : IntegrationEvent
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailSendIntegrationEvent(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}
