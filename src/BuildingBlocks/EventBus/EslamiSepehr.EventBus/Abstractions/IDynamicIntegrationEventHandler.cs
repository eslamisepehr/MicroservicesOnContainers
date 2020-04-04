using System.Threading.Tasks;

namespace EslamiSepehr.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
