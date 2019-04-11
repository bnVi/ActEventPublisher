using ActEventPublisher.Application.Infrastructure;
using ActEventPublisher.Application.Publishers;
using ActEventPublisher.Application.Interfaces;
using ActEventPublisher.Infrastructure;
using ActEventPublisher.UI.EventArgs;
using ActEventPublisher.UI.UserControls;
using Advanced_Combat_Tracker;
using System.Windows.Forms;

namespace ActEventPublisher
{
    class PluginManager
    {
        private ISettingsManager _settingsManager;
        private IPublisherQueue _publisherQueue;

        private TabPage _screenSpace;
        private Label _statusLabel;

        public PluginManager(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _screenSpace = pluginScreenSpace;
            _statusLabel = pluginStatusText;

            var configFile = ActPluginExtensions.ConfigFullPath("ActEventPublisher.config.json");
            _settingsManager = new SettingsManager(configFile);

            _publisherQueue = new PublisherQueue(new NatsPublisher());
        }

        public void Start()
        {
            var settings = _settingsManager.Load();

            _publisherQueue.SetPublisherEndpoint(settings.NatsEndpoint);
            _publisherQueue.Start();

            var settingsUserControl = new SettingsUserControl(settings.NatsEndpoint);
            settingsUserControl.OnEndpointUpdated += UpdateEndpoint;

            _screenSpace.Controls.Add(settingsUserControl);

            AddActEventHandlers();

            _statusLabel.Text = "Plugin Started.";
        }

        public void Stop()
        {
            RemoveActEventHandlers();

            _publisherQueue.Stop();

            _statusLabel.Text = "Plugin Stopped.";
        }

        private void AddActEventHandlers()
        {
            ActGlobals.oFormActMain.OnLogLineRead += PublishLogLineEvent;
            ActGlobals.oFormActMain.OnCombatStart += PublishCombatStartEvent;
            ActGlobals.oFormActMain.OnCombatEnd += PublishCombatEndEvent;
        }

        private void RemoveActEventHandlers()
        {
            ActGlobals.oFormActMain.OnLogLineRead -= PublishLogLineEvent;
            ActGlobals.oFormActMain.OnCombatStart -= PublishCombatStartEvent;
            ActGlobals.oFormActMain.OnCombatEnd -= PublishCombatEndEvent;
        }

        private void UpdateEndpoint(object sender, EndpointUpdatedEventArgs e)
        {
            _publisherQueue.SetPublisherEndpoint(e.Endpoint);

            var settings = _settingsManager.Load();
            settings.NatsEndpoint = e.Endpoint;

            _settingsManager.Save(settings);
        }

        private void PublishLogLineEvent(bool isImport, LogLineEventArgs e)
        {
            _publisherQueue.QueueEvent(e.ToLogLineEvent());
        }

        private void PublishCombatStartEvent(bool isImport, CombatToggleEventArgs e)
        {
            _publisherQueue.QueueEvent(e.ToCombatStartEvent());
        }

        private void PublishCombatEndEvent(bool isImport, CombatToggleEventArgs e)
        {
            _publisherQueue.QueueEvent(e.ToCombatEndEvent());
        }
    }
}
