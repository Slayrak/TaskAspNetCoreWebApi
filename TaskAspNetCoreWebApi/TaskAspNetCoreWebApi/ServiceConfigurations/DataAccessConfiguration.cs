using Microsoft.EntityFrameworkCore;
using TaskAspNetCoreWebApi.DataAccess;

namespace TaskAspNetCoreWebApi.ServiceConfigurations
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase(databaseName: "WebApiDatabaseName"));

            return services;
        }

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
                        DataSeed.SeedData(context);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
