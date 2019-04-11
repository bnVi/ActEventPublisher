using ActEventPublisher.Domain.Entities;

namespace ActEventPublisher.Application.Interfaces
{
    public interface IPublisherQueue
    {
        void SetPublisherEndpoint(string endpoint);
        void QueueEvent(Event e);
        void Start();
        void Stop();
    }
}
