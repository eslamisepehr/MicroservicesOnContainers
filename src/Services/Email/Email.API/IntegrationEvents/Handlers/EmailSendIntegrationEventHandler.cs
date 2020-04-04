using Email.API.IntegrationEvents.Events;
using EslamiSepehr.EventBus.Abstractions;
using System.Threading.Tasks;

namespace Email.API.IntegrationEvents.Handlers
{
    public class EmailSendIntegrationEventHandler : IIntegrationEventHandler<EmailSendIntegrationEvent>
    {
        public Task Handle(EmailSendIntegrationEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
