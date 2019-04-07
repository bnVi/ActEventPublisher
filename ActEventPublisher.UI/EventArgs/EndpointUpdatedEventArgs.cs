namespace ActEventPublisher.UI.EventArgs
{
    public class EndpointUpdatedEventArgs : System.EventArgs
    {
        public string Endpoint { get; private set; }

        public EndpointUpdatedEventArgs(string endpoint)
        {
            Endpoint = endpoint;
        }
    }
}
