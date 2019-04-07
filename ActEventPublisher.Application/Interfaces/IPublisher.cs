namespace ActEventPublisher.Application.Interfaces
{
    public interface IPublisher<T>
    {
        void SetEndpoint(string endpoint);
        void PublishEvent(T logline);
        void Start();
        void Stop();
    }
}
