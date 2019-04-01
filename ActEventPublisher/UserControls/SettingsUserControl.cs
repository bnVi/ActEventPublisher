using System;
using System.Windows.Forms;

namespace ActEventPublisher.UserControls
{
    public partial class SettingsUserControl : UserControl
    {
        public event EventHandler<EndpointUpdatedEventArgs> OnEndpointUpdated;

        public SettingsUserControl(string endpoint)
        {
            InitializeComponent();

            endpointTextBox.Text = endpoint;
        }

        private void updateEndpointButton_Click(object sender, EventArgs e)
        {
            var endpoint = endpointTextBox.Text;

            OnEndpointUpdated?.Invoke(this, new EndpointUpdatedEventArgs(endpoint));
        }
    }

    public class EndpointUpdatedEventArgs : EventArgs
    {
        public string Endpoint { get; private set; }

        public EndpointUpdatedEventArgs(string endpoint)
        {
            Endpoint = endpoint;
        }
    }

}
