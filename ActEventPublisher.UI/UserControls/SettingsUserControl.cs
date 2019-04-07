using ActEventPublisher.UI.EventArgs;
using System;
using System.Windows.Forms;

namespace ActEventPublisher.UI.UserControls
{
    public partial class SettingsUserControl : UserControl
    {
        public event EventHandler<EndpointUpdatedEventArgs> OnEndpointUpdated;

        public SettingsUserControl(string endpoint)
        {
            InitializeComponent();

            endpointTextBox.Text = endpoint;
        }

        private void updateEndpointButton_Click(object sender, System.EventArgs e)
        {
            var endpoint = endpointTextBox.Text;

            OnEndpointUpdated?.Invoke(this, new EndpointUpdatedEventArgs(endpoint));
        }
    }
}
