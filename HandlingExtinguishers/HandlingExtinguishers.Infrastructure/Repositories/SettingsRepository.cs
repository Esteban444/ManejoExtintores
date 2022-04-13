using HandlingExtinguishers.Contracts.Interfaces.Repositorios;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class SettingsRepository: ISettingsRepository
    {
        public string this[string key]
        {
            get
            {
                var value = Environment.GetEnvironmentVariable(key);
                return value ?? string.Empty;
            }
        }
    }
}
