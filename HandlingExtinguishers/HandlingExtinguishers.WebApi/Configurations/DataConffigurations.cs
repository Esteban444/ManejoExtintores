using HandlingExtinguishers.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HandlingExtinguishers.WebApi.Configurations
{
    public static class DataConffigurations
    {
        public static IServiceCollection DatabaseConfiguration(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("SQL_HANDLING_EXTINGUISHERS_CONNECTION");
            services.AddDbContext<HandlingExtinguishersDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
