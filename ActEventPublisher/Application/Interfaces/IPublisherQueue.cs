namespace ActEventPublisher.Application.Interfaces
{
    public interface IPublisherQueue
    {
        void SetPublisherEndpoint(string endpoint);
        void QueueEvent<T>(T content);
        void Start();
        void Stop();
    }
}
