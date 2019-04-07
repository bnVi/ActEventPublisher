using ActEventPublisher.Application.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ActEventPublisher.Application.Infrastructure
{
    public class PublisherQueue : IPublisherQueue
    {
        private IPublisher _publisher;
        private BlockingCollection<object> _queue;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public PublisherQueue(IPublisher publisher)
        {
            _publisher = publisher;

            _queue = new BlockingCollection<object>();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void SetPublisherEndpoint(string endpoint)
        {
            _publisher.SetEndpoint(endpoint);
        }

        public void QueueEvent<T>(T content)
        {
            _queue.Add(content);
        }

        public void Start()
        {
            Task.Run(() => Run(_cancellationTokenSource.Token));
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();

            _publisher.Stop();
        }

        private void Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var content = _queue.Take(cancellationToken);

                    _publisher.Publish(content);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    }
}
