using System.Net.Http;

namespace ActEventPublisher.Publishing
{
    public class Publisher : IPublisher
    { 
        private static readonly HttpClient _client = new HttpClient();
        private string _endpoint;

        public void SetEndpoint(string endpoint)
        {
            _endpoint = endpoint;
        }

        public void PublishLogLineEvent<T>(T content)
        {
            PublishEvent(_endpoint+"/logline", content);
        }

        private void PublishEvent<T>(string endpoint, T content)
        {
            _client.PostAsJsonAsync(endpoint, content);
        }
    }
}
