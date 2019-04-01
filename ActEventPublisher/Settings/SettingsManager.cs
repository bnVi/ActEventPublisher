using System.IO;

namespace ActEventPublisher.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private readonly string _configFile;

        public SettingsManager(string configFile)
        {
            _configFile = configFile;
        }

        public void Save(string endpoint)
        {
            File.WriteAllText(_configFile, endpoint);
        }

        public string Load()
        {
            if (File.Exists(_configFile))
            {
                var endpoint = File.ReadAllText(_configFile);
                return endpoint;
            }

            return string.Empty;
        }
    }
}
