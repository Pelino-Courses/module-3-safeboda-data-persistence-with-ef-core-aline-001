using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeBoda.Infrastructure;

namespace SafeBoda.Application
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext
            services.AddDbContext<SafeBodaDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SafeBodaDb")));

            // Register EF Repository
            services.AddScoped<ITripRepository, EfTripRepository>();
        }
    }
}