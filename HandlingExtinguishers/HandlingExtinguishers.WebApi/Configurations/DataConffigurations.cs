using HandlingExtinguishers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HandlingExtinguishers.WebApi.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataConffigurations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection DatabaseConfiguration(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("SQL_HANDLING_EXTINGUISHERS_CONNECTION");
            services.AddDbContext<HandlingExtinguishersDbContext>(x => x.UseSqlServer(connectionString!));
            return services;
        }
    }
}
