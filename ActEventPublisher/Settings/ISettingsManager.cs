namespace ActEventPublisher.Settings
{
    public interface ISettingsManager
    {
        void Save(string endpoint);
        string Load();
    }
}
