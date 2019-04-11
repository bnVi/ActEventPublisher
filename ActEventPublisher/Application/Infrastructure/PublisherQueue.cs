using ActEventPublisher.Application.Interfaces;
using ActEventPublisher.Domain.Entities;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ActEventPublisher.Application.Infrastructure
{
    public class PublisherQueue : IPublisherQueue
    {
        private IPublisher _publisher;
        private BlockingCollection<Event> _eventQueue;

        public PublisherQueue(IPublisher publisher)
        {
            _publisher = publisher;

            _eventQueue = new BlockingCollection<Event>();
        }

        public void SetPublisherEndpoint(string endpoint)
        {
            _publisher.SetEndpoint(endpoint);
        }

        public void QueueEvent(Event e)
        {
            _eventQueue.Add(e);
        }

        public void Start()
        {
           Task.Run(() => ProcessEvents());
        }

        public void Stop()
        {
            _eventQueue.CompleteAdding();
            _publisher.Stop();
        }

        private void ProcessEvents()
        {
            foreach(var e in _eventQueue.GetConsumingEnumerable())
            {
                _publisher.Publish(e);
            }
        }
    }
}
