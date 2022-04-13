

namespace HandlingExtinguishers.Contracts.Interfaces.Repositorios
{
    public interface ISettingsRepository
    {
        string this[string key] { get; }
    }
}
