using ActEventPublisher.Domain.Entities;

namespace ActEventPublisher.Application.Interfaces
{
    public interface ISettingsManager
    {
        void Save(Settings settings);
        Settings Load();
    }
}
