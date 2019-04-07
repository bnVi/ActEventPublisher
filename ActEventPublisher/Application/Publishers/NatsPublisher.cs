using ActEventPublisher.Application.Interfaces;
using NATS.Client;
using Newtonsoft.Json;
using System;
using System.Text;

namespace ActEventPublisher.Application.Publishers
{
    public class NatsPublisher : IPublisher
    {
        private IEncodedConnection _natsConnection;

        public void SetEndpoint(string endpoint)
        {
            var cf = new ConnectionFactory();
            if (_natsConnection != null)
            {
                _natsConnection.Close();
            }

            try
            {
                _natsConnection = cf.CreateEncodedConnection(endpoint);
                _natsConnection.OnSerialize = SerializeToJson;
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Publish<T>(T content)
        {
            var subject = content.GetType().Name;

            _natsConnection.Publish(subject, content);
        }

        public void Stop()
        {
            _natsConnection.Close();
        }

        private byte[] SerializeToJson(Object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
