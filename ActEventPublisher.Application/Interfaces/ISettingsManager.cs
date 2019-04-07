namespace ActEventPublisher.Application.Interfaces
{
    public interface ISettingsManager
    {
        void Save(string endpoint);
        string Load();
    }
}
