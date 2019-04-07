using ActEventPublisher.Application.Interfaces;
using ActEventPublisher.Domain.Entities;
using Newtonsoft.Json;
using System.IO;

namespace ActEventPublisher.Infrastructure
{
    public class SettingsManager : ISettingsManager
    {
        private readonly string _configFile;

        public SettingsManager(string configFile)
        {
            _configFile = configFile;
        }

        public void Save(Settings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText(_configFile, json);
        }

        public Settings Load()
        {
            if (File.Exists(_configFile))
            {
                var settingsJson = File.ReadAllText(_configFile);

                return JsonConvert.DeserializeObject<Settings>(settingsJson);
            }

            return CreateDefaultSettings();
        }

        private Settings CreateDefaultSettings()
        {
            var settings = new Settings()
            {
                NatsEndpoint = "localhost:4222"
            };

            Save(settings);

            return settings;
        }
    }
}
