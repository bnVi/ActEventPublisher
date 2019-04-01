using System;

namespace ActEventPublisher.Publishing
{
    public interface IPublisher
    {
        void SetEndpoint(string endpoint);
        void PublishLogLineEvent<T>(T content);
    }
}
