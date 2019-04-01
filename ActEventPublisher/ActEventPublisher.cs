using ActEventPublisher.Settings;
using ActEventPublisher.Publishing;
using ActEventPublisher.UserControls;
using Advanced_Combat_Tracker;
using System.Windows.Forms;

namespace ActEventPublisher
{
    public class ActEventPublisher : IActPluginV1
    {
        private ISettingsManager _settingsManager;
        private IPublisher _publisher;
        private Label _statusLabel;

        public ActEventPublisher()
        {
            var configFile = $@"{ActGlobals.oFormActMain.AppDataFolder.FullName}\Config\ActEventPublisher.config.txt";
            _settingsManager = new SettingsManager(configFile);

            _publisher = new Publisher();
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _statusLabel = pluginStatusText;

            var endpoint = _settingsManager.Load();

            InitializeSettingsUserControl(pluginScreenSpace, endpoint);

            _publisher.SetEndpoint(endpoint);

            RegisterEventListeners();

            _statusLabel.Text = "Plugin Started.";
        }

        public void DeInitPlugin()
        {
            DeregisterEventListeners();

            _statusLabel.Text = "Plugin Stopped.";
        }

        private void InitializeSettingsUserControl(TabPage pluginScreenSpace, string endpoint)
        {
            var settingsUserControl = new SettingsUserControl(endpoint);
            settingsUserControl.OnEndpointUpdated += UpdateEndpoint;

            pluginScreenSpace.Controls.Add(settingsUserControl);
        }

        private void RegisterEventListeners()
        {
            ActGlobals.oFormActMain.OnLogLineRead += PublishLogLineEvent;
        }

        private void DeregisterEventListeners()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= PublishLogLineEvent;
        }

        private void PublishLogLineEvent(bool isImport, LogLineEventArgs e)
        {
            _publisher.PublishLogLineEvent(e);
        }

        private void UpdateEndpoint(object sender, EndpointUpdatedEventArgs e)
        {
            _publisher.SetEndpoint(e.Endpoint);
            _settingsManager.Save(e.Endpoint);
        }
    }
}
