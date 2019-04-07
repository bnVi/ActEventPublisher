namespace ActEventPublisher.Application.Interfaces
{
    public interface IPublisher
    {
        void SetEndpoint(string endpoint);
        void Publish<T>(T content);
        void Stop();
    }
}
