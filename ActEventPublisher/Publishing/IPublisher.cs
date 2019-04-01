using System;

namespace ActEventPublisher.Publishing
{
    public interface IPublisher : IDisposable
    {
        void SetEndpoint(string endpoint);
        void PublishLogLineEvent<T>(T content);
    }
}
